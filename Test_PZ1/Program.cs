using LostAndFound_LIB;
using System;

namespace Test_PZ1
{
    class Program
    {
        static void Main(string[] args)
        {
            Office office = Seeder.Seed();
            office.printCountOfThingsByKeyWords();
            Console.ReadKey();
        }
    }
}
