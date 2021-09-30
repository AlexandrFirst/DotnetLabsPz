using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class Notifications
    {
        public void TextMessage(string message) => Console.WriteLine(message);

        public void ColourfulMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void CapsMesssage(string message) => Console.WriteLine(message.ToUpper());
    }
}
