using System;
using System.Diagnostics;

namespace Gioco.Core.Entità
{
    public class Eroe
    {
        public string ID { get; set; }
        public string UtenteID { get; set; }
        public string Classe { get; set; }
        public string Arma { get; set; }
        public int Livello { get; set; }
        public int PuntiAccumulati { get; set; }
        public int PuntiVita { get; set; }
        public Stopwatch TempoTotGioco { get; set; }

        
    }
}
