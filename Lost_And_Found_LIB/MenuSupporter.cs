using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class MenuSupporter
    {
        private Office office;
        public Office Office
        {
            get => office;
            set => office = value;
        }
        public delegate void MenuAction<T>(T param) where T : Office;
        public Dictionary<char, MenuAction<Office>> menuMethods;
        public MenuSupporter(Office office)
        {
            this.Office = office;
            menuMethods = new Dictionary<char, MenuAction<Office>>();
            menuMethods.Add('1', MyActions.ObtainAction);
            menuMethods.Add('2', MyActions.ExtradictAction);
            menuMethods.Add('3', MyActions.DisplayAllExtradictions);
            menuMethods.Add('4', MyActions.DisplayAllObtainings);
            menuMethods.Add('5', MyActions.AddColourfulMessageNotification);
            menuMethods.Add('6', MyActions.AddCapsMessageNotification);
            menuMethods.Add('7', MyActions.RemoveColourfulMessageNotification);
            menuMethods.Add('8', MyActions.RemoveCapsMessageNotification);
        }
        public void DrawMenu()
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
                Console.WriteLine("5)Chain ColourfulNotification");
                Console.WriteLine("6)Chain CapsNotification");
                Console.WriteLine("7)UnChain ColorfulNotification");
                Console.WriteLine("8)Unchain CapsNotification");
                Console.WriteLine("0)quit");
                Console.WriteLine();
                var input = Console.ReadKey(true).KeyChar;
                if (input == '0')
                    System.Environment.Exit(0);
                else
                    menuMethods[input]?.Invoke(Office);
            }
        }

        public static void DrawOldMenu(Office office)
        {
            Notifications notifications = new Notifications();
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
                Console.WriteLine("5)Chain ColourfulNotification");
                Console.WriteLine("6)Chain CapsNotification");
                Console.WriteLine("7)UnChain ColorfulNotification");
                Console.WriteLine("8)Unchain CapsNotification");
                Console.WriteLine("0)quit");
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
                    case '5':
                        office.Storage.NotifyEvent += notifications.ColourfulMessage;
                        Console.WriteLine("You have successfully chained a ColorfulMessage method");
                        break;
                    case '6':
                        office.Storage.NotifyEvent += notifications.CapsMesssage;
                        Console.WriteLine("You have successfully chained a CapsMessage method");
                        break;
                    case '7':
                        office.Storage.NotifyEvent -= notifications.ColourfulMessage;
                        Console.WriteLine("You have successfully unchained a ColourfulMessage method");
                        break;
                    case '8':
                        office.Storage.NotifyEvent -= notifications.CapsMesssage;
                        Console.WriteLine("You have successfully unchained a CapsMessage method");
                        break;
                    case '0':
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
