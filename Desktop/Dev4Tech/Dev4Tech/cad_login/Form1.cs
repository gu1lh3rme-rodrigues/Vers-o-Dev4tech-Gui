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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login t_login = new Login();
            t_login.Show();
            this.Hide();
        }

        private void btnCadastroEmpresa_Click(object sender, EventArgs e)
        {
            Cadastro_empresa cad_empresa = new Cadastro_empresa();
            cad_empresa.Show();
            this.Hide();
        }

        private void btnCadastroEmpresaAdmin_Click(object sender, EventArgs e)
        {
            empresa em = new empresa();
            int idEmpresaGerada = em.inserirEObterId();
            Cadastro_empresa_admin cadastroAdmin = new Cadastro_empresa_admin(idEmpresaGerada.ToString());
            cadastroAdmin.Show();
            this.Hide();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            string idAdminLogado = "";   // Pega este id do admin logado
            string idEmpresaAdmin = "";  // Pega o id da empresa relacionada ao admin

            // Ao abrir a tela de cadastro de funcionário passe os ids
            cadastro_funcionário cadastroFunc = new cadastro_funcionário(idAdminLogado, idEmpresaAdmin);
            cadastroFunc.Show();
            this.Hide();
        }
    }
}
