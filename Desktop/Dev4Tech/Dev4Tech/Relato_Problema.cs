using System;
using System.Windows.Forms;

namespace Dev4Tech
{
    public partial class Relato_Problema : Form
    {
        private int idTarefa;
        private int idEquipe;

        // Construtor que recebe os parâmetros necessários
        public Relato_Problema(int idTarefa, int idEquipe)
        {
            InitializeComponent();
            this.idTarefa = idTarefa;
            this.idEquipe = idEquipe;
        }

        private void txtDescriçãoProblema_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescriçãoProblema.Text.Trim();

            if (string.IsNullOrEmpty(descricao))
            {
                MessageBox.Show("Por favor, escreva a descrição do problema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnvioProblema relato = new EnvioProblema();
            try
            {
                relato.InserirRelato(idTarefa, idEquipe, descricao);
                MessageBox.Show("Problema enviado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar problema: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Tela_Tarefa Tt = new Tela_Tarefa(idEquipe);
            Tt.CarregarDetalhesTarefa(idTarefa);
            Tt.Show();
            this.Hide();

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Tela_Tarefa Tt = new Tela_Tarefa(idEquipe);
            Tt.CarregarDetalhesTarefa(idTarefa);
            Tt.Show();
            this.Hide();
        }
    }
}
