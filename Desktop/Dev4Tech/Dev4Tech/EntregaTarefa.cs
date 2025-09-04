using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Dev4Tech
{
    class EntregaTarefa : conexao
    {
        // Busca a tarefa da equipe selecionada
        public DataRow BuscarTarefaPorEquipe(int idEquipe)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Tarefas WHERE id_equipe = @idEquipe ORDER BY id_tarefa DESC LIMIT 1";
            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                finally
                {
                    fecharConexao();
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Registra a entrega da tarefa
        public void RegistrarEntrega(int idTarefa, int idEquipe, string descricao, string nomeArquivo, byte[] arquivoBlob)
        {
            string query = "INSERT INTO EntregasTarefa (id_tarefa, id_equipe, descricao, nome_arquivo, arquivo_blob) " +
                           "VALUES (@idTarefa, @idEquipe, @desc, @nomeArq, @arqBlob)";
            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@idTarefa", idTarefa);
                    cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
                    cmd.Parameters.AddWithValue("@desc", descricao);
                    cmd.Parameters.AddWithValue("@nomeArq", nomeArquivo);
                    cmd.Parameters.AddWithValue("@arqBlob", (object)arquivoBlob ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    fecharConexao();
                }
            }
        }

        // Retorna todas as tarefas pendentes da equipe (você pode filtrar por status se quiser)
        // Tarefas pendentes: tarefas que não possuem entrega registrada
        public DataTable BuscarTarefasPendentesPorEquipe(int idEquipe)
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT t.*, c.nome_categoria, e.nome_equipe
        FROM Tarefas t
        INNER JOIN Equipes eq ON t.id_equipe = eq.id_equipe
        INNER JOIN Categorias c ON eq.id_categoria = c.id_categoria
        INNER JOIN Equipes e ON t.id_equipe = e.id_equipe
        WHERE t.id_equipe = @idEquipe
        AND NOT EXISTS (
            SELECT 1 FROM EntregasTarefa et WHERE et.id_tarefa = t.id_tarefa AND et.id_equipe = t.id_equipe
        )
        ORDER BY t.data_entrega DESC";

            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
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

        // Tarefas entregues: tarefas que possuem entrega registrada
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
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
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
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
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
        public DataTable BuscarTarefasPendentesPorEquipeOrdenadasPorDificuldade(int idEquipe)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT t.*, c.nome_categoria, e.nome_equipe
                FROM Tarefas t
                INNER JOIN Equipes e ON t.id_equipe = e.id_equipe
                INNER JOIN Categorias c ON e.id_categoria = c.id_categoria
                WHERE t.id_equipe = @idEquipe
                AND NOT EXISTS (
                    SELECT 1 FROM EntregasTarefa et WHERE et.id_tarefa = t.id_tarefa AND et.id_equipe = t.id_equipe
                )
                ORDER BY
                    CASE t.dificuldade
                        WHEN 'Difícil' THEN 1
                        WHEN 'Média' THEN 2
                        WHEN 'Fácil' THEN 3
                        ELSE 4
                    END,
                    t.data_entrega DESC";

            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
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

        // NOVO MÉTODO: Busca uma tarefa específica por ID (para exibir detalhes)
        public DataRow BuscarTarefaPorId(int idTarefa)
        {
            DataTable dt = new DataTable();
            // Seleciona todos os campos da tarefa para exibir os detalhes
            string query = "SELECT t.*, c.nome_categoria FROM Tarefas t INNER JOIN Equipes e ON t.id_equipe = e.id_equipe INNER JOIN Categorias c ON e.id_categoria = c.id_categoria WHERE t.id_tarefa = @idTarefa";
            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@idTarefa", idTarefa);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
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
