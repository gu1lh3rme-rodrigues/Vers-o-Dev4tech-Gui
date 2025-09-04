using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
    class EntregaTarefa : conexao
    {
        // Busca a tarefa da equipe selecionada (última criada)
        public DataRow BuscarTarefaPorEquipe(int idEquipe)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Tarefas WHERE id_equipe = @idEquipe ORDER BY id_tarefa DESC LIMIT 1";

            if (abrirConexao())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                    {
                        cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Registra a entrega da tarefa feita por um funcionário específico na tabela EntregasTarefa
        public void RegistrarEntrega(int idTarefa, int idEquipe, int idFuncionario, string descricao, string nomeArquivo, byte[] arquivoBlob)
        {
            string query = @"
                INSERT INTO EntregasTarefa 
                (id_tarefa, id_equipe, FuncionarioId, descricao, nome_arquivo, arquivo_blob, data_entrega) 
                VALUES (@idTarefa, @idEquipe, @idFuncionario, @desc, @nomeArq, @arqBlob, NOW())";

            if (abrirConexao())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                    {
                        cmd.Parameters.AddWithValue("@idTarefa", idTarefa);
                        cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
                        cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                        cmd.Parameters.AddWithValue("@desc", descricao);
                        cmd.Parameters.AddWithValue("@nomeArq", nomeArquivo);
                        cmd.Parameters.AddWithValue("@arqBlob", (object)arquivoBlob ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }
            else
            {
                throw new Exception("Não foi possível abrir a conexão com o banco de dados.");
            }
        }

        // Verifica se o funcionário já entregou a tarefa
        public bool FuncionarioEntregou(int idTarefa, int idFuncionario)
        {
            bool entregou = false;
            string query = @"
                SELECT COUNT(*) FROM EntregasTarefa 
                WHERE id_tarefa = @idTarefa AND FuncionarioId = @idFuncionario";

            if (abrirConexao())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                    {
                        cmd.Parameters.AddWithValue("@idTarefa", idTarefa);
                        cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);

                        var result = cmd.ExecuteScalar();
                        int count = Convert.ToInt32(result);
                        entregou = (count > 0);
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }

            return entregou;
        }

        // Verifica se todos os funcionários da equipe já entregaram a tarefa
        public bool TodosEntregaram(int idTarefa, int idEquipe)
        {
            bool todosEntregaram = false;
            string query = @"
                SELECT 
                    (SELECT COUNT(*) FROM Equipes_Membros WHERE id_equipe = @idEquipe) AS total_funcionarios,
                    (SELECT COUNT(DISTINCT FuncionarioId) FROM EntregasTarefa WHERE id_tarefa = @idTarefa AND id_equipe = @idEquipe) AS total_entregas";

            if (abrirConexao())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                    {
                        cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
                        cmd.Parameters.AddWithValue("@idTarefa", idTarefa);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int totalFuncionarios = 0;
                            int totalEntregas = 0;

                            if (reader.Read())
                            {
                                totalFuncionarios = Convert.ToInt32(reader["total_funcionarios"]);
                                totalEntregas = Convert.ToInt32(reader["total_entregas"]);
                            }

                            todosEntregaram = (totalFuncionarios > 0 && totalFuncionarios == totalEntregas);
                        }
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }

            return todosEntregaram;
        }

        // Busca todas as tarefas pendentes da equipe (tarefas que não têm entrega do funcionário, ou seja, ele não entregou ainda)
        // Para um funcionário específico, usando LEFT JOIN para identificar tarefas não entregues dele
        public DataTable BuscarTarefasPendentesPorEquipeFuncionario(int idEquipe, int idFuncionario)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT t.*, c.nome_categoria, e.nome_equipe
                FROM Tarefas t
                INNER JOIN Equipes e ON t.id_equipe = e.id_equipe
                INNER JOIN Categorias c ON e.id_categoria = c.id_categoria
                LEFT JOIN EntregasTarefa et ON t.id_tarefa = et.id_tarefa AND et.FuncionarioId = @idFuncionario
                WHERE t.id_equipe = @idEquipe
                AND et.id_entrega IS NULL
                ORDER BY t.data_entrega DESC";

            if (abrirConexao())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                    {
                        cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
                        cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }
            return dt;
        }

        // Busca todas as tarefas entregues pelo funcionário em uma equipe
        public DataTable BuscarTarefasEntreguesPorEquipeFuncionario(int idEquipe, int idFuncionario)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT DISTINCT t.*, c.nome_categoria, e.nome_equipe
                FROM Tarefas t
                INNER JOIN Equipes e ON t.id_equipe = e.id_equipe
                INNER JOIN Categorias c ON e.id_categoria = c.id_categoria
                INNER JOIN EntregasTarefa et ON t.id_tarefa = et.id_tarefa AND et.FuncionarioId = @idFuncionario
                WHERE t.id_equipe = @idEquipe
                ORDER BY t.data_entrega DESC";

            if (abrirConexao())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                    {
                        cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
                        cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }
            return dt;
        }

        public DataTable BuscarTarefasAtrasadasPorEquipe(int idEquipe)
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT t.*, c.nome_categoria, e.nome_equipe
        FROM Tarefas t
        INNER JOIN Equipes e ON t.id_equipe = e.id_equipe
        INNER JOIN Categorias c ON e.id_categoria = c.id_categoria
        WHERE t.id_equipe = @idEquipe
        AND t.data_entrega < CURDATE()
        AND NOT EXISTS (
            SELECT 1 FROM EntregasTarefa et WHERE et.id_tarefa = t.id_tarefa AND et.id_equipe = t.id_equipe
        )
        ORDER BY t.data_entrega DESC";

            if (abrirConexao())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                    {
                        cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }
            return dt;
        }

        public DataTable BuscarTarefasCompletadasPorEquipe(int idEquipe)
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT t.*, c.nome_categoria, e.nome_equipe
        FROM Tarefas t
        INNER JOIN Equipes eq ON t.id_equipe = eq.id_equipe
        INNER JOIN Categorias c ON eq.id_categoria = c.id_categoria
        INNER JOIN Equipes e ON t.id_equipe = e.id_equipe
        WHERE t.id_equipe = @idEquipe
        AND EXISTS (
            SELECT 1 FROM EntregasTarefa et WHERE et.id_tarefa = t.id_tarefa AND et.id_equipe = t.id_equipe
        )
        ORDER BY t.data_entrega DESC";

            if (abrirConexao())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                    {
                        cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }
            return dt;
        }


        // Busca uma tarefa específica por ID
        public DataRow BuscarTarefaPorId(int idTarefa)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT t.*, c.nome_categoria, e.nome_equipe
                FROM Tarefas t
                INNER JOIN Equipes e ON t.id_equipe = e.id_equipe
                INNER JOIN Categorias c ON e.id_categoria = c.id_categoria
                WHERE t.id_tarefa = @idTarefa";

            if (abrirConexao())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conectar))
                    {
                        cmd.Parameters.AddWithValue("@idTarefa", idTarefa);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                finally
                {
                    fecharConexao();
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}