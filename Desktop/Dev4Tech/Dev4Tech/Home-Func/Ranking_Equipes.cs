using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev4Tech
{
    public partial class Ranking_Equipes : Form
    {
        public Ranking_Equipes()
        {           
            InitializeComponent();
        
            this.Load += Ranking_Equipes_Load; // Registra evento de load para carregar ranking

        }

        private void Ranking_Equipes_Load(object sender, EventArgs e)
        {
            // Chama método para carregar o ranking no painel ao abrir a tela
            CarregarRankingEquipes();
        }

        // Criar ToolTip global para ser reutilizado
        private ToolTip toolTipMembros = new ToolTip();

        // *** NOVO MÉTODO PARA CARREGAR O RANKING DAS EQUIPES ***
        private void CarregarRankingEquipes()
        {
            panelRankingEquipes.Controls.Clear();

            // Busca todas as equipes com a soma da pontuação dos membros
            DataTable dtEquipes = BuscarEquipesComPontuacao();

            int top = 10; // posição inicial vertical para o primeiro painel
            int rank = 1;
            foreach (DataRow row in dtEquipes.Rows)
            {
                int idEquipe = (int)row["id_equipe"];
                string nomeEquipe = row["nome_equipe"].ToString();
                int pontosEquipe = row["pontos"] != DBNull.Value ? Convert.ToInt32(row["pontos"]) : 0;

                // Buscar nomes reais dos membros da equipe (máximo 3 membros)
                List<string> nomesMembros = BuscarNomesMembrosEquipe(idEquipe);

                // Ajusta a altura do painel conforme a quantidade de membros (avatar 34px de altura + 10px padding)
                int alturaPainel = 90; // altura base pode ser mantida (ajuste se preferir)
                                       // Se quiser variar alturas conforme número de membros, ajuste aqui. Exemplo:
                                       // int alturaPainel = 60 + (nomesMembros.Count * 40); 

                Panel equipePanel = new Panel
                {
                    Width = panelRankingEquipes.Width - 40,
                    Height = alturaPainel,
                    BackColor = Color.White,
                    Top = top,
                    Left = 10,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = idEquipe
                };

                // Ícone do ranking para top 3
                PictureBox picIcone = new PictureBox
                {
                    Width = 44,
                    Height = 44,
                    Left = 10,
                    Top = 20,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = null
                };
                if (rank == 1)
                    picIcone.Image = Properties.Resources.icon_ranking_1;
                else if (rank == 2)
                    picIcone.Image = Properties.Resources.icon_ranking_2;
                else if (rank == 3)
                    picIcone.Image = Properties.Resources.icon_ranking_3;
                equipePanel.Controls.Add(picIcone);

                Label lblRank = new Label
                {
                    Text = $"#{rank}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Left = picIcone.Right + 10,
                    Top = 18,
                    ForeColor = Color.Black,
                    AutoSize = true
                };
                equipePanel.Controls.Add(lblRank);

                Label lblNomeEquipe = new Label
                {
                    Text = nomeEquipe,
                    Font = new Font("Segoe UI", 13, FontStyle.Bold),
                    Left = picIcone.Right + 60,
                    Top = 18,
                    AutoSize = true
                };
                equipePanel.Controls.Add(lblNomeEquipe);

                Label lblPontos = new Label
                {
                    Text = "Pontuação: " + pontosEquipe,
                    Font = new Font("Segoe UI", 11, FontStyle.Regular),
                    ForeColor = Color.DodgerBlue,
                    Left = picIcone.Right + 60,
                    Top = lblNomeEquipe.Bottom + 5,
                    AutoSize = true
                };
                equipePanel.Controls.Add(lblPontos);

                // Posiciona os avatares alinhados à direita, com base na quantidade de membros
                int numMembrosParaMostrar = Math.Min(nomesMembros.Count, 3);
                int leftFoto = equipePanel.Width - 40 - 35 * numMembrosParaMostrar;

                ToolTip toolTipMembros = new ToolTip();

                for (int i = 0; i < numMembrosParaMostrar; i++)
                {
                    PictureBox picMembro = new PictureBox
                    {
                        Image = Properties.Resources.icon_perfil,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 34,
                        Height = 34,
                        Left = leftFoto + (i * 35),
                        Top = 25,
                        BorderStyle = BorderStyle.FixedSingle,
                        Cursor = Cursors.Hand
                    };

                    toolTipMembros.SetToolTip(picMembro, nomesMembros[i]);

                    equipePanel.Controls.Add(picMembro);
                }



                panelRankingEquipes.Controls.Add(equipePanel);

                top += equipePanel.Height + 10; // atualiza posição vertical para próximo
                rank++;


            }
        }


        // *** NOVO MÉTODO PARA BUSCAR NOMES DOS MEMBROS DA EQUIPE ***
        private List<string> BuscarNomesMembrosEquipe(int idEquipe)
        {
            List<string> nomes = new List<string>();

            string query = @"
                SELECT f.Nome
                FROM Equipes_Membros em
                INNER JOIN Funcionarios f ON f.FuncionarioId = em.FuncionarioId
                WHERE em.id_equipe = @idEquipe
                ORDER BY f.Nome
            ";

            using (var conn = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;database=Dev4Tech;uid=root;pwd=;"))
            {
                conn.Open();

                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idEquipe", idEquipe);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nomes.Add(reader["Nome"].ToString());
                    }
                }
            }

            return nomes;
        }

        // *** MÉTODO JÁ EXISTENTE PARA BUSCAR EQUIPES COM PONTUAÇÃO ***
        private DataTable BuscarEquipesComPontuacao()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT e.id_equipe, e.nome_equipe, 
                       IFNULL(SUM(pf.pontos),0) AS pontos
                FROM Equipes e
                LEFT JOIN Equipes_Membros em ON em.id_equipe = e.id_equipe
                LEFT JOIN PontuacaoFuncionario pf ON pf.id_funcionario = em.FuncionarioId
                GROUP BY e.id_equipe, e.nome_equipe
                ORDER BY pontos DESC, e.data_criacao ASC
            ";

            using (var conn = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;database=Dev4Tech;uid=root;pwd=;"))
            {
                conn.Open();
                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // -- MANTÉM TODO SEU CÓDIGO ORIGINAL DE NAVEGAÇÃO E EVENTOS -- (não alterado)
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
                HomeAdm t_equipeAdmin = new HomeAdm();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEquipes_Click(object sender, EventArgs e)
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

        private void btnRanking_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                Ranking_Equipes t_equipe = new Ranking_Equipes();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
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
            Sessao.FuncionarioLogado = null;
            Sessao.AdminLogado = null;

            Form1 t_incial = new Form1();
            t_incial.Show();
            this.Hide();
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        {
            Tarefas_Pendentes t_Tarefas = new Tarefas_Pendentes();
            t_Tarefas.Show();
            this.Hide();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            Chat_geral_equipes t_Chat = new Chat_geral_equipes();
            t_Chat.Show();
            this.Hide();
        }

        private void btnIntegrantes_Click(object sender, EventArgs e)
        {
            Integrantes_Equipe t_Integrantes = new Integrantes_Equipe();
            t_Integrantes.Show();
            this.Hide();
        }

        private void lblPlanejamento_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                Planejamento t_equipe = new Planejamento();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                Planejamento t_equipeAdmin = new Planejamento();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label40_Click(object sender, EventArgs e)
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
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
        private void btnEstatisticas_Click(object sender, EventArgs e)
        {
        }

        private void lblGeral_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                Chat_geral_equipes t_equipe = new Chat_geral_equipes();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                Chat_geral_equipes t_equipeAdmin = new Chat_geral_equipes();
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
                Ranking_Equipes t_equipe = new Ranking_Equipes();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                Ranking_Equipes t_equipeAdmin = new Ranking_Equipes();
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
                Tarefas_Pendentes t_equipe = new Tarefas_Pendentes();
                t_equipe.Show();
                this.Hide();
            }
            else if (admin != null)
            {
                AvaliaçãoTarefaAdmin t_equipeAdmin = new AvaliaçãoTarefaAdmin();
                t_equipeAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nenhum usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Equipes_Estatisticas t_integrantes = new Equipes_Estatisticas();
            t_integrantes.Show();
            t_integrantes.CarregarGrafico(); // Carrega o gráfico ao abrir a tela
            this.Hide();



        }

        private void pictureBox20_Click(object sender, EventArgs e)
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

        private void panelRankingEquipes_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
