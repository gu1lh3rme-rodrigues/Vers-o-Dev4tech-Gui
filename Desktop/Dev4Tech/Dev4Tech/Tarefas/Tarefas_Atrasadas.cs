using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Dev4Tech
{
    public partial class Tarefas_Atrasadas : Form
    {
        public Tarefas_Atrasadas()
        {
            InitializeComponent();
            CarregarTarefasAtrasadas(); // Carrega as tarefas atrasadas ao abrir a tela
        }

        private void CarregarTarefasAtrasadas()
        {
            int idEquipe = 1; // Ajuste para o id da equipe correta no seu contexto

            panelTarefas.Controls.Clear();

            EntregaTarefa entregaTarefa = new EntregaTarefa();
            DataTable dt = entregaTarefa.BuscarTarefasAtrasadasPorEquipe(idEquipe);

            int margemTopo = 20;
            int margemEsquerda = 20;
            int espacamentoVertical = 20;
            int espacamentoHorizontal = 20;
            int larguraPanel = 350;
            int alturaPanel = 100;
            int colunas = 2;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                string dificuldade = row.Table.Columns.Contains("dificuldade") && row["dificuldade"] != DBNull.Value
                    ? row["dificuldade"].ToString()
                    : "Desconhecida";

                Panel tarefaPanel = new Panel
                {
                    Width = larguraPanel,
                    Height = alturaPanel,
                    BackColor = Color.White, // Fundo branco do painel
                    BorderStyle = BorderStyle.FixedSingle,
                    Left = margemEsquerda + (i % colunas) * (larguraPanel + espacamentoHorizontal),
                    Top = margemTopo + (i / colunas) * (alturaPanel + espacamentoVertical),
                    Cursor = Cursors.Hand,
                    Tag = row["id_tarefa"]
                };

                tarefaPanel.Click += (s, e) =>
                {
                    int idTarefa = Convert.ToInt32(((Panel)s).Tag);
                    Tela_Tarefa telaTarefa = new Tela_Tarefa(idEquipe);
                    telaTarefa.CarregarDetalhesTarefa(idTarefa);
                    telaTarefa.Show();
                    this.Hide();
                };

                PictureBox pic = new PictureBox
                {
                    Image = Properties.Resources.icon_EquipLogo,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 40,
                    Height = 40,
                    Left = 10,
                    Top = 10
                };
                tarefaPanel.Controls.Add(pic);

                Label lblNome = new Label
                {
                    Text = row["nomeTarefa"].ToString(),
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Left = 60,
                    Top = 5,
                    AutoSize = true
                };
                tarefaPanel.Controls.Add(lblNome);

                Label lblSub = new Label
                {
                    Text = row["nome_equipe"].ToString(),
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Left = 60,
                    Top = 30,
                    AutoSize = true
                };
                tarefaPanel.Controls.Add(lblSub);

                Label lblCategoria = new Label
                {
                    Text = row["nome_categoria"].ToString(),
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    Left = 60,
                    Top = 50,
                    AutoSize = true
                };
                tarefaPanel.Controls.Add(lblCategoria);

                Label lblConclusao = new Label
                {
                    Text = "Prazo expirado em " + Convert.ToDateTime(row["data_entrega"]).ToString("dd/MM/yy"),
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    Left = 60,
                    Top = 70,
                    AutoSize = true,
                    ForeColor = Color.Red
                };
                tarefaPanel.Controls.Add(lblConclusao);

                Label lblStatus = new Label
                {
                    Text = "Atrasado",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.Red,
                    Left = larguraPanel - 90,
                    Top = 10,
                    AutoSize = true
                };
                tarefaPanel.Controls.Add(lblStatus);

                Label lblDificuldade = new Label
                {
                    Text = "Dificuldade: " + dificuldade,
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    ForeColor = Color.Black,
                    Left = larguraPanel - 90,
                    Top = 30,
                    AutoSize = true
                };

                // Define a cor de fundo da label conforme a dificuldade
                switch (dificuldade.ToLower())
                {
                    case "difícil":
                        lblDificuldade.BackColor = Color.LightCoral; // vermelho claro
                        break;
                    case "média":
                    case "mediana":
                        lblDificuldade.BackColor = Color.LightGoldenrodYellow; // amarelo claro
                        break;
                    case "fácil":
                        lblDificuldade.BackColor = Color.LightGreen; // verde claro
                        break;
                    default:
                        lblDificuldade.BackColor = Color.Transparent;
                        break;
                }

                tarefaPanel.Controls.Add(lblDificuldade);

                panelTarefas.Controls.Add(tarefaPanel);
            }
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

        private void btnEquipe_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                // Se for funcionário, abre a tela de adicionar tarefa (exemplo)
                PesquisaEquipes t_equipe = new PesquisaEquipes();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                // Se for administrador, abre a tela de adicionar tarefa para admin (exemplo)
                PesquisaEquipes t_equipeAdmin = new PesquisaEquipes();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Limpa a sessão antes de voltar para a tela inicial
            Sessao.FuncionarioLogado = null;
            Sessao.AdminLogado = null;

            Form1 t_incial = new Form1();
            t_incial.Show();
            this.Hide();
        }

        private void lblGeral_Click(object sender, EventArgs e)
        {

            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                // Se for funcionário, abre a tela de adicionar tarefa (exemplo)
                Chat_geral_equipes t_equipe = new Chat_geral_equipes();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                // Se for administrador, abre a tela de adicionar tarefa para admin (exemplo)
                Chat_geral_equipes t_equipeAdmin = new Chat_geral_equipes();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblTarefas_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                // Se for funcionário, abre a tela de adicionar tarefa (exemplo)
                Tarefas_Pendentes t_equipe = new Tarefas_Pendentes();
                t_equipe.Show();
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

        private void lblRanking_Click(object sender, EventArgs e)
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

        private void lblMembros_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                Integrantes_Equipe h = new Integrantes_Equipe();
                h.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                // Se for administrador, abre a tela de adicionar tarefa para admin (exemplo)
                Integrantes_Equipe t_equipeAdmin = new Integrantes_Equipe();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPendentes_Click(object sender, EventArgs e)
        {
            Tarefas_Pendentes trf_Pendentes = new Tarefas_Pendentes();
            trf_Pendentes.Show();
            this.Hide();
        }

        private void btnEmAtraso_Click(object sender, EventArgs e)
        {
            Tarefas_Atrasadas trf_Atrasadas = new Tarefas_Atrasadas();
            trf_Atrasadas.Show();
            this.Hide();
        }

        private void btnCompletadas_Click(object sender, EventArgs e)
        {
            Tarefas_Completadas trf_Completas = new Tarefas_Completadas();
            trf_Completas.Show();
            this.Hide();
        }

        private void Tarefa1_Enter(object sender, EventArgs e)
        {
        }

        private void txtPesquisaTarefa_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPlanejamento_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                // Se for funcionário, abre a tela de adicionar tarefa (exemplo)
                Planejamento t_equipe = new Planejamento();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                // Se for administrador, abre a tela de adicionar tarefa para admin (exemplo)
                Planejamento t_equipeAdmin = new Planejamento();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;

            if (funcionario != null)
            {
                Configuracoes config = new Configuracoes(funcionario);
                config.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum funcionário logado.");
            }
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                // Se for funcionário, abre a tela de adicionar tarefa (exemplo)
                Planejamento t_equipe = new Planejamento();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                // Se for administrador, abre a tela de adicionar tarefa para admin (exemplo)
                AdicionarTarefa t_equipeAdmin = new AdicionarTarefa();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                // Se for funcionário, abre a tela de adicionar tarefa (exemplo)
                Home t_equipe = new Home();
                t_equipe.Show();
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
