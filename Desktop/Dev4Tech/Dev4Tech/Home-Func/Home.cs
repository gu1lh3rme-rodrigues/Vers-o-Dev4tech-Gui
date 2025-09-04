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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnEquipes_Click(object sender, EventArgs e)
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
            Integrantes_Equipe t_integrantes = new Integrantes_Equipe();
            t_integrantes.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void btnEntrarEquipes_Click(object sender, EventArgs e) {
            PesquisaEquipes p = new PesquisaEquipes();
            p.Show();
            this.Hide();

        }
        private void btnEntrarRanking_Click(object sender, EventArgs e) {
            Ranking_Equipes rank = new Ranking_Equipes();
            rank.Show();
            this.Hide();
        }
        private void btnHome_Click(object sender, EventArgs e) {
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
        private void Home_Load(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void btnEntrarTarefas_Click(object sender, EventArgs e) {
            Tarefas_Pendentes tp = new Tarefas_Pendentes();
            tp.Show();
            this.Hide();
        }
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

        private void btnCalendar_Click(object sender, EventArgs e)
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
                AdicionarTarefa t_equipeAdmin = new AdicionarTarefa();
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
