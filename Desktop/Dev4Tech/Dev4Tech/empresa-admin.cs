using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Biblioteca de conexão do SQL
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Dev4Tech
{
    class empresa_admin : conexao
    {
        private string AdminId, Email, Senha, Telefone, DataNascimento, CPF, Cargo, Nome;

        public void setAdminId(string adminId)
        {
            this.AdminId = adminId;
        }
        public void setNome(string nome)
        {
            this.Nome = nome;
        }
        public void setCargo(string cargo)
        {
            this.Cargo = cargo;
        }
        public void setCPF(string cpf)
        {
            this.CPF = cpf;
        }
        public void setDataNascimento(string dataNascimento)
        {
            this.DataNascimento = dataNascimento;
        }
        public void setTelefone(string telefone)
        {
            this.Telefone = telefone;
        }
        public void setEmail(string email)
        {
            this.Email = email;
        }
        public void setSenha(string senha)
        {
            this.Senha = senha;
        }

        public string getAdminId()
        {
            return this.AdminId;
        }
        public string getNome()
        {
            return this.Nome;
        }
        public string getCargo()
        {
            return this.Cargo;
        }
        public string getCPF()
        {
            return this.CPF;
        }
        public string getDataNascimento()
        {
            return this.DataNascimento;
        }
        public string getTelefone()
        {
            return this.Telefone;
        }
        public string getEmail()
        {
            return this.Email;
        }
        public string getSenha()
        {
            return this.Senha;
        }

        //Método inserir, para mandar os dados no banco de dados
        public void inserir()
        {
            string query = "INSERT INTO Administradores(Nome, Cargo, CPF, DataNascimento, Telefone, Email, Senha) " +
                           "VALUES('" + getAdminId() + "','" + getNome() + "','" + getCargo() + "','" + getCPF() + "','" + getDataNascimento() + "','" + getTelefone() + "','" + getEmail() + "','" + getSenha() + "')";

            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharConexao();
            }
        }

        //Excluir informações do banco de dados por meio da chave primária
        public void excluir()
        {
            string query = "DELETE FROM Administradores WHERE AdminID = '" + getAdminId() + "'";
            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharConexao();
            }
        }

        //Método consultar mostra todos os dados existentes na tabela
        public DataTable Consultar()
        {
            DataTable dt = new DataTable();
            string mSQL = "SELECT * FROM Administradores";

            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                this.fecharConexao();
            }
            return dt;
        }
    }
}
