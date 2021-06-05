using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.Model;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext(); 
        static void Main(string[] args)
        {

            _context.Database.EnsureCreated();
            //GetSamurai("Before Add:");
            //AddSamurai();
            //GetSamurai("After Add:");
            //Console.WriteLine("Press any key...");
            //Console.ReadKey();
            //QueryFilters();
            //RetrieveAndUpdateSamurai();
            RetrieveAndUpdateMultipleSamurai();

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
            var samurai = new Samurai { Name = "Ahmed",HorseId = 2};
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
    }
}
