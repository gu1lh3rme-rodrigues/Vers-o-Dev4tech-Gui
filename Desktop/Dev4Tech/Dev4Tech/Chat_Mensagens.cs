using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Dev4Tech
{
    class Chat_Mensagens : conexao
    {
        private string idMensagem;
        private string texto;
        private DateTime dataEnvio;
        private int idEquipe;  // Novo campo para identificar a equipe

        // Setters
        public void setIdMensagem(string idMensagem) { this.idMensagem = idMensagem; }
        public void setTexto(string texto) { this.texto = texto; }
        public void setDataEnvio(DateTime dataEnvio) { this.dataEnvio = dataEnvio; }
        public void setIdEquipe(int idEquipe) { this.idEquipe = idEquipe; }

        // Getters
        public string getIdMensagem() { return this.idMensagem; }
        public string getTexto() { return this.texto; }
        public DateTime getDataEnvio() { return this.dataEnvio; }
        public int getIdEquipe() { return this.idEquipe; }

        // Inserir mensagem no banco com idEquipe
        public void inserir()
        {
            string query = "INSERT INTO MensagensChat (texto, data_envio, id_equipe) " +
                           "VALUES (@texto, @data_envio, @id_equipe)";

            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.Parameters.AddWithValue("@texto", getTexto());
                cmd.Parameters.AddWithValue("@data_envio", getDataEnvio().ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@id_equipe", getIdEquipe());
                cmd.ExecuteNonQuery();
                this.fecharConexao();
            }
        }

        // Excluir mensagem por id (sem alterações)
        public void excluir()
        {
            string query = "DELETE FROM MensagensChat WHERE id_mensagem = @id_mensagem";
            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.Parameters.AddWithValue("@id_mensagem", getIdMensagem());
                cmd.ExecuteNonQuery();
                this.fecharConexao();
            }
        }

        // Consultar mensagens por equipe
        public DataTable ConsultarPorEquipe(int idEquipe)
        {
            DataTable dt = new DataTable();
            if (this.abrirConexao())
            {
                string mSQL = "SELECT * FROM MensagensChat WHERE id_equipe = @id_equipe ORDER BY data_envio";
                MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
                cmd.Parameters.AddWithValue("@id_equipe", idEquipe);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                this.fecharConexao();
            }
            return dt;
        }

        // Atualizar última atividade da equipe
        public void AtualizarUltimaAtividade(int idEquipe)
        {
            string query = @"
                INSERT INTO UltimaAtividadeEquipe (id_equipe, ultima_atividade)
                VALUES (@id_equipe, NOW())
                ON DUPLICATE KEY UPDATE ultima_atividade = NOW()
            ";

            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.Parameters.AddWithValue("@id_equipe", idEquipe);
                cmd.ExecuteNonQuery();
                this.fecharConexao();
            }
        }
    }
}
