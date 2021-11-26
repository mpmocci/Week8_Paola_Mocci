using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrica.Core.Entities
{
    public class Contatto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public List<Indirizzo> ListaIndirizzi { get; set; } = new List<Indirizzo>();

        public Contatto()
        {

        }

        public Contatto(string nome, string cognome) {

            Nome = nome;
            Cognome = cognome;
        }

        public Contatto(int id, string nome, string cognome)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
        }

        public override string ToString()
        {
            return $"Id: {Id}\t{Nome}\t{Cognome}";
        }
    }
}
