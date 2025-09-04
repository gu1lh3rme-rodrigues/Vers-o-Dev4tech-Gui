using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Dev4Tech
{
    class Chat : conexao
    {
        private string id_mensagem, id_remetente, id_destinatario, mensagem, data_envio, status;

        public void setIdMensagem(string id_mensagem)
        {
            this.id_mensagem = id_mensagem;
        }
        public void setIdRemetente(string id_remetente)
        {
            this.id_remetente = id_remetente;
        }
        public void setIdDestinatario(string id_destinatario)
        {
            this.id_destinatario = id_destinatario;
        }
        public void setMensagem(string mensagem)
        {
            this.mensagem = mensagem;
        }
        public void setDataEnvio(string data_envio)
        {
            this.data_envio = data_envio;
        }
        public void setStatus(string status)
        {
            this.status = status;
        }

        public string getIdMensagem()
        {
            return this.id_mensagem;
        }
        public string getIdRemetente()
        {
            return this.id_remetente;
        }
        public string getIdDestinatario()
        {
            return this.id_destinatario;
        }
        public string getMensagem()
        {
            return this.mensagem;
        }
        public string getDataEnvio()
        {
            return this.data_envio;
        }
        public string getStatus()
        {
            return this.status;
        }

        public void enviarMensagem()
        {
            string query = "INSERT INTO Mensagens(id_remetente, id_destinatario, mensagem, data_envio, status) " +
                           "VALUES('" + getIdRemetente() + "','" + getIdDestinatario() + "','" + getMensagem() + "',NOW(),'enviada')";

            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharConexao();
            }
        }

        public DataTable ConsultarMensagens(string id_remetente, string id_destinatario)
        {
            DataTable dt = new DataTable();
            string mSQL = "SELECT * FROM Mensagens WHERE (id_remetente = '" + id_remetente + "' AND id_destinatario = '" + id_destinatario + "') " +
                         "OR (id_remetente = '" + id_destinatario + "' AND id_destinatario = '" + id_remetente + "') ORDER BY data_envio ASC";

            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                this.fecharConexao();
            }
            return dt;
        }

        public void marcarComoLida()
        {
            string query = "UPDATE Mensagens SET status = 'lida' WHERE id_destinatario = '" + getIdDestinatario() + "' AND status = 'enviada'";
            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharConexao();
            }
        }
    }
} 