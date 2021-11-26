using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrica.RepositoryMock
{
    public class RepositoryIndirizzoMock : IRepositoryIndirizzo
    {

        public List<Indirizzo> listaIndirizzi = new List<Indirizzo>();
        public Indirizzo Add(Indirizzo item)
        {
            if (listaIndirizzi.Count == 0)
            {
                item.Id = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var c in listaIndirizzi)
                {
                    if (c.Id > maxId)
                    {
                        maxId = c.Id;
                    }
                }

                item.Id = maxId + 1;
            }


            listaIndirizzi.Add(item);
            return item;
        }

        public List<Indirizzo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Indirizzo GetById(int id)
        {
            foreach (var item in listaIndirizzi)
            {
                if (item.Id == id)
                {
                    return item;
                }

            }
            return null;
        }

        public List<Indirizzo> GetByIdContatto(int id)
        {

            List<Indirizzo> indirizzi = new List<Indirizzo>();

            foreach (var item in listaIndirizzi)
            {
                if (item.IdContatto == id)
                {
                    indirizzi.Add(item);
                }

            }
            return indirizzi;
        }
    }
}
