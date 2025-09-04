using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
    public class empresaCadFuncionario : conexao
    {
        private string FuncionarioId, Email, Senha, Telefone, CPF, Cargo, Nome, endereco, numero, id_empresa, AdminId;
        private DateTime data_cadFunc, DataNascimento;

        private byte[] fotoPerfilBytes;

        public void setFotoPerfilBytes(byte[] bytes)
        {
            fotoPerfilBytes = bytes;
        }
        public byte[] getFotoPerfilBytes()
        {
            return fotoPerfilBytes;
        }

        public void setData_cadFunc(DateTime data_cadFunc) { this.data_cadFunc = data_cadFunc; }
        public void setNumero(string numero) { this.numero = numero; }
        public void setEndereco(string endereco) { this.endereco = endereco; }
        public void setFuncionarioId(string FuncionarioId) { this.FuncionarioId = FuncionarioId; }
        public void setNome(string nome) { this.Nome = nome; }
        public void setCargo(string cargo) { this.Cargo = cargo; }
        public void setCPF(string cpf) { this.CPF = cpf; }
        public void setDataNascimento(DateTime dataNascimento) { this.DataNascimento = dataNascimento; }
        public void setTelefone(string telefone) { this.Telefone = telefone; }
        public void setEmail(string email) { this.Email = email; }
        public void setSenha(string senha) { this.Senha = senha; }
        public void setIdEmpresa(string id_Empresa) { this.id_empresa = id_Empresa; }
        public void setAdminId(string AdminId) { this.AdminId = AdminId; }

        public string getEndereco() { return this.endereco; }
        public string getNumero() { return this.numero; }
        public string getFuncionarioId() { return this.FuncionarioId; }
        public string getNome() { return this.Nome; }
        public string getCargo() { return this.Cargo; }
        public string getCPF() { return this.CPF; }
        public DateTime getDataNascimento() { return this.DataNascimento; }
        public string getTelefone() { return this.Telefone; }
        public string getEmail() { return this.Email; }
        public string getSenha() { return this.Senha; }
        public DateTime getData_cadFunc() { return this.data_cadFunc; }
        public string getIdEmpresa() { return this.id_empresa; }
        public string getAdminId() { return this.AdminId; }

        public empresaCadFuncionario ObterFuncionarioPorEmailSenha(string email, string senha)
        {
            empresaCadFuncionario func = null;

            string query = @"SELECT FuncionarioId, Nome, Cargo, CPF, DataNascimento, Telefone, Email, endereco, numero, data_cadFunc, Senha, id_empresa, AdminId 
                             FROM Funcionarios WHERE Email = @Email AND Senha = @Senha LIMIT 1";

            if (!this.abrirConexao())
                throw new Exception("Falha ao abrir conexão com o banco de dados.");

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                {
                    cmd.Parameters.AddWithValue("@Email", email?.Trim() ?? "");
                    cmd.Parameters.AddWithValue("@Senha", senha); // Se usar hash, ajuste aqui

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            func = new empresaCadFuncionario();
                            func.setFuncionarioId(reader["FuncionarioId"].ToString());
                            func.setNome(reader["Nome"].ToString());
                            func.setCargo(reader["Cargo"].ToString());
                            func.setCPF(reader["CPF"].ToString());
                            func.setDataNascimento(Convert.ToDateTime(reader["DataNascimento"]));
                            func.setTelefone(reader["Telefone"].ToString());
                            func.setEmail(reader["Email"].ToString());
                            func.setEndereco(reader["endereco"].ToString());
                            func.setNumero(reader["numero"].ToString());
                            func.setData_cadFunc(Convert.ToDateTime(reader["data_cadFunc"]));
                            func.setSenha(reader["Senha"].ToString());
                            func.setIdEmpresa(reader["id_empresa"].ToString());
                            func.setAdminId(reader["AdminId"].ToString());
                        }
                    }
                }
            }
            finally
            {
                this.fecharConexao();
            }
            return func;
        }

        public void inserir()
        {
            string query = @"INSERT INTO Funcionarios
                (Nome, Cargo, CPF, DataNascimento, Telefone, Email, Senha, data_cadFunc, endereco, numero, id_empresa, AdminId) 
                VALUES (@Nome, @Cargo, @CPF, @DataNascimento, @Telefone, @Email, @Senha, @DataCadFunc, @Endereco, @Numero, @IdEmpresa, @AdminId)";

            if (!this.abrirConexao())
                throw new Exception("Falha ao abrir conexão com o banco de dados.");

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                {
                    cmd.Parameters.AddWithValue("@Nome", getNome()?.Trim());
                    cmd.Parameters.AddWithValue("@Cargo", getCargo()?.Trim());
                    cmd.Parameters.AddWithValue("@CPF", getCPF()?.Trim());
                    cmd.Parameters.AddWithValue("@DataNascimento", getDataNascimento());
                    cmd.Parameters.AddWithValue("@Telefone", getTelefone()?.Trim());
                    cmd.Parameters.AddWithValue("@Email", getEmail()?.Trim());
                    cmd.Parameters.AddWithValue("@Senha", getSenha());
                    cmd.Parameters.AddWithValue("@DataCadFunc", getData_cadFunc());
                    cmd.Parameters.AddWithValue("@Endereco", getEndereco()?.Trim());
                    cmd.Parameters.AddWithValue("@Numero", getNumero()?.Trim());
                    cmd.Parameters.AddWithValue("@IdEmpresa", getIdEmpresa());
                    cmd.Parameters.AddWithValue("@AdminId", getAdminId());

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                this.fecharConexao();
            }
        }
    }
}
