using System;
using System.Diagnostics;
using Gioco.ADORepository;
using Gioco.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gioco
{
    class Program
    {
        static void Main(string[] args)

        {
            // Creazione Timer di gioco

            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //watch.Stop();
            //Console.WriteLine("Itarativo: {0}", watch.ElapsedMilliseconds);

            //Variabili
            string Nome = "";
            int flag;
            string IDUT="";
            //Inizio gioco:
            Console.WriteLine("Benvenuto al gioco Eroe VS Mostri scegli cosa vuoi fare?\n");
            Console.WriteLine("1)Crea nuovo utente");
            Console.WriteLine("2)Utilizza utente esistente\n");
            int scelta = Convert.ToInt32(Console.ReadLine());
           
            if (scelta == 1)
            {
                
                do
                {
                    // Riporto il valore del flag a 0 per il secondo giro eventuale
                    flag = 0;

                    //Scelta utente inserire nomeUtente
                    Console.WriteLine("Nome Utente: ");
                    Nome = Console.ReadLine();

                    //Controllo che non esista un utente nel DB con stesso nome inserito per nuovo utente
                    var serviceProvider = DIConfiguration.ConfigurazioneUtente();
                    UtenteServices giocoService = serviceProvider.GetService<UtenteServices>();
                    var utente = giocoService.GetAll();

                    foreach (var ute in utente)
                    {
                        if (Nome == ute.ID)
                        {
                            Console.WriteLine("\nUtente già esistente!");
                            Console.WriteLine("Scegli un altro nome:\n");
                            flag = 1;
                            break;
                        }
                    }
                    // Controllo con un flag che non entri se esiste utente 
                    if (flag == 0)
                    {
                        var serviceProviderCreate = DIConfiguration.ConfigurazioneUtente();
                        UtenteServices giocoServiceCreate = serviceProvider.GetService<UtenteServices>();
                        var utente1 = giocoService.CreateUtente(new Core.Entità.Utente(), Nome);

                        // Mi salvo il nome Utente inserito
                        IDUT = Nome;
                    }
                } while (flag == 1);


                //Partita:
               

                Console.WriteLine("Scegli cosa vuoi fare?");
                Console.WriteLine("1)Crea nuovo eroe");
                Console.WriteLine("2)Continuare la partita con eroe esistente");
                Console.WriteLine("3)Eliminare un eroe");
                Console.WriteLine("4)Uscire gioco");
                int scelta2 = Convert.ToInt32(Console.ReadLine());
                if (scelta2 == 1)
                {
                    Console.WriteLine("Inserire nome eroe:");
                    string NomeEroe = Console.ReadLine();
                    var serviceProviderEroe = DIConfiguration.ConfigurazioneEroe();
                    EroeServices giocoServiceEroe = serviceProviderEroe.GetService<EroeServices>();
                    var eroe = giocoServiceEroe.CreateEroe(new Core.Entità.Eroe(), NomeEroe, IDUT);
                }


            }


        }
    }
}
