using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
    public partial class Tela_Tarefa : Form
    {
        private int idEquipeAtual = 0; // ID da equipe selecionada
        private int idTarefaExibida = 0; // ID da tarefa atualmente exibida
        private string caminhoArquivoEntrega = ""; // Caminho do arquivo para entrega

        // Construtor que recebe o ID da equipe para carregar dados específicos
        public Tela_Tarefa(int idEquipe)
        {
            InitializeComponent();
            idEquipeAtual = idEquipe;
            txtNomeEquipe.Text = BuscarNomeEquipe(idEquipeAtual);
            lblArquivoEntregaTarefa.Click += LblArquivoEntregaTarefa_Click;
            btnRelatarProblema.Click += btnRelatarProblema_Click;
        }

        // Carrega detalhes da tarefa selecionada e atualiza a interface
        public void CarregarDetalhesTarefa(int idTarefa)
        {
            EntregaTarefa entrTarefa = new EntregaTarefa();
            DataRow tarefa = entrTarefa.BuscarTarefaPorId(idTarefa);

            if (tarefa != null)
            {
                idTarefaExibida = Convert.ToInt32(tarefa["id_tarefa"]);

                // Nome da tarefa na label
                lblNomeTarefa.Text = tarefa["nomeTarefa"].ToString();

                // Categoria da equipe na label
                lblCategoriaEquipe.Text = tarefa["nome_categoria"].ToString();

                // Data de entrega formatada na label
                DateTime dataEntrega = Convert.ToDateTime(tarefa["data_entrega"]);
                lblDataEntrega.Text = dataEntrega.ToString("dd/MM/yyyy");

                lblInstrucoes.Text = tarefa["instrucoes"].ToString();

                // NOVO: Mostrar dificuldade
                if (tarefa.Table.Columns.Contains("dificuldade") && tarefa["dificuldade"] != DBNull.Value)
                {
                    lblDificuldade.Text = "Dificuldade: " + tarefa["dificuldade"].ToString();
                    lblDificuldade.Visible = true;
                }
                else
                {
                    lblDificuldade.Visible = false;
                }

                // Resto do código para arquivo e habilitar botão
                lblArquivoTarefa.Click -= LblArquivoTarefa_Click;

                if (tarefa["nome_arquivo"] != DBNull.Value && !string.IsNullOrEmpty(tarefa["nome_arquivo"].ToString()))
                {
                    lblArquivoTarefa.Text = "Arquivo: " + tarefa["nome_arquivo"].ToString();
                    lblArquivoTarefa.ForeColor = Color.Blue;
                    lblArquivoTarefa.Cursor = Cursors.Hand;
                    lblArquivoTarefa.Click += LblArquivoTarefa_Click;
                }
                else
                {
                    lblArquivoTarefa.Text = "Nenhum arquivo anexado à tarefa.";
                    lblArquivoTarefa.ForeColor = SystemColors.ControlText;
                    lblArquivoTarefa.Cursor = Cursors.Default;
                }

                btnEnviar.Enabled = true;
                LimparCamposEntrega();
            }
            else
            {
                LimparDetalhesTarefa();
            }
        }


        // Limpa os detalhes da tarefa da tela
        private void LimparDetalhesTarefa()
        {
            idTarefaExibida = 0;
            lblInstrucoes.Text = "";
            lblArquivoTarefa.Text = "";
            btnEnviar.Enabled = false;
            lblCategoriaEquipe.Text = "";
            LimparCamposEntrega();
        }

        // Evento para abrir o arquivo anexado à tarefa
        private void LblArquivoTarefa_Click(object sender, EventArgs e)
        {
            if (idTarefaExibida == 0) return;

            EntregaTarefa entrTarefa = new EntregaTarefa();
            DataRow tarefa = entrTarefa.BuscarTarefaPorId(idTarefaExibida);

            if (tarefa != null && tarefa["arquivo_blob"] != DBNull.Value)
            {
                try
                {
                    byte[] arquivo = (byte[])tarefa["arquivo_blob"];
                    string tempPath = Path.Combine(Path.GetTempPath(), tarefa["nome_arquivo"].ToString());
                    File.WriteAllBytes(tempPath, arquivo);
                    System.Diagnostics.Process.Start(tempPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao abrir o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Busca o nome da equipe pelo ID no banco
        private string BuscarNomeEquipe(int idEquipe)
        {
            string nome = "";
            using (var conn = new MySqlConnection("server=localhost;database=Dev4Tech;uid=root;pwd=;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT nome_equipe FROM Equipes WHERE id_equipe = @id", conn);
                cmd.Parameters.AddWithValue("@id", idEquipe);
                var result = cmd.ExecuteScalar();
                nome = result != null ? result.ToString() : "";
            }
            return nome;
        }

        // Evento para anexar arquivo de entrega
        private void LblArquivoEntregaTarefa_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Todos os arquivos (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                caminhoArquivoEntrega = ofd.FileName;
                lblArquivoEntregaTarefa.Text = Path.GetFileName(caminhoArquivoEntrega);
                lblArquivoEntregaTarefa.ForeColor = Color.Blue;
            }
        }


        private void btnEnviar_Click(object sender, EventArgs e) // Certifique-se que o botão no Designer está linkado a este método.
        {
            if (idTarefaExibida == 0)
            {
                MessageBox.Show("Não há tarefa para ser entregue.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescrição.Text))
            {
                MessageBox.Show("Por favor, descreva sua entrega.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] arquivoBytes = null;
            string nomeArquivo = null;

            if (!string.IsNullOrEmpty(caminhoArquivoEntrega))
            {
                try
                {
                    arquivoBytes = File.ReadAllBytes(caminhoArquivoEntrega);
                    nomeArquivo = Path.GetFileName(caminhoArquivoEntrega);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao ler o arquivo de entrega: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            EntregaTarefa entrTarefa = new EntregaTarefa();
            try
            {
                // Registra a entrega
                int idFuncionarioAtual = Sessao.FuncionarioLogado != null ? int.Parse(Sessao.FuncionarioLogado.getFuncionarioId()) : 0;

                // Verifique se idFuncionarioAtual é válido
                if (idFuncionarioAtual == 0)
                {
                    MessageBox.Show("Funcionário não está logado corretamente.");
                    return;
                }

                // Chamada correta para registrar entrega
                entrTarefa.RegistrarEntrega(idTarefaExibida, idEquipeAtual, idFuncionarioAtual, txtDescrição.Text, nomeArquivo, arquivoBytes);

                // Busca a dificuldade da tarefa
                string dificuldade = "";
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;database=Dev4Tech;uid=root;pwd=;"))
                {
                    conn.Open();
                    // Usando "t." para evitar ambiguidade se houver outra tabela com coluna "dificuldade"
                    var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT t.dificuldade FROM Tarefas t WHERE t.id_tarefa = @idTarefa", conn);
                    cmd.Parameters.AddWithValue("@idTarefa", idTarefaExibida);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        dificuldade = result.ToString();
                }

                // Define os pontos conforme a dificuldade
                int pontos = 0;
                switch (dificuldade.ToLower())
                {
                    case "fácil":
                        pontos = 2;
                        break;
                    case "média": // "Mediana" foi padronizado para "Média" na classe AddTarefas
                        pontos = 4;
                        break;
                    case "difícil":
                        pontos = 6;
                        break;
                }

                // Adiciona os pontos ao funcionário logado
                if (pontos > 0 && Sessao.FuncionarioLogado != null)
                {
                    pontuacaoUsuarios ptFunc = new pontuacaoUsuarios();
                    int idFunc = int.Parse(Sessao.FuncionarioLogado.getFuncionarioId());
                    ptFunc.AdicionarPontos(idFunc, pontos);
                }

                MessageBox.Show("Entrega registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCamposEntrega();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar a entrega: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Limpa campos após entrega
        private void LimparCamposEntrega()
        {
            txtDescrição.Clear();
            lblArquivoEntregaTarefa.Text = "Clique para anexar arquivo";
            lblArquivoEntregaTarefa.ForeColor = Color.Gray;
            caminhoArquivoEntrega = "";
        }

        // Eventos e métodos adicionais (mantidos)
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

        private void btnEquipes_Click(object sender, EventArgs e)
        {
            PesquisaEquipes p_equipe = new PesquisaEquipes();
            p_equipe.Show();
            this.Hide();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            Ranking_Equipes rank_equipe = new Ranking_Equipes();
            rank_equipe.Show();
            this.Hide();
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

        private void lblTarefas_Click(object sender, EventArgs e)
        {
            Tarefas_Pendentes trf_pendente = new Tarefas_Pendentes();
            trf_pendente.Show();
            this.Hide();
        }

        private void lblGeral_Click(object sender, EventArgs e)
        {
            Chat_geral_equipes chatEquipe = new Chat_geral_equipes();
            chatEquipe.Show();
            this.Hide();
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

        private void lblRanking_Click(object sender, EventArgs e) { }
        private void btnRelatarProblema_Click(object sender, EventArgs e)
        {
            if (idTarefaExibida == 0 || idEquipeAtual == 0)
            {
                MessageBox.Show("Selecione uma tarefa válida para relatar um problema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Relato_Problema relatoForm = new Relato_Problema(idTarefaExibida, idEquipeAtual);
            relatoForm.Show();
            this.Hide();
        }


        private void txtDescrição_TextChanged(object sender, EventArgs e) { }
        private void btnConfigurações_Click(object sender, EventArgs e)
        {
            // Alterado para suportar Funcionário ou Admin logado
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
        private void lblPlanejamento_Click(object sender, EventArgs e) { }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Tarefas_Pendentes t_pendente = new Tarefas_Pendentes();
            t_pendente.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var funcionario = Sessao.FuncionarioLogado;
            var admin = Sessao.AdminLogado;

            if (funcionario != null)
            {
                Tarefas_Pendentes h = new Tarefas_Pendentes();
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

        private void pictureBox2_Click(object sender, EventArgs e){ }

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
