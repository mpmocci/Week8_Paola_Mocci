using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrica.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {

        private readonly IRepositoryContatti contattiRepo;
        private readonly IRepositoryIndirizzo indirizziRepo;

        public MainBusinessLayer(IRepositoryContatti contatti, IRepositoryIndirizzo indirizzi)
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;
        }

        public Esito AddContatto(Contatto contatto)
        {
            Contatto newContatto = contattiRepo.GetById(contatto.Id);

            if (newContatto == null || newContatto.Id==0)
            {
                contattiRepo.Add(contatto);
                return new Esito { Messaggio = "Contatto aggiunto correttamente.", IsOk = true };
            }
            else
            {
                return new Esito { Messaggio = "Esiste già un contatto con questo ID.", IsOk = false };
            }
        }

        public Esito AddIndirizzo(Indirizzo indirizzo)
        {
            Indirizzo newIndirizzo = indirizziRepo.GetById(indirizzo.Id);


            if (newIndirizzo == null || newIndirizzo.Id ==0)
            {
                indirizziRepo.Add(indirizzo);
                Contatto contatto = contattiRepo.GetById(indirizzo.IdContatto);
                contatto.ListaIndirizzi.Add(indirizzo);

                return new Esito { Messaggio = "Indirizzo aggiunto correttamente.", IsOk = true };
            }
            else
            {
                return new Esito { Messaggio = "Esiste già un indirizzo con questo ID.", IsOk = false };
            }

        }


    

        public Esito EliminaContatto(int id)
        {
            Contatto contatto = contattiRepo.GetById(id);
            List<Indirizzo> indirizziIdContatto = indirizziRepo.GetByIdContatto(contatto.Id);

            if (contatto != null)
            {

                if (indirizziIdContatto.Count == 0)
                {
                    contattiRepo.Delete(contatto);


                    return new Esito { Messaggio = "Il contatto è stato eliminato correttamente.", IsOk = true };
                }

                else
                {
                    return new Esito { Messaggio = "Il contatto non può essere eliminato perché ha almeno un indirizzo associato.", IsOk = false};

                }
            }
            else
            {
                return new Esito { Messaggio = "Nessun contatto corrispondente all'ID inserito", IsOk = false };
            }
        }

        public List<Contatto> GetAll()
        {
            return contattiRepo.GetAll();

        }
    }
}
