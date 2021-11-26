using System;
using System.Collections.Generic;
using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;

namespace Rubrica.RepositoryMock
{
    public class RepositoryContattoMock : IRepositoryContatti
    {

        public List<Contatto> listaContatti = new List<Contatto>();

        public Contatto Add(Contatto item)
        {

            if (listaContatti.Count == 0)
            {
                item.Id = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var c in listaContatti)
                {
                    if(c.Id > maxId)
                    {
                        maxId = c.Id;
                    }
                }

                item.Id = maxId + 1;
            }


            listaContatti.Add(item);
            return item;

        }

        public bool Delete(Contatto item)
        {
            listaContatti.Remove(item);
            return true;

        }

        public List<Contatto> GetAll()
        {



            return listaContatti;

        }

        public Contatto GetById(int id)
        {
            foreach (var item in listaContatti)
            {
                if (item.Id == id)
                {
                    return item;
                }

            }
            return null;


        }
    }
}
