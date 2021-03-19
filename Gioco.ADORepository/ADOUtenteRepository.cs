using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Gioco.ADORepository.Extensions;
using Gioco.Core.Entità;
using Gioco.Core.Interfaces;

namespace Gioco.ADORepository
{
    public  class ADOUtenteRepository :IUtenteRepository
    {
        const string connectionString = @"Persist Security Info = False; Integrated Security = true; Initial Catalog=Gioco; Server = .\SQLEXPRESS";

        public void Create(Utente obj, string nom)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                

                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = connection;
                selectCommand.CommandType = System.Data.CommandType.Text;
                selectCommand.CommandText = "SELECT * FROM Utente";

                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = connection;
                insertCommand.CommandType = System.Data.CommandType.Text;
                insertCommand.CommandText = "INSERT INTO Utente VALUES (@Nome)";

                insertCommand.Parameters.AddWithValue("@Nome", nom);

                adapter.SelectCommand = selectCommand;
                adapter.InsertCommand = insertCommand;


                DataSet dataset = new DataSet();
                try
                {
                    connection.Open();
                    adapter.Fill(dataset, "Utente");

                    DataRow utente = dataset.Tables["Utente"].NewRow();

                    dataset.Tables["Utente"].Rows.Add(utente);

                    adapter.Update(dataset, "Utente");
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void CreateER(Utente obj, string nom, Utente u)
        {
            throw new NotImplementedException();
        }

        public void CreateER(Utente obj, string nom, string u)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Utente obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Utente> GetAll()
        {
            List<Utente> utente = new List<Utente>();
            //ADO.NET
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //Aprire la connesione
                connection.Open();
                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Utente";

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();
                //Lettura dei dati
                while (reader.Read())
                {
                    utente.Add(reader.ToUtente());
                }
                //Chiusura connesione
                reader.Close();
                connection.Close();
            }
            return utente;
        }

        public Utente GetByID(string ID)
        {
            throw new NotImplementedException();
        }

        public bool Update(Utente obj)
        {
            throw new NotImplementedException();
        }
    }
}
