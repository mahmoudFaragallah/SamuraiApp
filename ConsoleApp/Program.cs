using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.Model;
using SamuraiApp.Domain;
using SamuraiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext(); 
        static void Main(string[] args)
        {
            //_context.Database.EnsureCreated();
            //GetSamurai("Before Add:");
            //AddSamurai();
            //GetSamurai("After Add:");
            //Console.WriteLine("Press any key...");
            //Console.ReadKey();
            //QueryFilters();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurai();
            //RetrieveAndDeleteSamurai();
            //GetAllSamurai();
            //InsertBattle();
            //QueryAndUpdateBattle_Disconnected();
            // InsertNewSamuraiWithQuote();
            // EagerLoadSamuraiWithQuotes();
            //AddQuoteToExistingSamuraiNotTracked_Easy(8);
            //  ProjectSomeProperty();
            //ProjectSamuraiWithQuotes();
            // ExplicitLoadQuotes();
            // FilteringWithRelatedData();
            // ModifyingRealtedDataWhenTracked();
            //ModifyingRelatedDataWhenNotTracked();
            // JoinBattleAndSamurai();
            // EnlistSamuraiInfoABattle();
            //RemoveJoinBetweenSamuraiAndBattleSimple();
            // GetSamuraiWithBattles();
            //AddNewSamuraiWithHorse();
            // AddNewHorseToSamuraiUsingId();
            //AddNewHorseToSamuraiObject();
            // AddNewHorseToDisconnectedSamuraiObject();
            //ReplaceAHorse();
            // GetSamuraiWithHorse();
            // GetHorseWithSamurai();
            //GetSamuraiWithClan();
            GetClanWithSamurai();
        }

        private static void GetClanWithSamurai()
        {
            var clan = _context.Samurais.Where(e => e.Clan.Id == 1).ToList();
        }

        private static void GetSamuraiWithClan()
        {
            var samurai = _context.Samurais.Include(e => e.Clan).FirstOrDefault();
        }

        private static void GetHorseWithSamurai()
        {
            var horseWithoutSamurai = _context.Set<Horse>().Find(9);
            
            var horseWithSamurai = _context.Samurais.Include(h => h.Horse).FirstOrDefault(e => e.Horse.Id == 10);

            var horsesWithSamurais = _context.Samurais
                .Where(s => s.Horse != null)
                .Select(e => new
                {
                    Samurais = e,
                    Horse = e.Horse,
                }).ToList();
        }

        private static void GetSamuraiWithHorse()
        {
            var samurais = _context.Samurais.Include(e => e.Horse).ToList();

        }

        private static void ReplaceAHorse()
        {
            var samurai = _context.Samurais.Include(e => e.Horse).FirstOrDefault(e => e.Id == 13);
            samurai.Horse = new Horse { Name = "Roma" };
            _context.SaveChanges();
        }

        private static void AddNewHorseToDisconnectedSamuraiObject()
        {
            var samurai = _context.Samurais.AsNoTracking().FirstOrDefault(e => e.Id == 14);
            samurai.Horse = new Horse { Name = "Lola" };
            using (var newContext = new SamuraiContext())
            {
                newContext.Attach(samurai);
                newContext.SaveChanges();
            }
            Console.ReadKey();
        }

        private static void AddNewHorseToSamuraiObject()
        {
            var samurai = _context.Samurais.Find(11);
            samurai.Horse = new Horse { Name = "TOtya" };
            _context.SaveChanges();
        }

        private static void AddNewHorseToSamuraiUsingId()
        {
            var horse = new Horse { Name = "Toto", SamuraiId = 12 };
            _context.Add(horse);
            _context.SaveChanges();
        }

        private static void AddNewSamuraiWithHorse()
        {
            var samurai = new Samurai { Name = "Rami" };
            samurai.Horse = new Horse { Name = "Tornado" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamuraiWithBattles()
        {
            //var samuraiWithBattle = _context.Samurais
            //    .Include(e => e.SamuraiBattles)
            //    .ThenInclude(e => e.Battle)
            //    .FirstOrDefault(a => a.Id == 6);

            var samuraiWithBattleCleaner = _context.Samurais
                .Where(e => e.Id == 8)
                .Select(e => new
                {
                    Samurai = e,
                    Battles = e.SamuraiBattles.Select(s => s.Battle)
                }).FirstOrDefault();

            Console.ReadKey();
        }

        private static void RemoveJoinBetweenSamuraiAndBattleSimple()
        {
            var join = new SamuraiBattle { BattleId = 1, SamuraiId = 6 };
            _context.Remove(join);
            _context.SaveChanges();
            Console.ReadKey();
        }

        private static void EnlistSamuraiInfoABattle()
        {
            var battle = _context.Battles.Find(1);
            battle.SamuraiBattles.Add(new SamuraiBattle { SamuraiId = 6 });
            _context.SaveChanges();
            Console.ReadKey();
        }

        private static void JoinBattleAndSamurai()
        {
            var sbJoin = new SamuraiBattle { BattleId = 1, SamuraiId = 8};
            _context.Add(sbJoin);
            _context.SaveChanges();
        }

        private static void ModifyingRelatedDataWhenNotTracked()
        {
            var samurai = _context.Samurais.Include(e => e.QuotesSamurais).FirstOrDefault(e => e.Id == 8);
            var quote = samurai.QuotesSamurais[0];
            quote.Text += "Hello From Related data with no tracked.";

            using (var newContext = new SamuraiContext())
            {
                newContext.Entry(quote).State = EntityState.Modified;
                newContext.SaveChanges();
            }
            Console.ReadKey();
        }

        private static void ModifyingRealtedDataWhenTracked()
        {
            var samurai = _context.Samurais.Include(e => e.QuotesSamurais)
                                           .FirstOrDefault(e => e.Id == 8);
            samurai.QuotesSamurais[0].Text = "Do you hear that?";
         //   _context.QuotesSamurais.Remove(samurai.QuotesSamurais[2]);
            _context.SaveChanges();
        }

        private static void FilteringWithRelatedData()
        {
            var samurai = _context.Samurais
                                    .Where(e => e.QuotesSamurais
                                    .Any(x => x.Text.Contains("dinner")))
                                    .ToList();
            Console.ReadKey();
        }

        private static void ExplicitLoadQuotes()
        {
            var samurai = _context.Samurais.FirstOrDefault(e => e.Name.Contains("Mahmoud"));
            _context.Entry(samurai).Collection(e => e.QuotesSamurais).Load();
            _context.Entry(samurai).Reference(e => e.Horse).Load();

            Console.ReadKey();
        }

        private static void ProjectSamuraiWithQuotes()
        {
            //var somePropertyWithQuotes = _context.Samurais
            //    .Select(e => new
            //    {
            //        e.Id,
            //        e.Name,
            //        e.QuotesSamurais.Count
            //    })
            //    .ToList();
            var dinnerQuotes = _context.Samurais.Select(e => new
            {
                e.Id,
                e.Name,
                DinnerQuotes = e.QuotesSamurais.Where(x => x.Text.Contains("dinner"))
            }).ToList();
            Console.ReadKey();
        }

        private static void ProjectSomeProperty()
        {
            _context.Samurais.Select(e => new IdAndName(e.Id,e.Name)).ToList();
            Console.ReadKey();
        }
        public struct IdAndName
        {
            public IdAndName(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private static void InsertNewSamuraiWithQuote()
        {
            var samurai = new Samurai
            {
                Name = "Mahmoud",
                QuotesSamurais = new List<Quote> 
                { 
                    new Quote { Text = "I've come to save you"}
                }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
            Console.ReadKey();
        }
        private static void QueryAndUpdateBattle_Disconnected()
        {
            var battle = _context.Battles.AsNoTracking().FirstOrDefault();
            battle.EndDate = new DateTime(1560, 5, 2);
            using (var newContextInstance = new SamuraiContext())
            {
                newContextInstance.Battles.Update(battle);
                newContextInstance.SaveChanges();
            }
        }
        private static void InsertBattle()
        {
            _context.Battles.Add(new Battle
            {
                Name = "Battle of AbdElkadir",
                StartDate =new DateTime(1245,2,2),
                EndDate =new DateTime(1245,2,5)
            });
            _context.SaveChanges();
        }
        private static void GetAllSamurai()
        {
            var samurais =  _context.Samurais.ToList();
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
            Console.ReadKey();
        }
        private static void QueryFilters()
        {
            // we have creates sperated variable to write prevent write hard code in sql 
            // but create @param name
            //var name = "Mahmoud";
            // var samurai = _context.Samurais.Where(s => s.Name == name).ToList();
            // we can replace file with Like function 
            //var samurai = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "M")).ToList();
            //var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);
        }
        private static void RetrieveAndUpdateMultipleSamurai()
        {
            var samuaris = _context.Samurais.Skip(1).Take(3).ToList();
            samuaris.ForEach(e => e.Name += "San");
            _context.SaveChanges();
        }
        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
        }
        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Ahmed" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void GetSamurai(string text)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }       
        private static void RetrieveAndDeleteSamurai()
        {
            var samurai = _context.Samurais.Find(18);
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();
        }
        private static void AddQuoteToExistingSamuraiNotTracked_Easy(int samuraiId)
        {
            var quote = new Quote
            {
                Text = "Now that I saved you, will you feed me dinner again?",
                SamuraiId = samuraiId
            };
            using (var newContext = new SamuraiContext())
            {
                newContext.QuotesSamurais.Add(quote);
                newContext.SaveChanges();
            }
            Console.ReadKey();
        }
        private static void EagerLoadSamuraiWithQuotes()
        {
            var samuraiWithQuotes = _context.Samurais.Where(e => e.Name.Contains("Mahmoud")).ToList();
            //Find return or not samurai not dbSet
            var firstSamurai = _context.Samurais.Find(1);
        }
        
    }
}
