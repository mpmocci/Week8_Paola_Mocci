using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrica.Core.InterfaceRepositories
{
   public interface IRepository<T>
    {

        public List<T> GetAll();
        public T Add(T item);

        public T GetById(int id);
    }
}
