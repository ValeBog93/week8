using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Gioco.Core;
using Gioco.Core.Entità;
using Gioco.Core.Interfaces;

namespace Gioco.ADORepository
{
    public class ADOEroeRepository : IEroeRepositorycs
    {
        const string connectionString = @"Persist Security Info = False; Integrated Security = true; Initial Catalog=Gioco; Server = .\SQLEXPRESS";

        public void Create(Eroe obj, string nom)
        {
            throw new NotImplementedException();
        }

        public void CreateER(Eroe obj, string nom, string u)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                string UtID = u;
                string Classe;
                string Arma="";
                int Livello = 1;
                int PuntiVita = 20;
                int PuntiAccumulati = 0;
                int TempoTotGioco = 0;
               

                Console.WriteLine("Sclegli la classe dell'eroe\n:");
                Console.WriteLine("1)Guerriero");
                Console.WriteLine("2)Mago\n");
                int scleta = Convert.ToInt32(Console.ReadLine());
                if(scleta == 1)
                {
                    Classe = "Guerriero";
                }
                else
                    Classe = "Mago";

                if(Classe== "Guerriero")
                {
                    Console.WriteLine("Sclegli la l'arma dell'eroe guerriero:");
                    Console.WriteLine("1)Ascia");
                    Console.WriteLine("2)Coltello");
                    Console.WriteLine("3)Spadone");
                    int scleta2 = Convert.ToInt32(Console.ReadLine());
                    if (scleta2 == 1)
                    {
                        Arma = "Ascia";
                    }
                    else if(scleta2 == 2)
                    {
                        Arma = "Coltello";
                    }
                    else
                        Arma = "Spadone";

                }
                else if(Classe == "Mago")
                {
                    Console.WriteLine("Sclegli la classe dell'eroe guerriero:");
                    Console.WriteLine("1)PallaFuoco");
                    Console.WriteLine("2)PallaGhiaccio");
                    Console.WriteLine("3)Bachetta");
                    int scleta2 = Convert.ToInt32(Console.ReadLine());
                    if (scleta2 == 1)
                    {
                        Arma = "PallaFuoco";
                    }
                    else if (scleta2 == 2)
                    {
                        Arma = "PallaGhiaccio";
                    }
                    else
                        Arma = "Bachetta";
                }
                



                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = connection;
                selectCommand.CommandType = System.Data.CommandType.Text;
                selectCommand.CommandText = "SELECT * FROM Eroe";

                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = connection;
                insertCommand.CommandType = System.Data.CommandType.Text;
                insertCommand.CommandText = "INSERT INTO Eroe VALUES (@UtenteID,@NomeEroe,@Classe,@Arma,@Livello,@PuntiVita,@PuntiAccumulati,@TempoTotGioco)";

                
                insertCommand.Parameters.AddWithValue("@UtenteID", UtID);
                insertCommand.Parameters.AddWithValue("@NomeEroe", nom);
                insertCommand.Parameters.AddWithValue("@Classe", Classe);
                insertCommand.Parameters.AddWithValue("@Arma", Arma);
                insertCommand.Parameters.AddWithValue("@Livello", Livello);
                insertCommand.Parameters.AddWithValue("@PuntiVita", PuntiVita);
                insertCommand.Parameters.AddWithValue("@PuntiAccumulati", PuntiAccumulati);
                insertCommand.Parameters.AddWithValue("@TempoTotGioco", TempoTotGioco);
                

                adapter.SelectCommand = selectCommand;
                adapter.InsertCommand = insertCommand;


                DataSet dataset = new DataSet();
                try
                {
                    connection.Open();
                    adapter.Fill(dataset, "Eroe");

                    DataRow utente = dataset.Tables["Eroe"].NewRow();

                    dataset.Tables["Eroe"].Rows.Add(utente);

                    adapter.Update(dataset, "Eroe");
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
        public bool Delete(Eroe obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Eroe> GetAll()
        {
            throw new NotImplementedException();
        }

        public Eroe GetByID(string ID)
        {
            throw new NotImplementedException();
        }

        public bool Update(Eroe obj)
        {
            throw new NotImplementedException();
        }
    }
}
