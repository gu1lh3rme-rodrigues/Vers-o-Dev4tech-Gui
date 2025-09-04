using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
        class LoginVerify : conexao
    {
        public bool ValidarLogin(string email, string senha)
        {
            bool valido = false;
            string query = "SELECT COUNT(*) FROM Funcionarios WHERE email = @Email AND senha = @Senha";

            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        long countLong = (long)result;
                        int count = Convert.ToInt32(countLong);
                        valido = (count > 0);
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }
            return valido;
        }
    }
}
