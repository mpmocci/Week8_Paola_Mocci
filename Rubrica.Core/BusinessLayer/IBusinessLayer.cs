using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrica.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<Contatto> GetAll();
        Esito AddContatto(Contatto contatto);
        Esito AddIndirizzo(Indirizzo indirizzo);
        Esito EliminaContatto(int id);
    }
}
