using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrica.Core.InterfaceRepositories
{
    public interface IRepositoryContatti : IRepository<Contatto>
    {

        public Contatto GetById(int id);
        public bool Delete(Contatto item);

    }
}
