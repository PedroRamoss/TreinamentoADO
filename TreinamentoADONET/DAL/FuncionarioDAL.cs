using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TreinamentoADONET.Models;

namespace TreinamentoADONET.DAL
{
    public class FuncionarioDAL : IFuncionarioDAL
    {
        private readonly IConfiguration _configuration;
        private string connectionString = "";
        public FuncionarioDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = GetConnectionString();
        }
       
        public IEnumerable<Funcionario> GetAllFuncionarios()
        {
            List<Funcionario> lstfuncionario = new List<Funcionario>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, Nome,Cidade, Departamento FROM Funcionarios", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.Id = Convert.ToInt32(rdr["Id"]);
                    funcionario.Nome = rdr["Nome"].ToString();
                    funcionario.Cidade = rdr["Cidade"].ToString();
                    funcionario.Departamento = rdr["Departamento"].ToString();

                    lstfuncionario.Add(funcionario);
                }
                con.Close();
            }
            return lstfuncionario;
        }

        public void AddFuncionario(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "INSERT INTO Funcionarios (Id, Nome,Cidade,Departamento) VALUES(@Id, @Nome, @Cidade, @Departamento)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", funcionario.Id);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Cidade", funcionario.Cidade);
                cmd.Parameters.AddWithValue("@Departamento", funcionario.Departamento);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
      
        private  string GetConnectionString()
        {
            return _configuration.GetSection("ConnectionStrings").Value;
        }

    }
}
