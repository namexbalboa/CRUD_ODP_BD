using System;
using System.Collections.Generic;
using System.Text;

namespace UI.DOS
{
    public class AlunoAplicacao
    {

      
        private Contexto contexto;

        /* Metodo para INSERT*/
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

        /* Metodo para UPDATE*/
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

    }
}
