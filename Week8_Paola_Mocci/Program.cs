using System;
using System.Collections.Generic;
using Rubrica.Core;
using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryADO;
using Rubrica.RepositoryMock;

namespace Week8_Paola_Mocci
{
    class Program
    {

        //private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattoMock(), new RepositoryIndirizzoMock());
       private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattoADO(), new RepositoryIndirizzoADO());


        static void Main(string[] args)
        {

                   

        bool continua = true;



            while (continua == true)
            {

                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }



        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {

                case 1:
                    VisualizzaContatti();

                    break;

                case 2:

                    InserisciContatto();

                    break;

                case 3:
                    AggiungiIndirizzo();

                    break;

                case 4:

                    EliminaContatto();

                    break;

                case 0:
                    return false;

            }
            return true;
        

        }

        private static void EliminaContatto()
        {
            int id;
            do
            {
                Console.WriteLine("Quale contatto si vuole eliminare?:");
                VisualizzaContatti();
            }
            while (!(int.TryParse(Console.ReadLine(), out id)));//TODO: controllare che esista in lista

            Esito e = bl.EliminaContatto(id);

            Console.WriteLine(e.Messaggio);

        }

        private static void AggiungiIndirizzo()
        {
            string tipologia, via, citta, provincia, nazione;
            int idContatto, cap;

            do
            {
                Console.WriteLine("A quale ID contatto si vuole associare l'indirizzo?:");
            VisualizzaContatti();
            }
            while (!(int.TryParse(Console.ReadLine(), out idContatto)));//TODO: controllare che esista in lista

            Console.WriteLine("Inserire la tipologia del nuovo indirizzo:");
            tipologia = Console.ReadLine();           
            Console.WriteLine("Inserire la via del nuovo indirizzo:");
            via = Console.ReadLine();
            Console.WriteLine("Inserire la città del nuovo indirizzo:");
            citta = Console.ReadLine();
            Console.WriteLine("Inserire la provincia del nuovo indirizzo");
            provincia = Console.ReadLine();
            Console.WriteLine("Inserire la nazione del nuovo indirizzo:");
            nazione = Console.ReadLine();
            do
            {
                Console.WriteLine("Inserire il CAP del nuovo indirizzo:");
            }
            while (!(int.TryParse(Console.ReadLine(), out cap)));
                         
            Indirizzo indirizzo = new Indirizzo(tipologia, via, citta, cap, provincia, nazione, idContatto);

            Esito esito = bl.AddIndirizzo(indirizzo);
            Console.WriteLine(esito.Messaggio);

            Console.WriteLine(indirizzo);

        }

        private static void InserisciContatto()
        {
            string nome, cognome;
            
            Console.WriteLine("Inserire il nome del nuovo contatto:");
            nome = Console.ReadLine();           
            Console.WriteLine("Inserire il cognome del nuovo contatto:");
            cognome = Console.ReadLine();

            Contatto contatto = new Contatto(nome, cognome);

            Esito esito = bl.AddContatto(contatto);
            Console.WriteLine(esito.Messaggio);

        }

        private static void VisualizzaContatti()
        {
            List<Contatto> listaContatti = new List<Contatto>();

            listaContatti = bl.GetAll();

            foreach (var item in listaContatti)
            {
                Console.WriteLine(item);
            }



        }

        private static int SchermoMenu()
        {
            Console.WriteLine("***********Benvenuto nella tua Rubrica!**********");
            Console.WriteLine("1. Visualizza tutti i contatti.");
            Console.WriteLine("2. Inserisci un nuovo contatto.");
            Console.WriteLine("3. Inserisci un nuovo indirizzo.");
            Console.WriteLine("4. Elimina un contatto.");
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("****************************");
            int scelta;
            Console.WriteLine("Inserisci la tua scelta.");
            while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4))
            {
                Console.WriteLine("Scelta errata! Inserisci scelta corretta.");
            }

            return scelta;
        }
    }
}
