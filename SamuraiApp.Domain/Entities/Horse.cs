﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain.Entities
{
   public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Samurai Samurai { get; set; }
    }
}