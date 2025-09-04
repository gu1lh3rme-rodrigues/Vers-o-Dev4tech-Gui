using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
    class AddTarefas : conexao
    {
        public string NomeTarefa { get; set; }
        public string Instrucoes { get; set; }
        public string Dificuldade { get; set; } // Nova propriedade
        public int IdEquipe { get; set; }
        public DateTime DataEntrega { get; set; }
        public string NomeArquivo { get; set; }
        public byte[] ArquivoBlob { get; set; }

        public void Inserir()
        {
            string query = "INSERT INTO Tarefas (nomeTarefa, instrucoes, dificuldade, id_equipe, data_entrega, nome_arquivo, arquivo_blob) " +
                           "VALUES (@nome, @instr, @dificuldade, @idEq, @data, @nomeArq, @arqBlob)";

            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@nome", NomeTarefa);
                    cmd.Parameters.AddWithValue("@instr", Instrucoes);
                    cmd.Parameters.AddWithValue("@dificuldade", Dificuldade);
                    cmd.Parameters.AddWithValue("@idEq", IdEquipe);
                    cmd.Parameters.AddWithValue("@data", DataEntrega);
                    cmd.Parameters.AddWithValue("@nomeArq", NomeArquivo);
                    cmd.Parameters.AddWithValue("@arqBlob", (object)ArquivoBlob ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    fecharConexao();
                }
            }
        }

        public DataTable BuscarEquipes()
        {
            DataTable dt = new DataTable();
            if (abrirConexao())
            {
                try
                {
                    string query = "SELECT id_equipe, nome_equipe FROM Equipes ORDER BY nome_equipe";
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                finally
                {
                    fecharConexao();
                }
            }
            return dt;
        }
    }
}
