using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rubrica.RepositoryADO
{
    public class RepositoryContattoADO: IRepositoryContatti
    {

        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rubrica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Contatto Add(Contatto item)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Contatto VALUES (@n, @c)";
                command.Parameters.AddWithValue("@n", item.Nome);
                command.Parameters.AddWithValue("@c", item.Cognome);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return item;
                }
                connection.Close();
                return item;

            }





        }

        public bool Delete(Contatto item)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM Contatto WHERE Id=@id";
                command.Parameters.AddWithValue("@id", item.Id);

                int numRighe = command.ExecuteNonQuery();

                if (numRighe == 1)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;

            }

        }

        public List<Contatto> GetAll()
        {
            List<Contatto> contatti = new List<Contatto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Contatto";


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];

                    Contatto contatto = new Contatto(id, nome, cognome);

                    contatti.Add(contatto);
                }
                connection.Close();

                return contatti;
            }
        }

        public Contatto GetById(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Contatto WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                Contatto contatto = new Contatto();

                while (reader.Read())
                {

                    Indirizzo indirizzo = new Indirizzo();
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];

   

                    contatto.Id = id;
                    contatto.Nome = nome;
                    contatto.Cognome = cognome;

                }
                connection.Close();

                return contatto;
            }
        }
    }
}
