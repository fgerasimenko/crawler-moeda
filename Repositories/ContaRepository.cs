using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Repositories
{
    public class ContaRepository
    {

        public void Save(Conta conta)
        {
            var connString = @"Server=localhost\SQLEXPRESS;Database=ContaDB;User Id=dev;Password=teste123;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Conta VALUES (@id, @saldo)";

                    cmd.Parameters.AddWithValue("@id", conta.Id);
                    cmd.Parameters.AddWithValue("@saldo", conta.Saldo);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void Update(Conta conta)
        {
            var connString = @"Server=localhost\SQLEXPRESS;Database=ContaDB;User Id=dev;Password=teste123;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Conta SET Saldo = @saldo WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", conta.Id);
                    cmd.Parameters.AddWithValue("@saldo", conta.Saldo);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public Conta GetConta(int id)
        {
            Conta conta = new Conta();

            var connString = @"Server=localhost\SQLEXPRESS;Database=ContaDB;User Id=dev;Password=teste123;";
            
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from Conta Where Id = "+ id;
                    


                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        while (data.Read())
                        {
                            conta.Codigo = data["Codigo"] != null ? Convert.ToInt32(data["Codigo"]) : 0;
                            conta.Id = data["Id"] != null ? Convert.ToInt32(data["Id"]) : 0;
                            conta.Saldo = data["Saldo"] != null ? Convert.ToDecimal(data["Saldo"]) : 0;
                        }
                    }
                }
                conn.Close();
            }
            return conta;
        }
    }
}
