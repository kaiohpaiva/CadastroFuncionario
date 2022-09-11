using CadastroFuncionario.Data.Model;
using CadastroFuncionario.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFuncionario.Repository
{
    public class FuncionarioRepository : IFuncionario
    {
        public void AlterarFuncionario(Funcionario funcionario)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            sqlConnection.Open();

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"
             UPDATE [CadastroFuncionario].[dbo].[TB_Funcionario]
                SET [Nome] = @NOME,
                [DataNascimento] = @DATANASCIMENTO,
                [Salario] = @SALARIO, 
                [Atividades]  = @ATIVIDADES

             WHERE CodFuncionario = @CODFUNCIONARIO";

            cmd.Parameters.Add("@NOME", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@NOME"].Value = funcionario.Nome;

            cmd.Parameters.Add("@DATANASCIMENTO", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@DATANASCIMENTO"].Value = funcionario.DataNascimento;

            cmd.Parameters.Add("@SALARIO", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@SALARIO"].Value = funcionario.Salario;

            cmd.Parameters.Add("@ATIVIDADES", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@ATIVIDADES"].Value = funcionario.Atividades;

            cmd.ExecuteNonQuery();

            cmd.Dispose();

            sqlConnection.Close();
            
        }

        public List<Funcionario> BuscaFuncionario(string nome)
        {
            List<Funcionario> listFuncionario = new List<Funcionario>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            sqlConnection.Open();

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"
             SELECT 
                  [CodFuncionario]
                , [Nome]
                , [DataNascimento]
                ,[Salario], 
                [Atividades] 
             FROM [dbo].[TB_Funcionario]
             Where Nome like @nome";

            SqlParameter p = new SqlParameter("@nome", SqlDbType.VarChar)
            {
                Value = "%" + nome + "%"
            };

            cmd.Parameters.AddWithValue(p.ParameterName, p.Value);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                //MessageBox.Show(reader.GetValue(0) + " - " + reader.GetValue(1) + " - " + reader.GetValue(2));
                listFuncionario.Add(
                    new Funcionario()
                    {
                        CodFuncionario = Convert.ToInt32(reader["CodFuncionario"]),
                        Nome = reader["Nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                        Salario = Convert.ToDouble( reader["Salario"]),
                        Atividades = reader["Atividades"].ToString()
                    });
            }

            reader.Close();
            cmd.Dispose();

            sqlConnection.Close();
            return listFuncionario;
        }

        public void CriarFuncionario(Funcionario funcionario)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            sqlConnection.Open();

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"
            INSERT INTO [dbo].[TB_Funcionario]
             (  [Nome]
                ,[DataNascimento]
                ,[Salario]
                ,[Atividades]
             )
             VALUES
                   (@NOME
                   ,@DATANASCIMENTO
                   ,@SALARIO
                   ,@ATIVIDADES
             )";

            cmd.Parameters.Add("@NOME", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@NOME"].Value = funcionario.Nome;

            cmd.Parameters.Add("@DATANASCIMENTO", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@DATANASCIMENTO"].Value = funcionario.DataNascimento;

            cmd.Parameters.Add("@SALARIO", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@SALARIO"].Value = funcionario.Salario;

            cmd.Parameters.Add("@ATIVIDADES", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@ATIVIDADES"].Value = funcionario.Atividades;

            cmd.ExecuteNonQuery();

            cmd.Dispose();

            sqlConnection.Close();
        }

        public void DeleteFuncionario(int codFuncionario)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            sqlConnection.Open();

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"
            DELETE [dbo].[TB_Funcionario]
            WHERE CodFuncionario = @CODFUNCIONARIO";

            cmd.Parameters.Add("@CODFUNCIONARIO", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@CODFUNCIONARIO"].Value = codFuncionario;

            cmd.ExecuteNonQuery();

            cmd.Dispose();

            sqlConnection.Close();

        }
    }
}
