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
    class Tarefas : conexao
    {
        private string id_tarefa, id_equipe, id_criador, titulo, descricao, data_criacao, data_limite, data_conclusao, prioridade, status;

        public void setIdTarefa(string id_tarefa)
        {
            this.id_tarefa = id_tarefa;
        }
        public void setIdEquipe(string id_equipe)
        {
            this.id_equipe = id_equipe;
        }
        public void setIdCriador(string id_criador)
        {
            this.id_criador = id_criador;
        }
        public void setTitulo(string titulo)
        {
            this.titulo = titulo;
        }
        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }
        public void setDataCriacao(string data_criacao)
        {
            this.data_criacao = data_criacao;
        }
        public void setDataLimite(string data_limite)
        {
            this.data_limite = data_limite;
        }
        public void setDataConclusao(string data_conclusao)
        {
            this.data_conclusao = data_conclusao;
        }
        public void setPrioridade(string prioridade)
        {
            this.prioridade = prioridade;
        }
        public void setStatus(string status)
        {
            this.status = status;
        }

        public string getIdTarefa()
        {
            return this.id_tarefa;
        }
        public string getIdEquipe()
        {
            return this.id_equipe;
        }
        public string getIdCriador()
        {
            return this.id_criador;
        }
        public string getTitulo()
        {
            return this.titulo;
        }
        public string getDescricao()
        {
            return this.descricao;
        }
        public string getDataCriacao()
        {
            return this.data_criacao;
        }
        public string getDataLimite()
        {
            return this.data_limite;
        }
        public string getDataConclusao()
        {
            return this.data_conclusao;
        }
        public string getPrioridade()
        {
            return this.prioridade;
        }
        public string getStatus()
        {
            return this.status;
        }

        public void inserir()
        {
            string query = "INSERT INTO Tarefas(id_equipe, id_criador, titulo, descricao, data_criacao, data_limite, prioridade, status) " +
                           "VALUES('" + getIdEquipe() + "','" + getIdCriador() + "','" + getTitulo() + "','" + getDescricao() + "',NOW(),'" + getDataLimite() + "','" + getPrioridade() + "','pendente')";

            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharConexao();
            }
        }

        public void concluirTarefa()
        {
            string query = "UPDATE Tarefas SET status = 'concluida', data_conclusao = NOW() WHERE id_tarefa = '" + getIdTarefa() + "'";
            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharConexao();
            }
        }

        public DataTable ConsultarPendentes()
        {
            DataTable dt = new DataTable();
            string mSQL = "SELECT * FROM Tarefas WHERE status = 'pendente'";

            if (this.abrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                this.fecharConexao();
            }
            return dt;
        }
    }
} 