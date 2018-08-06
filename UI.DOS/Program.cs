using System;
using System.Data.SqlClient;


namespace UI.DOS
{

    class Program
    {
        static void Main(string[] args)
        {

            var appAluno = new AlunoAplicacao();

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

            /*INSERT OU UPDATE*/

            var aluno1 = new Aluno()
            {
                Nome = nome,
                Mae = mae,
                DataNascimento = DateTime.Parse(dataNascimento)
            };
            //aluno1.Id = 0;
            appAluno.Salvar(aluno1);

            /*DELETE*/
            //new AlunoAplicacao().Excluir(9);

            /*READ*/
            var dados = appAluno.ListarTodos();

            /***************************CRUD REFERENCIADO*********************/



            /*ENCAPSULADO*/
            foreach (var aluno in dados)
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Mae:{2}, DataNascimento:{3}", aluno.Id, aluno.Nome, aluno.Mae, aluno.DataNascimento);
            }

        }
    }
}
