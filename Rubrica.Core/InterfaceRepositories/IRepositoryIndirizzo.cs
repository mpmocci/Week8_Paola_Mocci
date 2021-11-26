using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrica.Core.InterfaceRepositories
{
    public interface IRepositoryIndirizzo : IRepository<Indirizzo>
    {
        Indirizzo GetById(int id);

        List<Indirizzo> GetByIdContatto(int id);
    }
}
