using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Gioco.Core;
using Gioco.Core.Entità;

namespace Gioco.ADORepository.Extensions
{
    public static class SqlDataReaderExtension
    {
        public static Utente ToUtente(this SqlDataReader reader)
        {
            return new Utente()
            {
                ID = reader["ID"].ToString(),

            };
        }
        public static Eroe ToEroe(this SqlDataReader reader)
        {
            return new Eroe()
            {
                ID = reader["ID"].ToString(),
                UtenteID = reader["UtenteID"].ToString(),
                Classe = reader["Classe"].ToString(),
                Arma = reader["Arma"].ToString(),
                Livello = (int)reader["Livello"],
                PuntiAccumulati = (int)reader["PuntiAccumulati"],
                PuntiVita = (int)reader["PuntiVita"],
                TempoTotGioco = (Stopwatch)reader["TempoTotGioco"]

            };
        }
        public static Mostro ToMostro(this SqlDataReader reader)
        {
            return new Mostro()
            {
                NomeMostro = reader["ID"].ToString(),
                ClasseMostro = reader["UtenteID"].ToString(),
                ArmaMostro = reader["Classe"].ToString(),
                LivelloMostro = (int)reader["PuntiAccumulati"],
                PuntiVitaMostro = (int)reader["PuntiVita"],
               
            };
        }
    }
}
