using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestEFCore.Entities;
using TestEFCore.UnitsOfWork;

namespace TestEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cassette cassette1 = new Cassette {Amount = 1 };
            //Cassette cassette4 = new Cassette {Amount = 4 };
            //Cassette cassette3 = new Cassette {Amount = 3 };

            /*using (UnitOfWork unit = new UnitOfWork(new VideoLibraryDbContext()))
            {
                
                //unit.CasseteRep.Add(cassette1);
                //unit.CasseteRep.Add(cassette3);
                //unit.CasseteRep.Add(cassette4);
                //unit.Save();

                IList<Cassette> allCassettes = unit.CassetteRep.GetAll().ToList();

                Console.WriteLine("All cassettes:");
                foreach (var cassette in allCassettes)
                    Console.WriteLine($"Cassette id={cassette.Id}, amount={cassette.Amount}");

                IList<Cassette> minCassettes = unit.CassetteRep.GetCassettesMin(3).ToList();
                Console.WriteLine("Cassettes which have amount < 3 :");
                foreach (var cassette in minCassettes)
                    Console.WriteLine($"Cassette id={cassette.Id}, amount={cassette.Amount}");

                IList<Cassette> maxCassettes = unit.CassetteRep.GetCassettesMax(3).ToList();
                Console.WriteLine("Cassettes which have amount >= 3 :");
                foreach (var cassette in maxCassettes)
                    Console.WriteLine($"Cassette id={cassette.Id}, amount={cassette.Amount}");

            }*/
        }
    }
}
