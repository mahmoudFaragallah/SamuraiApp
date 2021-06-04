using SamuraiApp.Data.Model;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext context = new SamuraiContext(); 
        static void Main(string[] args)
        {

            context.Database.EnsureCreated();
            GetSamurai("Before Add:");
            AddSamurai();
            GetSamurai("After Add:");
            Console.WriteLine("Press any key...");
            Console.ReadKey();

        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Mahmoud" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        private static void GetSamurai(string text)
        {
            var samurais = context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
