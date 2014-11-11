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

        public void CarDetailsMenu(List<Car> carsList)
        {
            Console.Clear();
            //generic instance for car 
            Car generic = new Car();
            Console.WriteLine("Car details \n=========================\n");
            Console.WriteLine("Make: ");
            generic.Make = Console.ReadLine();
            Console.WriteLine("Model: ");
            generic.Model = Console.ReadLine();
            Console.WriteLine("Year: ");
            generic.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Price: ");
            generic.Price = int.Parse(Console.ReadLine());
            Console.WriteLine("Car Type (Sedan, Hatchback, Coupe, Convertible): ");
            //Attempts to convert user value to carTypeEnum value
            string carType;
            carType = Console.ReadLine();
            carTypeEnum convertedValue;
            if (Enum.TryParse<carTypeEnum>(carType, true, out convertedValue))
                generic.CarType = convertedValue;
            else
            {
                Console.WriteLine("Car type not recognized. Defaulting to \" Unknown \"");
                generic.CarType = carTypeEnum.Unknown;
                Console.ReadLine();
            }
            carsList.Add(generic);
        }

    }
}
