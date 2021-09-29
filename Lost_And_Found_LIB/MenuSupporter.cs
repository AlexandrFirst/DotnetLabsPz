using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class MenuSupporter
    {
        public static void DrawMenu(Office office)
        {
            Console.WriteLine("Welcome to lost and found!!");
            Console.WriteLine("-------------------------------------------------------");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please select one of the following options:");
                Console.WriteLine("1)Obtain a new item");
                Console.WriteLine("2)Extradict the item");
                Console.WriteLine("3)List all extradictions");
                Console.WriteLine("4)List all obtainings");
                Console.WriteLine("5)quit");
                Console.WriteLine();
                var input = Console.ReadKey(true).KeyChar;
                switch (input)
                {
                    case '1':
                        MyActions.ObtainAction(office);
                        break;
                    case '2':
                        MyActions.ExtradictAction(office);
                        break;
                    case '3':
                        MyActions.DisplayAllExtradictions(office);
                        break;
                    case '4':
                        MyActions.DisplayAllObtainings(office);
                        break;
                }
            }
        }
    }
}
