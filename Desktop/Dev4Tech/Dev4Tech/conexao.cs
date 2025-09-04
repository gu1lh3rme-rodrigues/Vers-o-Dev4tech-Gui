using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Biblioteca de conexão do SQL
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
    public class conexao
    {
        public MySqlConnection conectar;
        public string servidor, database, usuario, senha;

        public conexao()
        {
            inicializar();
        }
        public void inicializar()
        {
            servidor = "127.0.0.1";
            /*127.0.0.1 - número do servidor local ou seja o proprio computador, para conexões online necessário colocar o número do servidor na internet.*/
            database = "Dev4Tech";
            //Database que iremos criar futuramente 
            usuario = "root";
            senha = "";
            /*Usuário e senha são padrões (root e senha branco) para conexões remotas, necessários substituir por usuario e senhas fornecidos */
            string conexaoString;
            conexaoString = "SERVER=" + servidor + ";" + "DATABASE= " + database + ";" + "UID= " + usuario + ";" + "PASSWORD= " + senha + ";";
            conectar = new MySqlConnection(conexaoString);
            //MySqlConnection - utlizar a string conexaoString para conectar ao banco de dados
        }
        public bool abrirConexao()
        {
            //try catch é  um tratamento de erros para códigos
            try
            {
                conectar.Open();
                return true;
            }
            catch (MySqlException ex) // Catch - caso o try não execute, o catch entra em ação
            {
                switch (ex.Number)
                {
                    case 0:
                        System.Windows.Forms.MessageBox.Show("Não foi possível conectar.");
                        break;
                    case 1045:
                        System.Windows.Forms.MessageBox.Show("Usuário e senha inválidos");
                        break;
                }
                return false;
            }
        }
        public bool fecharConexao()
        {
            try
            {
                conectar.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}