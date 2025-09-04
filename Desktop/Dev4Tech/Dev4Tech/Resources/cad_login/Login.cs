using System;
using System.Windows.Forms;

namespace Dev4Tech
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblCadastrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Supondo que "adminLogado" é o objeto que você tem após login
            Sessao.AdminLogado.getAdminId();
            Sessao.AdminLogado.getIdEmpresa();

            cadastro_funcionário cadastroFunc = new cadastro_funcionário(
    Sessao.AdminLogado.getAdminId(),
    Sessao.AdminLogado.getIdEmpresa());
            cadastroFunc.Show();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha o Email e a senha para efetuar o Login");
                return;
            }

            LoginVerify lv = new LoginVerify();
            bool loginValidoFuncionario = lv.ValidarLogin(email, senha);

            if (loginValidoFuncionario)
            {
                empresaCadFuncionario empresa = new empresaCadFuncionario();
                var funcionario = empresa.ObterFuncionarioPorEmailSenha(email, senha);

                if (funcionario != null)
                {
                    Sessao.FuncionarioLogado = funcionario;
                    Sessao.AdminLogado = null;

                    Configuracoes config = new Configuracoes(funcionario);
                    config.Show();
                    this.Hide();
                    return;
                }
                else
                {
                    MessageBox.Show("Erro ao carregar dados do funcionário.");
                    return;
                }
            }
            else
            {
                // Tenta login como administrador
                empresaCadAdmin admin = new empresaCadAdmin();
                var adminLogado = admin.ObterAdminPorEmailSenha(email, senha);

                if (adminLogado != null)
                {
                    Sessao.AdminLogado = adminLogado;
                    Sessao.FuncionarioLogado = null;

                    // Abre a tela de configurações passando o admin logado
                    Configuracoes config = new Configuracoes(adminLogado);
                    config.Show();
                    this.Hide();
                    return;
                }
                else
                {
                    MessageBox.Show("Email ou senha incorretos.");
                    return;
                }
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtSenha_TextChanged(object sender, EventArgs e) { }
    }
}

