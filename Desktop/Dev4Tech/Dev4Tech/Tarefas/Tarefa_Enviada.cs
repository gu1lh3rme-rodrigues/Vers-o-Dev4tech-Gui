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
    public partial class Tarefa_Enviada : Form
    {
        public Tarefa_Enviada()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home t_Home = new Home();
            t_Home.Show();
            this.Hide();
        }

        private void btnEquipes_Click(object sender, EventArgs e)
        {
            Equipes_Estatisticas t_Equipes = new Equipes_Estatisticas();
            t_Equipes.Show();
            this.Hide();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            Ranking_Equipes t_Ranking = new Ranking_Equipes();
            t_Ranking.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
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

        private void btnOk_Click(object sender, EventArgs e) { }
    }
}
