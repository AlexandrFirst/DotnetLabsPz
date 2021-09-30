using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class Notifications
    {

        public static List<Notifications> createdCapsNotifications = new List<Notifications>();
        public static List<Notifications> createdColourfulNotifications = new List<Notifications>();

        public static Notifications AddCapsNotification()
        {
            Notifications notifications = new Notifications();
            createdCapsNotifications.Add(notifications);
            return notifications;
        }
        public static Notifications AddColourfulNotification()
        {
            Notifications notifications = new Notifications();
            createdColourfulNotifications.Add(notifications);
            return notifications;
        }
        public static Notifications RemoveCapsNotification()
        {
            if (createdCapsNotifications.Count != 0)
            {
                var notification = createdCapsNotifications[createdCapsNotifications.Count - 1];
                createdCapsNotifications.RemoveAt(createdCapsNotifications.Count - 1);
                return notification;
            }
            else
                return null;
        }
        public static Notifications RemoveColourfulNotification()
        {
            if (createdColourfulNotifications.Count != 0)
            {
                var notification = createdColourfulNotifications[createdColourfulNotifications.Count - 1];
                createdColourfulNotifications.RemoveAt(createdColourfulNotifications.Count - 1);
                return notification;
            }
            else
                return null;
        }
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
