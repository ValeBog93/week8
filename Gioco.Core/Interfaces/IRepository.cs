using System;
using System.Collections.Generic;
using System.Text;
using Gioco.Core.Entità;

namespace Gioco.Core.Interfaces
{
    public interface IRepository<T>
    {
        //CRUD:
        //Create
        void CreateER(T obj,string nom,string u);
        void Create(T obj, string nom);
        //Read
        T GetByID(string ID);
        IEnumerable<T> GetAll();
        //Update
        bool Update(T obj);
        //Delete
        bool Delete(T obj);
    }
}
