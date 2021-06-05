using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
  public  class SamuraiBattle
    {
        public int SamuraiId { get; set; }
        public int BattleId { get; set; }

        // This nvaigation for only coding convenience
        public Samurai Samurai { get; set; }
        public Battle Battle { get; set; }
    }
}
