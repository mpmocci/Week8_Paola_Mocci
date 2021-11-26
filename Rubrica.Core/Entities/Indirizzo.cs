using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrica.Core.Entities
{
    public class Indirizzo
    {
        public int Id { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Città { get; set; }
        public int Cap { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }

        public int IdContatto { get; set; }

        public Contatto Contatto { get; set; }

        public Indirizzo()
        {

        }
        public Indirizzo(string tipologia, string via, string citta, int cap,string prov, string nazione, int idContatto)
        {
            Tipologia = tipologia;
            Via = via;
            Città = citta;
            Cap = cap;
            Provincia = prov;
            Nazione = nazione;
            IdContatto = idContatto;

        }


        public Indirizzo(int id, string tipologia, string via, string citta, int cap, string prov, string nazione, int idContatto)
        {
            Id = id;
            Tipologia = tipologia;
            Via = via;
            Città = citta;
            Cap = cap;
            Provincia = prov;
            Nazione = nazione;
            IdContatto = idContatto;

        }
        public override string ToString()
        {
            return $"Id: {Id}\t{Tipologia}\t{Via}\t{Città}\t{Cap}\t{Provincia}\t{Nazione}\t Id Contatto:{IdContatto}";
        }

    }
}
