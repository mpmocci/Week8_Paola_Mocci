using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Rubrica.RepositoryADO
{
   public class RepositoryIndirizzoADO : IRepositoryIndirizzo
    {

        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rubrica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Indirizzo Add(Indirizzo item)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Indirizzo VALUES (@t, @v, @c, @cap, @p, @n, @idC)";
                command.Parameters.AddWithValue("@t", item.Tipologia);
                command.Parameters.AddWithValue("@v", item.Via);
                command.Parameters.AddWithValue("@c", item.Città);
                command.Parameters.AddWithValue("@cap", item.Cap);
                command.Parameters.AddWithValue("@p", item.Provincia);
                command.Parameters.AddWithValue("@n", item.Nazione);
                command.Parameters.AddWithValue("@idC", item.IdContatto);

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

        public List<Indirizzo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Indirizzo GetById(int id)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Indirizzo WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                Indirizzo indirizzo = new Indirizzo();

                while (reader.Read())
                {
                    var tipologia = (string)reader["Tipologia"];
                    var via = (string)reader["Via"];
                    var citta = (string)reader["Città"];
                    var cap = (int)reader["CAP"];
                    var provincia = (string)reader["Provincia"];
                    var nazione = (string)reader["Nazione"];
                    var idC = (int)reader["IdContatto"];


                    indirizzo.Tipologia = tipologia;
                    indirizzo.Via = via;
                    indirizzo.Città = citta;
                    indirizzo.Cap = cap;
                    indirizzo.Provincia = provincia;
                    indirizzo.Nazione = nazione;
                    indirizzo.IdContatto = idC;

                }
                connection.Close();

                return indirizzo;
            }




        }

        public List<Indirizzo> GetByIdContatto(int id)
        {
            List<Indirizzo> indirizzi = new List<Indirizzo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Indirizzo WHERE IdContatto = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                Indirizzo indirizzo = new Indirizzo();

                while (reader.Read())
                {
                    var tipologia = (string)reader["Tipologia"];
                    var via = (string)reader["Via"];
                    var citta = (string)reader["Città"];
                    var cap = (int)reader["CAP"];
                    var provincia = (string)reader["Provincia"];
                    var nazione = (string)reader["Nazione"];
                    var idC = (int)reader["IdContatto"];


                    indirizzo.Tipologia = tipologia;
                    indirizzo.Via = via;
                    indirizzo.Città = citta;
                    indirizzo.Cap = cap;
                    indirizzo.Provincia = provincia;
                    indirizzo.Nazione = nazione;
                    indirizzo.IdContatto = idC;

                    indirizzi.Add(indirizzo);

                }
                connection.Close();

                return indirizzi;
            }


        }
    }
}
