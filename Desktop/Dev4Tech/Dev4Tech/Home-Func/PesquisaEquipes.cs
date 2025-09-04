using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dev4Tech
{
    public partial class PesquisaEquipes : Form
    {
        public PesquisaEquipes()
        {
            InitializeComponent();
            panelEquipes.AutoScroll = true;

            filtroEquipes.Items.Add("Todos");
            filtroEquipes.Items.Add("Desenvolvedor de software");
            filtroEquipes.Items.Add("Design");
            filtroEquipes.Items.Add("Marketing");
            filtroEquipes.SelectedIndex = 0;
        }

        private int mensagensCount = 0;
        private int margemTopo = 30;
        private int margemEsquerda = 350;
        private int espacamentoVertical = 20;
        private int alturaMensagem = 110;

        private void txtPesquisaEquipe_Click(object sender, EventArgs e)
        {
            txtPesquisaEquipe.Text = "";
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

        private void btnHome_Click(object sender, EventArgs e)
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

        private void btnRanking_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                // Se for funcionário, abre a tela de adicionar tarefa (exemplo)
                Ranking_Equipes t_equipe = new Ranking_Equipes();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                // Se for administrador, abre a tela de adicionar tarefa para admin (exemplo)
                Ranking_Equipes t_equipeAdmin = new Ranking_Equipes();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPesquisarEquipe_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPesquisaEquipe.Text))
            {
                txtPesquisaEquipe.Text = "Pesquisar Equipe";
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarEquipes(filtroEquipes.SelectedItem?.ToString());
        }

        private void CarregarEquipes(string filtroCategoria = null)
        {
            panelEquipes.Controls.Clear();
            mensagensCount = 0;

            FiltroEquipes filtro = new FiltroEquipes();
            DataTable dt = filtro.ObterEquipesComMembrosComFotos(filtroCategoria); // Método que traz fotos e ids

            var equipes = dt.AsEnumerable()
                            .GroupBy(row => new
                            {
                                id_equipe = row.Field<int>("id_equipe"),
                                nome_equipe = row.Field<string>("nome_equipe"),
                                categoria = row.Field<string>("nome_categoria"),
                                ultima_atividade = row.IsNull("ultima_atividade") ? (DateTime?)null : row.Field<DateTime>("ultima_atividade")
                            });

            foreach (var equipe in equipes)
            {
                int diasDesdeUltimaAtividade = -1;
                if (equipe.Key.ultima_atividade.HasValue)
                    diasDesdeUltimaAtividade = (DateTime.Now - equipe.Key.ultima_atividade.Value).Days;

                var membros = dt.AsEnumerable()
                .Where(r => r.Field<int>("id_equipe") == equipe.Key.id_equipe)
                .Select(r => new MembroEquipe
                {
                    IdFuncionario = r.Field<int>("FuncionarioId"),
                    Nome = r.Field<string>("nome_funcionario"),
                    FotoPerfil = r.Field<byte[]>("foto_perfil")
                })
                .ToList();


                AdicionarPainelEquipe(
                    equipe.Key.nome_equipe,
                    equipe.Key.categoria,
                    membros,
                    equipe.Key.id_equipe,
                    diasDesdeUltimaAtividade
                );
            }
        }

        private void AdicionarPainelEquipe(string nomeEquipe, string categoria, System.Collections.Generic.List<MembroEquipe> membros, int idEquipe, int diasDesdeUltimaAtividade)
        {
            int x = margemEsquerda;
            int y = margemTopo + (alturaMensagem + espacamentoVertical) * mensagensCount;

            Panel equipePanel = new Panel
            {
                Width = 350,
                Height = alturaMensagem,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Left = x,
                Top = y,
                Cursor = Cursors.Hand
            };

            equipePanel.Click += (s, e) =>
            {
                Chat_geral_equipes chatForm = new Chat_geral_equipes(idEquipe, nomeEquipe, categoria);
                chatForm.Show();
                this.Hide();
            };

            PictureBox picEquipe = new PictureBox
            {
                Image = Properties.Resources.icon_EquipLogo,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 40,
                Height = 40,
                Left = 10,
                Top = 10,
                BorderStyle = BorderStyle.FixedSingle
            };
            equipePanel.Controls.Add(picEquipe);

            Label lblNomeEquipe = new Label
            {
                Text = nomeEquipe,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Left = 60,
                Top = 5,
                AutoSize = true
            };
            equipePanel.Controls.Add(lblNomeEquipe);

            Label lblCategoria = new Label
            {
                Text = categoria,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Left = 60,
                Top = 30,
                AutoSize = true
            };
            equipePanel.Controls.Add(lblCategoria);

            string textoAtividade = diasDesdeUltimaAtividade == -1
                ? "Nunca ativo"
                : $"Ativo há {diasDesdeUltimaAtividade} dia(s)";

            Label lblAtividade = new Label
            {
                Text = textoAtividade,
                Font = new Font("Segoe UI", 8, FontStyle.Italic),
                ForeColor = diasDesdeUltimaAtividade > 7 ? Color.Red : Color.Green,
                Left = 60,
                Top = 50,
                AutoSize = true
            };
            equipePanel.Controls.Add(lblAtividade);

            Label lblColaboradores = new Label
            {
                Text = "Colaboradores",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Left = 60,
                Top = 70,
                AutoSize = true
            };
            equipePanel.Controls.Add(lblColaboradores);

            int fotoLeft = 60;
            int fotoTop = 90;
            foreach (var membro in membros)
            {
                PictureBox picMembro = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 32,
                    Height = 32,
                    Left = fotoLeft,
                    Top = fotoTop,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                    Tag = membro.IdFuncionario  // Para identificar qual funcionário representa
                };

                if (membro.FotoPerfil != null && membro.FotoPerfil.Length > 0)
                {
                    using (var ms = new System.IO.MemoryStream(membro.FotoPerfil))
                    {
                        picMembro.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picMembro.Image = Properties.Resources.icon_perfil; // Sua imagem padrão
                }

                picMembro.MouseHover += (s, e) =>
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(picMembro, membro.Nome);
                };

                equipePanel.Controls.Add(picMembro);
                fotoLeft += 38;
            }

            panelEquipes.Controls.Add(equipePanel);
            mensagensCount++;
        }

        public class MembroEquipe
        {
            public int IdFuncionario { get; set; }
            public string Nome { get; set; }
            public byte[] FotoPerfil { get; set; }
        }


        // Métodos e eventos que você já tinha (mantidos)
        private void btnEquipe_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                PesquisaEquipes t_equipe = new PesquisaEquipes();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                PesquisaEquipes t_equipeAdmin = new PesquisaEquipes();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCalendar_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                Tarefas_Pendentes t_equipe = new Tarefas_Pendentes();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                AdicionarTarefa t_equipeAdmin = new AdicionarTarefa();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtPesquisaEquipe_TextChanged(object sender, EventArgs e) { }
        private void filtroEquipes_SelectedIndexChanged(object sender, EventArgs e) { }
        private void panelEquipes_Paint(object sender, PaintEventArgs e) { }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                Configuracoes config = new Configuracoes(funcionario);
                config.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                Configuracoes config = new Configuracoes(admin);
                config.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.");
            }
        }

        private void PesquisaEquipes_Load(object sender, EventArgs e)
        {

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
