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
            QueryFilters();

        }

        private static void QueryFilters()
        {
            // we have creates sperated variable to write prevent write hard code in sql 
            // but create @param name
            var name = "Mahmoud";
            // var samurai = _context.Samurais.Where(s => s.Name == name).ToList();
            // we can replace file with Like function 
            //var samurai = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "M")).ToList();
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Mahmoud" };
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
