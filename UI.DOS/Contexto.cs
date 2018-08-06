using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;

namespace UI.DOS
{
    class Contexto : IDisposable
    {

        private readonly SqlConnection minhaconexao;

        /*Toda vez que chamada a classe este método é executado*/
        public Contexto()
        {
            minhaconexao = new SqlConnection(ConfigurationManager.ConnectionStrings["TISelvagemConfig"].ConnectionString);
            minhaconexao.Open();
        }

        /*Encapsulamento de CRUD*/
        public void ExecutaComando(string strQuery)
        {
            var cmdComando = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = minhaconexao
            };

            cmdComando.ExecuteNonQuery();
        }

        /*SELECT SQL*/
        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, minhaconexao);
            return cmdComando.ExecuteReader();
        }

        /*Encerra conexão caso aberta*/
        public void Dispose()
        {
            if (minhaconexao.State == ConnectionState.Open)
            minhaconexao.Close();
            
        }
    }
}
