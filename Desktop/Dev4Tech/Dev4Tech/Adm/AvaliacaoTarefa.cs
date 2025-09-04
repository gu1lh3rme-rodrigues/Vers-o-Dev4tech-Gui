using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
    class AvaliacaoTarefa : conexao
    {
        public void SalvarAvaliacao(int idTarefa, bool aceita, bool? atrasoJustificado)
        {
            string query = @"
                INSERT INTO AvaliacaoTarefa (id_tarefa, aceita, atraso_justificado)
                VALUES (@idTarefa, @aceita, @atraso)
                ON DUPLICATE KEY UPDATE aceita = @aceita, atraso_justificado = @atraso";

            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@idTarefa", idTarefa);
                    cmd.Parameters.AddWithValue("@aceita", aceita);
                    if (atrasoJustificado.HasValue)
                        cmd.Parameters.AddWithValue("@atraso", atrasoJustificado.Value);
                    else
                        cmd.Parameters.AddWithValue("@atraso", DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    fecharConexao();
                }
            }
        }
    }
}