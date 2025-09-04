using System;
using System.Windows.Forms;
using System.Drawing; // Adicionado para FontStyle.Bold e manipulação de imagens
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
    public partial class Configuracoes : Form
    {
        private empresaCadFuncionario funcionario;
        private empresaCadAdmin admin;

        // Construtor para funcionário
        public Configuracoes(empresaCadFuncionario func)
        {
            InitializeComponent();
            funcionario = func;
            admin = null; // Garante que admin é nulo
            PreencherCamposFuncionario();

            this.Load += Perfil_Load; // Adiciona evento Load para carregar foto
            IconFuncionario.SizeMode = PictureBoxSizeMode.StretchImage; // Define modo stretch no PictureBox
        }

        // Construtor para administrador
        public Configuracoes(empresaCadAdmin adm)
        {
            InitializeComponent();
            admin = adm;
            funcionario = null; // Garante que funcionario é nulo
            PreencherCamposAdmin();

            this.Load += Perfil_Load; // Adiciona evento Load para carregar foto
            IconFuncionario.SizeMode = PictureBoxSizeMode.StretchImage; // Define modo stretch no PictureBox
        }


        private void PreencherCamposFuncionario()
        {
            lblNomeFunc.Text = funcionario.getNome();
            lblCargo.Text = funcionario.getNome();
            txtNome.Text = funcionario.getNome(); // Onde o nome do funcionário será exibido
            lblCargo.Text = funcionario.getCargo();
            txtCPF.Text = funcionario.getCPF();
            txtDataNascFunc.Text = funcionario.getDataNascimento().ToString("dd/MM/yyyy");
            txtTelefone.Text = funcionario.getTelefone();
            txtEmail.Text = funcionario.getEmail();
            textBox1.Text = $"{funcionario.getEndereco()}, {funcionario.getNumero()}";

            // Obter e mostrar a pontuação atual do funcionário
            pontuacaoUsuarios ptFunc = new pontuacaoUsuarios(); // Certifique-se que o namespace está correto para pontuacaoUsuarios
            int idFunc = int.Parse(funcionario.getFuncionarioId());
            int pontos = ptFunc.ObterPontos(idFunc);
            lblPontos.Text = $"{pontos}";
        }

        private void PreencherCamposAdmin()
        {
            lblNomeFunc.Text = admin.getNome();
            lblCargo.Text = admin.getNome();
            txtNome.Text = admin.getNome(); // Onde o nome do administrador será exibido
            lblCargo.Text = admin.getCargo();
            txtCPF.Text = admin.getCPF();
            txtDataNascFunc.Text = admin.getDataNascimento().ToString("dd/MM/yyyy");
            txtTelefone.Text = admin.getTelefone();
            txtEmail.Text = admin.getEmail();
            textBox1.Text = $"{admin.getEndereco()}, {admin.getNum()}";

            // Para administrador, pode exibir um texto diferente ou 0 pontos
            lblPontos.Text = "Administrador"; // Ou "0" ou "N/A"
        }

        // Os demais métodos e eventos permanecem os mesmos, sem alterações
        private void label8_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e)
        {
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                Home h = new Home();
                h.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                // Se for administrador, abre a tela de adicionar tarefa para admin (exemplo)
                HomeAdm t_equipeAdmin = new HomeAdm();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void txtNome_TextChanged(object sender, EventArgs e) { }

        // Corrigido para verificar FuncionarioLogado e AdminLogado
        private void btnConfigurações_Click(object sender, EventArgs e)
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

        private void btnEquipes_Click(object sender, EventArgs e)
        {
            PesquisaEquipes p_equipe = new PesquisaEquipes();
            p_equipe.Show();
            this.Hide();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            var funcionarioSessao = Sessao.FuncionarioLogado;
            var adminSessao = Sessao.AdminLogado;

            if (funcionarioSessao != null)
            {
                Home h = new Home();
                h.Show();
                this.Hide();
            }
            else if (adminSessao != null)
            {
                // Se for administrador, abre a tela de adicionar tarefa para admin (exemplo)
                HomeAdm t_equipeAdmin = new HomeAdm();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Limpa a sessão antes de voltar para a tela inicial
            Sessao.FuncionarioLogado = null;
            Sessao.AdminLogado = null;

            Form1 t_incial = new Form1();
            t_incial.Show();
            this.Hide();
        }
        private void btnRanking_Click(object sender, EventArgs e)
        {
            Ranking_Equipes rank_equipe = new Ranking_Equipes();
            rank_equipe.Show();
            this.Hide();
        }
        private void picPerfilMembro_Click(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtDataNascFunc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void txtTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void panelEquipes_Paint(object sender, PaintEventArgs e) { }

        private void Configuracoes_Load(object sender, EventArgs e) { } // Mantido se associado no Designer
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Tarefas_Pendentes t_pendente = new Tarefas_Pendentes();
            t_pendente.Show();
            this.Hide();
        }

        private void AtualizarFotoNoBanco(byte[] fotoBytes)
        {
            // Adaptar para salvar na tabela correta conforme usuário atual (func/admin)
            if (funcionario != null)
            {
                int idFuncionario = int.Parse(funcionario.getFuncionarioId());
                using (var conn = new MySqlConnection("server=localhost;database=Dev4Tech;uid=root;pwd="))
                {
                    conn.Open();
                    string query = "UPDATE Funcionarios SET foto_perfil = @foto WHERE FuncionarioId = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@foto", fotoBytes);
                        cmd.Parameters.AddWithValue("@id", idFuncionario);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else if (admin != null)
            {
                int idAdmin = int.Parse(admin.getAdminId());
                using (var conn = new MySqlConnection("server=localhost;database=Dev4Tech;uid=root;pwd="))
                {
                    conn.Open();
                    string query = "UPDATE Administradores SET foto_perfil = @foto WHERE AdminId = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@foto", fotoBytes);
                        cmd.Parameters.AddWithValue("@id", idAdmin);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnTrocarFotoPerfil_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecione a nova foto do perfil";
            ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string caminhoImagem = ofd.FileName;
                IconFuncionario.SizeMode = PictureBoxSizeMode.StretchImage; // Garante que seja Stretch
                IconFuncionario.Image = new Bitmap(caminhoImagem);

                byte[] fotoBytes = System.IO.File.ReadAllBytes(caminhoImagem);

                // Salvar no banco a nova foto
                AtualizarFotoNoBanco(fotoBytes);

                MessageBox.Show("Foto de perfil atualizada!");
            }
        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            if (funcionario != null)
            {
                int idFuncionario = int.Parse(funcionario.getFuncionarioId());
                CarregarFotoDoBanco(idFuncionario, true);
            }
            else if (admin != null)
            {
                int idAdmin = int.Parse(admin.getAdminId());
                CarregarFotoDoBanco(idAdmin, false);
            }
            else
            {
                IconFuncionario.SizeMode = PictureBoxSizeMode.StretchImage;
                IconFuncionario.Image = Properties.Resources.icon_perfil;
            }
        }

        private void CarregarFotoDoBanco(int id, bool isFuncionario)
        {
            using (var conn = new MySqlConnection("server=localhost;database=Dev4Tech;uid=root;pwd="))
            {
                conn.Open();
                string query = isFuncionario
                    ? "SELECT foto_perfil FROM Funcionarios WHERE FuncionarioId = @id"
                    : "SELECT foto_perfil FROM Administradores WHERE AdminId = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        IconFuncionario.SizeMode = PictureBoxSizeMode.StretchImage;
                        if (rdr.Read())
                        {
                            if (!rdr.IsDBNull(0))
                            {
                                byte[] fotoBytes = (byte[])rdr["foto_perfil"];
                                using (var ms = new System.IO.MemoryStream(fotoBytes))
                                {
                                    IconFuncionario.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                IconFuncionario.Image = Properties.Resources.icon_perfil; // imagem padrão
                            }
                        }
                        else
                        {
                            IconFuncionario.Image = Properties.Resources.icon_perfil;
                        }
                    }
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                Tarefas_Completadas h = new Tarefas_Completadas();
                h.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                // Se for administrador, abre a tela de adicionar tarefa para admin (exemplo)
                AvaliaçãoTarefaAdmin t_equipeAdmin = new AvaliaçãoTarefaAdmin();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
