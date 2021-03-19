using System;
using System.Collections.Generic;
using Gioco.Core.Entità;
using Gioco.Core.Interfaces;

namespace Gioco.Services
{
    public class UtenteServices
    {
        private IUtenteRepository _repo;

        

        public UtenteServices(IUtenteRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Utente> GetAllUtenti()
        {
            return _repo.GetAll();
        }
        public Utente GetUtenteByID(string id)
        {
            //logica di "buisness"
            if (id !=null)
            {
                return _repo.GetByID(id);
            }
            return null;
        }
        public Utente CreateUtente(Utente m, string nom)
        {
            if (m != null)
            {
                _repo.Create(m,nom);
                return m;
            }
            else
                return null;
        }

    }

}
