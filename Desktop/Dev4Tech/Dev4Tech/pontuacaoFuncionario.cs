using System;
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
    public class pontuacaoFuncionario : conexao
    {
        public void AdicionarPontos(int idFuncionario, int pontos)
        {
            string querySelect = "SELECT pontos FROM PontuacaoFuncionario WHERE id_funcionario = @idFuncionario";
            string queryInsert = "INSERT INTO PontuacaoFuncionario (id_funcionario, pontos) VALUES (@idFuncionario, @pontos)";
            string queryUpdate = "UPDATE PontuacaoFuncionario SET pontos = pontos + @pontos WHERE id_funcionario = @idFuncionario";

            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmdSelect = new MySqlCommand(querySelect, conectar);
                    cmdSelect.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                    var result = cmdSelect.ExecuteScalar();

                    if (result == null) // não existe registro, insere
                    {
                        MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conectar);
                        cmdInsert.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                        cmdInsert.Parameters.AddWithValue("@pontos", pontos);
                        cmdInsert.ExecuteNonQuery();
                    }
                    else // já existe, atualiza
                    {
                        MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conectar);
                        cmdUpdate.Parameters.AddWithValue("@pontos", pontos);
                        cmdUpdate.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }
        }

        // Novo método para obter a pontuação atual do funcionário
        public int ObterPontos(int idFuncionario)
        {
            int pontos = 0;
            string query = "SELECT pontos FROM PontuacaoFuncionario WHERE id_funcionario = @idFuncionario";

            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        pontos = Convert.ToInt32(result);
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }

            return pontos;
        }
    }
}