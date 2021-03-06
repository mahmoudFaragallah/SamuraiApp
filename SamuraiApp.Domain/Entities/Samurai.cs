using SamuraiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SamuraiApp.Domain
{
    public class Samurai
    {
        public Samurai()
        {
            QuotesSamurais = new List<Quote>();
            SamuraiBattles = new List<SamuraiBattle>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<Quote> QuotesSamurais { get; set; }
        public Clan Clan { get; set; }
        public List<SamuraiBattle> SamuraiBattles { get; set; }
        
        public Horse Horse { get; set; }
    }
}
