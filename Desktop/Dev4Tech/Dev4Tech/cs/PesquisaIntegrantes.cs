using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace Dev4Tech
{
    class PesquisaIntegrantes : conexao
    {
        public DataTable BuscarEquipesComCategoriaEMembros()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT e.id_equipe, e.nome_equipe, c.nome_categoria
                FROM Equipes e
                INNER JOIN Categorias c ON e.id_categoria = c.id_categoria
                ORDER BY e.nome_equipe";
            if (abrirConexao())
            {
                try
                {
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
        public DataTable BuscarMembrosDaEquipe(int idEquipe, string filtroNome = "")
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT f.FuncionarioId, f.Nome, f.Email, f.Telefone, f.foto_perfil
                FROM Equipes_Membros em
                INNER JOIN Funcionarios f ON em.FuncionarioId = f.FuncionarioId
                WHERE em.id_equipe = @idEquipe";
            if (!string.IsNullOrWhiteSpace(filtroNome))
            {
                query += " AND f.Nome LIKE @filtroNome";
            }
            if (abrirConexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@idEquipe", idEquipe);
                    if (!string.IsNullOrWhiteSpace(filtroNome))
                        cmd.Parameters.AddWithValue("@filtroNome", "%" + filtroNome + "%");
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
