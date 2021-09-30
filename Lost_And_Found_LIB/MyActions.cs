using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost_And_Found_LIB
{
    public class MyActions
    {
        public static void ObtainAction<T>(T param) where T : Office
        {
            param.Storage.Obtain(DateTime.Now,
                                    param.MyStorage.Workers.GetRandom(),
                                    param.MyStorage.Findings.GetRandom(),
                                    param.MyStorage.Finders.GetRandom());
        }
        public static void ExtradictAction<T>(T param) where T: Office
        {
            param.Storage.Extradict(DateTime.Now,
                                     param.MyStorage.Workers.GetRandom(),
                                     param.MyStorage.Findings.GetRandom(),
                                     param.MyStorage.Owners.GetRandom());
        }
        public static string GetPersonFullName(Person person) =>
            person.Name + " " + person.Surname;
        public static void DisplayAllObtainings<T>(T param) where T : Office
        {
            Console.WriteLine("Things obtained: ");
            Console.WriteLine("        Time        |         Finder      |       Finding      |        Worker       ");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            foreach(var obtainedThing in param.Storage.Obtainings)
            {
                Console.WriteLine("{0}|{1}|{2}|{3}",obtainedThing.ActTime.TimeOfDay.ToString().FitWithLength(),
                                                    GetPersonFullName(obtainedThing.Finder).FitWithLength(),
                                                    obtainedThing.Finding.Name.FitWithLength(),
                                                    GetPersonFullName(obtainedThing.Worker).FitWithLength());
            }
        }
        public static void DisplayAllExtradictions<T>(T param) where T: Office 
        {
            Console.WriteLine("Things extradicted: ");
            Console.WriteLine("        Time        |         Owner      |       Finding      |        Worker       ");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            foreach (var obtainedThing in param.Storage.Extradictions)
            {
                Console.WriteLine("{0}|{1}|{2}|{3}", obtainedThing.ActTime.TimeOfDay.ToString().FitWithLength(),
                                                    GetPersonFullName(obtainedThing.Owner).FitWithLength(),
                                                    obtainedThing.Finding.Name.FitWithLength(),
                                                    GetPersonFullName(obtainedThing.Worker).FitWithLength());
            }
        }
        public static void AddColourfulMessageNotification<T>(T param)where T :Office
        {
            Notifications notifications = Notifications.AddColourfulNotification();
            param.Storage.NotifyEvent += notifications.ColourfulMessage;
            Console.WriteLine("You have successfully chained a ColorfulMessage method");
        }
        public static void AddCapsMessageNotification<T>(T param) where T : Office
        {
            Notifications notifications = Notifications.AddCapsNotification();
            param.Storage.NotifyEvent += notifications.CapsMesssage;
            Console.WriteLine("You have successfully chained a CapsMessage method");
        }
        public static void RemoveColourfulMessageNotification<T>(T param) where T : Office
        {
            Notifications notifications = Notifications.RemoveColourfulNotification();
            if (notifications == null)
                return;
            param.Storage.NotifyEvent -= notifications.ColourfulMessage;
            Console.WriteLine("You have successfully unchained a ColorfulMessage method");
        }
        public static void RemoveCapsMessageNotification<T>(T param) where T : Office
        {
            Notifications notifications = Notifications.RemoveCapsNotification();
            if (notifications == null)
                return;
            param.Storage.NotifyEvent -= notifications.CapsMesssage;
            Console.WriteLine("You have successfully unchained a CapsMessage method");
        }
    }
}
