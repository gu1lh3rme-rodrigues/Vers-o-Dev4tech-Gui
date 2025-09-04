using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
    public class empresaCadAdmin : conexao
    {
        private string AdminId, Email, Senha, Telefone, CPF, Cargo, Nome, endereco, num;
        private DateTime data_cadAdmin, DataNascimento;

        public void setNum(string num) { this.num = num; }
        public void setEndereco(string endereco) { this.endereco = endereco; }
        public void setData_cadAdmin(DateTime data_cadAdmin) { this.data_cadAdmin = data_cadAdmin; }
        public void setAdminId(string adminId) { this.AdminId = adminId; }
        public void setNome(string nome) { this.Nome = nome; }
        public void setCargo(string cargo) { this.Cargo = cargo; }
        public void setCPF(string cpf) { this.CPF = cpf; }
        public void setDataNascimento(DateTime dataNascimento) { this.DataNascimento = dataNascimento; }
        public void setTelefone(string telefone) { this.Telefone = telefone; }
        public void setEmail(string email) { this.Email = email; }
        public void setSenha(string senha) { this.Senha = senha; }

        public string getEndereco() { return this.endereco; }
        public string getNum() { return this.num; }
        public DateTime getData_cadAdmin() { return this.data_cadAdmin; }
        public string getAdminId() { return this.AdminId; }
        public string getNome() { return this.Nome; }
        public string getCargo() { return this.Cargo; }
        public string getCPF() { return this.CPF; }
        public DateTime getDataNascimento() { return this.DataNascimento; }
        public string getTelefone() { return this.Telefone; }
        public string getEmail() { return this.Email; }
        public string getSenha() { return this.Senha; }

        // Método para obter administrador por email e senha (login)
        public empresaCadAdmin ObterAdminPorEmailSenha(string email, string senha)
        {
            empresaCadAdmin admin = null;

            string query = "SELECT AdminId, Nome, Cargo, CPF, DataNascimento, Telefone, Email, endereco, num, data_cadAdmin, Senha " +
                           "FROM Administradores WHERE Email = @Email AND Senha = @Senha LIMIT 1";

            if (this.abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            admin = new empresaCadAdmin();

                            admin.setAdminId(reader["AdminId"].ToString());
                            admin.setNome(reader["Nome"].ToString());
                            admin.setCargo(reader["Cargo"].ToString());
                            admin.setCPF(reader["CPF"].ToString());
                            admin.setDataNascimento(Convert.ToDateTime(reader["DataNascimento"]));
                            admin.setTelefone(reader["Telefone"].ToString());
                            admin.setEmail(reader["Email"].ToString());
                            admin.setEndereco(reader["endereco"].ToString());
                            admin.setNum(reader["num"].ToString());
                            admin.setData_cadAdmin(Convert.ToDateTime(reader["data_cadAdmin"]));
                            admin.setSenha(reader["Senha"].ToString());
                        }
                    }
                }
                finally
                {
                    this.fecharConexao();
                }
            }

            return admin;
        }

        // Método inserir para mandar os dados no banco de dados
        public void inserir()
        {
            string query = "INSERT INTO Administradores(AdminId,Nome, Cargo, CPF, DataNascimento, Telefone, Email, Senha, data_cadAdmin, endereco, num) " +
                           "VALUES('" + getAdminId() + "','" + getNome() + "','" + getCargo() + "','" + getCPF() + "','" + getDataNascimento().ToString("yyyy-MM-dd HH:mm:ss") + "','" + getTelefone() + "','" + getEmail() + "','" + getSenha() + "','" + getData_cadAdmin().ToString("yyyy-MM-dd HH:mm:ss") + "','" + getEndereco() + "','" + getNum() + "')";

            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharConexao();
            }
        }
    }
}
