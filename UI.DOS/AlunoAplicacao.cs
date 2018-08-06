using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace UI.DOS
{
    public class AlunoAplicacao
    {

        private Contexto contexto;

        /* Metodo para INSERT */
        private void Inserir(Aluno aluno)
        {
            var strQuery = "";
            strQuery += "INSERT INTO ALUNO (Nome, Mae, DataNascimento)";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}') ",
                aluno.Nome, aluno.Mae, aluno.DataNascimento
                );

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        /* Metodo para UPDATE */
        private void Alterar (Aluno aluno)
        {
            var strQuery = "";
            strQuery += " UPDATE Aluno SET ";
            strQuery += string.Format(" Nome = '{0}', ", aluno.Nome);
            strQuery += string.Format(" Mae = '{0}', ", aluno.Mae);
            strQuery += string.Format(" DataNascimento = '{0}' ", aluno.DataNascimento);
            strQuery += string.Format(" WHERE AlunoID = '{0}';", aluno.Id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        /* Metodo publico para Salvar ou Atualizar */
        public void Salvar(Aluno aluno)
        {
            if (aluno.Id > 0)
            {
                Alterar(aluno);
            }
            else
            {
                Inserir(aluno);
            }
        }

        /* Metodo para DELETE */
        public void Excluir (int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM ALUNO WHERE AlunoID = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        /* Metodo para Listar Todos */
        public List<Aluno> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM ALUNO";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaObjeto(retornoDataReader);

            }
        }

        /* Metodo para Transformar Data Reader em Lista*/
        private List<Aluno> TransformaReaderEmListaObjeto(SqlDataReader reader)
        {
            var alunos = new List<Aluno>();
            while (reader.Read())
            {
                var tempObjeto = new Aluno()
                {
                    Id = int.Parse(reader["AlunoID"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Mae = reader["Mae"].ToString(),
                    DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString())
                };

                alunos.Add(tempObjeto);
            }

            reader.Close();
            return alunos;
        }
    }
}
