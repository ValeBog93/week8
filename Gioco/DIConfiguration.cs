using System;
using System.Collections.Generic;
using System.Text;
using Gioco.ADORepository;
using Gioco.Core.Interfaces;
using Gioco.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gioco
{
    public class DIConfiguration
    {
        //Provider generico di Servizi
        public static ServiceProvider ConfigurazioneUtente()
        {
            return new ServiceCollection()
                //Agguingendo i miei servizi
                .AddTransient<UtenteServices>()

                //Agguingendo un "servizio" cha mappa l'astrazione     
                .AddTransient<IUtenteRepository, ADOUtenteRepository>()
                .BuildServiceProvider();
        }

        public static ServiceProvider ConfigurazioneEroe()
        {
            return new ServiceCollection()
                //Agguingendo i miei servizi
                .AddTransient<EroeServices>()

                //Agguingendo un "servizio" cha mappa l'astrazione     
                .AddTransient<IEroeRepositorycs, ADOEroeRepository>()
                .BuildServiceProvider();
        }

    }
}
