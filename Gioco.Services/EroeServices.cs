using System;
using System.Collections.Generic;
using System.Text;
using Gioco.Core;
using Gioco.Core.Entità;
using Gioco.Core.Interfaces;

namespace Gioco.Services
{
    public class EroeServices
    {
        private IEroeRepositorycs _repo;



        public EroeServices(IEroeRepositorycs repo)
        {
            _repo = repo;
        }
        public IEnumerable<Eroe> GetAllEroi()
        {
            return _repo.GetAll();
        }
        public Eroe GetEroeByID(string id)
        {
            //logica di "buisness"
            if (id != null)
            {
                return _repo.GetByID(id);
            }
            return null;
        }
        public Eroe CreateEroe(Eroe m, string nom, string u)
        {
            if (m != null)
            {
                _repo.CreateER(m, nom, u);
                return m;
            }
            else
                return null;
        }

    }
}
