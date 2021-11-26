using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryADO;
using System;
using Xunit;

namespace Rubrica.Test
{


    public class Tests
    {

        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattoADO(), new RepositoryIndirizzoADO());

        [Fact]

        //Test per vedere se mi fa aggiungere un utente con ID già esistente
        public void Test1()
        {
            //ARRANGE
            Contatto contatto = new Contatto();
            contatto.Id = 1004;
            //ACT
            Esito esito = bl.AddContatto(contatto);
            //ASSERT
            Assert.Equal(esito.IsOk, false);


        }



        }
    }
}
