using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dev4Tech
{
    public partial class AdicionarEquipes : Form
    {
        AddEquipes equipe = new AddEquipes();
        private List<string> membrosSelecionados = new List<string>();
        private List<string> funcionariosSelecionados = new List<string>();

        public AdicionarEquipes()
        {
            InitializeComponent();
            panelDadosFunc.AutoScroll = true; // Habilita o scroll automático
            this.Load += AdicionarEquipes_Load;
            btnAddMembro.Click += btnAddMembro_Click;
            btnCriarEquipe.Click += btnCriarEquipe_Click;
            // Adiciona o evento para quando o email for selecionado
            cbmEmailMembro.SelectedIndexChanged += cbmEmailMembro_SelectedIndexChanged;
            // Inclui os eventos para evitar erros
            cmbCategoriaEquipe.SelectedIndexChanged += cmbCategoriaEquipe_SelectedIndexChanged;
            txtNomeEquipe.TextChanged += txtNomeEquipe_TextChanged;
        }

        private void AdicionarEquipes_Load(object sender, EventArgs e)
        {
            CarregarCategorias();
            CarregarEmailsFuncionarios();
            cmbCategoriaEquipe.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void CarregarCategorias()
        {
            try
            {
                DataTable dtCategorias = equipe.ConsultarCategorias();
                cmbCategoriaEquipe.Items.Clear();
                foreach (DataRow row in dtCategorias.Rows)
                {
                    cmbCategoriaEquipe.Items.Add(row["nome_categoria"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
            }
        }

        private void CarregarEmailsFuncionarios()
        {
            try
            {
                DataTable dtEmails = equipe.ConsultarEmailsFuncionarios();
                cbmEmailMembro.Items.Clear();
                foreach (DataRow row in dtEmails.Rows)
                {
                    cbmEmailMembro.Items.Add(row["email"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar emails: " + ex.Message);
            }
        }

        // Métodos adicionados para evitar erros de eventos não definidos
        private void txtNomeEquipe_TextChanged(object sender, EventArgs e)
        {
            // Pode deixar vazio ou implementar se desejar
        }

        private void cmbCategoriaEquipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Pode deixar vazio ou implementar se desejar
        }

        private void cbmEmailMembro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string emailSelecionado = cbmEmailMembro.Text.Trim();
            if (!string.IsNullOrEmpty(emailSelecionado) && !funcionariosSelecionados.Contains(emailSelecionado))
            {
                funcionariosSelecionados.Add(emailSelecionado);
                AtualizarListaFuncionarios();
            }
        }

        private void AtualizarListaFuncionarios()
        {
            panelDadosFunc.Controls.Clear();
            int posY = 10; // posição inicial vertical
            foreach (string email in funcionariosSelecionados)
            {
                empresaCadFuncionario func = BuscarFuncionarioPorEmail(email);
                if (func == null)
                    continue;

                pontuacaoUsuarios ptFunc = new pontuacaoUsuarios();
                int idFunc = int.Parse(func.getFuncionarioId());
                int pontos = ptFunc.ObterPontos(idFunc);

                Panel funcPanel = new Panel
                {
                    Width = panelDadosFunc.Width - 20,
                    Height = 100,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Left = 10,
                    Top = posY
                };

                PictureBox picFuncionario = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 80,
                    Height = 80,
                    Left = 10,
                    Top = 10,
                    BorderStyle = BorderStyle.FixedSingle
                };

                byte[] fotoBytes = func.getFotoPerfilBytes();
                if (fotoBytes != null && fotoBytes.Length > 0)
                {
                    using (var ms = new System.IO.MemoryStream(fotoBytes))
                    {
                        picFuncionario.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picFuncionario.Image = Properties.Resources.icon_perfil; // imagem padrão
                }

                funcPanel.Controls.Add(picFuncionario);

                Label lblNome = new Label
                {
                    Text = func.getNome(),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Left = picFuncionario.Right + 15,
                    Top = 15,
                    AutoSize = true
                };
                funcPanel.Controls.Add(lblNome);

                Label lblCargo = new Label
                {
                    Text = func.getCargo(),
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Left = picFuncionario.Right + 15,
                    Top = lblNome.Bottom + 5,
                    AutoSize = true
                };
                funcPanel.Controls.Add(lblCargo);

                Label lblPontos = new Label
                {
                    Text = $"Pontos: {pontos}",
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Left = picFuncionario.Right + 15,
                    Top = lblCargo.Bottom + 5,
                    AutoSize = true
                };
                funcPanel.Controls.Add(lblPontos);

                panelDadosFunc.Controls.Add(funcPanel);
                posY += funcPanel.Height + 10; // Espaçamento entre painéis
            }
        }

        private empresaCadFuncionario BuscarFuncionarioPorEmail(string email)
        {
            empresaCadFuncionario func = new empresaCadFuncionario();
            string query = "SELECT * FROM Funcionarios WHERE Email = @Email LIMIT 1";
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;database=Dev4Tech;uid=root;pwd=;"))
            {
                conn.Open();
                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        func.setFuncionarioId(reader["FuncionarioId"].ToString());
                        func.setNome(reader["Nome"].ToString());
                        func.setCargo(reader["Cargo"].ToString());

                        if (!reader.IsDBNull(reader.GetOrdinal("foto_perfil")))
                        {
                            byte[] fotoBytes = (byte[])reader["foto_perfil"];
                            func.setFotoPerfilBytes(fotoBytes);
                        }
                    }
                    else
                    {
                        func = null;
                    }
                }
            }
            return func;
        }

        private void btnAddMembro_Click(object sender, EventArgs e)
        {
            string emailSelecionado = cbmEmailMembro.Text.Trim();
            if (!string.IsNullOrEmpty(emailSelecionado) && !membrosSelecionados.Contains(emailSelecionado))
            {
                membrosSelecionados.Add(emailSelecionado);
                MessageBox.Show($"Membro {emailSelecionado} adicionado.");
            }
            else
            {
                MessageBox.Show("Selecione um email válido que ainda não foi adicionado.");
            }
        }

        private void btnCriarEquipe_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeEquipe = txtNomeEquipe.Text.Trim();
                string categoria = cmbCategoriaEquipe.Text.Trim();
                if (string.IsNullOrEmpty(nomeEquipe))
                {
                    MessageBox.Show("Informe o nome da equipe.");
                    return;
                }
                if (string.IsNullOrEmpty(categoria))
                {
                    MessageBox.Show("Informe a categoria da equipe.");
                    return;
                }
                if (membrosSelecionados.Count == 0)
                {
                    MessageBox.Show("Adicione pelo menos um membro (email) para a equipe.");
                    return;
                }
                equipe.setNomeEquipe(nomeEquipe);
                equipe.setCategoria(categoria);
                int idEquipe = equipe.InserirEquipeRetornandoId();
                foreach (string email in membrosSelecionados)
                {
                    equipe.InserirMembroEquipe(idEquipe, email);
                }
                MessageBox.Show("Equipe cadastrada com sucesso!");
                LimparFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar equipe: " + ex.Message);
            }
        }

        private void LimparFormulario()
        {
            txtNomeEquipe.Clear();
            cmbCategoriaEquipe.Text = "";
            cbmEmailMembro.Text = "";
            membrosSelecionados.Clear();
            funcionariosSelecionados.Clear();
            panelDadosFunc.Controls.Clear();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            var funcionarioSessao = Sessao.FuncionarioLogado;
            var adminSessao = Sessao.AdminLogado;

            if (funcionarioSessao != null)
            {
                Configuracoes config = new Configuracoes(funcionarioSessao);
                config.Show();
                this.Hide();
            }
            else if (adminSessao != null)
            {
                Configuracoes config = new Configuracoes(adminSessao);
                config.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.");
            }
        }

        private void btnRanking_Click_1(object sender, EventArgs e)
        {
            Ranking_Equipes rank = new Ranking_Equipes();
            rank.Show();
            this.Hide();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            Planejamento t_pendentes = new Planejamento();
            t_pendentes.Show();
            this.Hide();
        }

        private void btnEquipes_Click_1(object sender, EventArgs e)
        {
            PesquisaEquipes p_equipes = new PesquisaEquipes();
            p_equipes.Show();
            this.Hide();
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;
            if (funcionario != null)
            {
                Home h = new Home();
                h.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                HomeAdm t_equipeAdmin = new HomeAdm();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            // Limpa a sessão antes de voltar para a tela inicial
            Sessao.FuncionarioLogado = null;
            Sessao.AdminLogado = null;

            Form1 t_incial = new Form1();
            t_incial.Show();
            this.Hide();
        }

        private void panelDadosFunc_Paint(object sender, PaintEventArgs e)
        {
        }

        private void AdicionarEquipes_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AvaliaçãoTarefaAdmin t_pendentes = new AvaliaçãoTarefaAdmin();
            t_pendentes.Show();
            this.Hide();
        }
    }
}