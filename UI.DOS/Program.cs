using System;
using System.Data.SqlClient;


namespace UI.DOS
{

    class Program
    {
        static void Main(string[] args)
        {

            /**************************CONSOLE**********************************/
            Console.Write("Digite o Nome do Aluno: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o Nome da Mãe do Aluno: ");
            string mae = Console.ReadLine();

            Console.Write("Digite a data de nascimento do Aluno: ");
            string dataNascimento = Console.ReadLine();

            /**************************CONSOLE**********************************/

            /***************************CRUD CLASSICO***************************/

            ///*CREATE*/
            //string strQueryCreate = "INSERT INTO ALUNO (Nome, Mae, DataNascimento) VALUES ('Joao','Maria','1980-01-01')";
            //SqlCommand cmdComandoCreate = new SqlCommand(strQueryCreate, minhaConexao);
            //cmdComandoCreate.ExecuteNonQuery();

            ///*READ*/
            //string strQuerySelect = "SELECT * FROM ALUNO";
            //SqlCommand cmdComandoSelect = new SqlCommand(strQuerySelect, minhaConexao);
            //SqlDataReader dados = cmdComandoSelect.ExecuteReader();

            /*UPDATE*/
            //string strQueryUpdate = "UPDATE ALUNO SET Nome = 'MARIA LUCIA' WHERE AlunoID = 1";
            //SqlCommand cmdComandoUpdate = new SqlCommand(strQueryUpdate, minhaConexao);
            //cmdComandoUpdate.ExecuteNonQuery

            ///*DELETE*/
            //string strQueryDelete = "DELETE FROM ALUNO WHERE AlunoID = 4;";
            //SqlCommand cmdComandoDelete = new SqlCommand(strQueryDelete, minhaConexao);
            //cmdComandoDelete.ExecuteNonQuery();

            /***************************CRUD CLASSICO***************************/

            /***************************CRUD REFERENCIADO*********************/
            var contexto = new Contexto();

            var aluno = new Aluno()
            {
                Nome = nome,
                Mae = mae,
                DataNascimento = DateTime.Parse(dataNascimento)
            };

            aluno.Id = 10;

            new AlunoAplicacao().Salvar(aluno);
            
            string strQuerySelect = "SELECT * FROM ALUNO";
            SqlDataReader dados = contexto.ExecutaComandoComRetorno(strQuerySelect);

            /***************************CRUD REFERENCIADO*********************/

            while (dados.Read())
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Mae:{2}, DataNascimento:{3}", dados["AlunoId"], dados["Nome"], dados["Mae"], dados["DataNascimento"]);
            }

        }
    }
}
