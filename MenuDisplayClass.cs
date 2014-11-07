using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MenuDisplayClass
    {
        public void MainMenu ()
        {
            Console.Clear();
            Console.WriteLine("Main Menu \n=========================\n");
            Console.WriteLine("1. Insert Vehicle Details \n2. Under Construction \n3. Under Construction \n4. Exit");
            Console.WriteLine("\nGo to option:  ");
        }
        public void VehicleTypeMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose Vehicle Type \n=========================\n");
            Console.WriteLine("1. Car \n2. Motorbike \n3. Lorrie \n4. Cancel");
            Console.WriteLine("\nOption:  ");
        }

        public void ExitMessage ()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using our system!");
            Console.ReadLine();
        }
        public void OptionNotAvailableMessage()
        {
            Console.Clear();
            Console.WriteLine("Option not available");
            Console.ReadLine();
        }
    }
}
