using System.Data;
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
    class FiltroEquipes : conexao
    {
        public DataTable ObterEquipesComMembros(string filtroCategoria = null)
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT 
    e.id_equipe, 
    e.nome_equipe, 
    c.nome_categoria, 
    f.Nome AS nome_funcionario,
    COALESCE(
        TIMESTAMPDIFF(DAY, u.ultima_atividade, NOW()),
        TIMESTAMPDIFF(DAY, e.data_criacao, NOW()),
        -1
    ) AS dias_desde_ultima_atividade
FROM Equipes e
INNER JOIN Categorias c ON e.id_categoria = c.id_categoria
INNER JOIN Equipes_Membros em ON e.id_equipe = em.id_equipe
INNER JOIN Funcionarios f ON em.FuncionarioId = f.FuncionarioId
LEFT JOIN UltimaAtividadeEquipe u ON e.id_equipe = u.id_equipe
            ";

            if (!string.IsNullOrEmpty(filtroCategoria) && filtroCategoria != "Todos")
            {
                query += " WHERE c.nome_categoria = @categoria ";
            }

            query += " ORDER BY e.nome_equipe, f.Nome";

            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    if (!string.IsNullOrEmpty(filtroCategoria) && filtroCategoria != "Todos")
                        cmd.Parameters.AddWithValue("@categoria", filtroCategoria);

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
