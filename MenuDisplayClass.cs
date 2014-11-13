using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MenuDisplayClass
    {
        public int MainMenu ()
        {
            string selection;
            int Selection;
            Console.Clear();
            Console.WriteLine("Main Menu \n=========================\n");
            Console.WriteLine("1. Insert Vehicle Details \n2. Display all added vehicles \n3. Perform Query \n4. Exit");
            Console.WriteLine("\nGo to option:  ");
            selection = Console.ReadLine();
            int.TryParse(selection, out Selection);
            return Selection;
        }
        public int VehicleTypeMenu()
        {
            string selection;
            int Selection;
            Console.Clear();
            Console.WriteLine("Choose Vehicle Type \n=========================\n");
            Console.WriteLine("1. Car \n2. Motorbike \n3. Lorrie \n4. Cancel");
            Console.WriteLine("\nOption:  ");
            selection = Console.ReadLine();
            int.TryParse(selection, out Selection);
            return Selection;
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
        public void MotorbikeDetailsMenu(List<Motobike> bikesList)
        {
            Console.Clear();
            //generic instance for car 
            Motobike generic = new Motobike();
            Console.WriteLine("Bike details \n=========================\n");
            Console.WriteLine("Make: ");
            generic.Make = Console.ReadLine();
            Console.WriteLine("Model: ");
            generic.Model = Console.ReadLine();
            Console.WriteLine("Year: ");
            generic.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Price: ");
            generic.Price = int.Parse(Console.ReadLine());
            Console.WriteLine("Twin Spark? (true, false): ");
            //Attempts to convert user value to carTypeEnum value
            string twinSpark;
            twinSpark = Console.ReadLine();
            bool boolTwinSpark;
            if (bool.TryParse(twinSpark, out boolTwinSpark))
                generic.TwinSpark = boolTwinSpark;
            else
            {
                Console.WriteLine("Spark type not recognized. Defaulting to \" False \"");
                generic.TwinSpark = false;
                Console.ReadLine();
            }
             bikesList.Add(generic);
        }
        public void LorrieDetailsMenu(List<Lorrie> lorrieList)
        {
            Console.Clear();
            //generic instance for car 
            Lorrie generic = new Lorrie();
            Console.WriteLine("Lorrie details \n=========================\n");
            Console.WriteLine("Make: ");
            generic.Make = Console.ReadLine();
            Console.WriteLine("Model: ");
            generic.Model = Console.ReadLine();
            Console.WriteLine("Year: ");
            generic.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Price: ");
            generic.Price = int.Parse(Console.ReadLine());
            Console.WriteLine("Carry Load: ");
            generic.CarryLoad = int.Parse(Console.ReadLine());
            lorrieList.Add(generic);
        }

        public void DisplayAllVehicle (List<Car> carsList, List<Motobike> bikesList, List<Lorrie> lorrieList)
        {
            Console.Clear();
            Console.WriteLine("Vehicles in Memory \n=========================");
            Console.WriteLine("\n---Cars---\n");
            foreach (Car car in carsList)
            {
                Console.WriteLine("Make: {0} Model: {1} Price: {2} Year: {3} Type: {4}", car.Make, car.Model, car.Price, car.Year, car.CarType);
            }
            Console.WriteLine("\n---Bikes---\n");
            foreach (Motobike bike in bikesList)
            {
                Console.WriteLine("Make: {0} Model: {1} Price: {2} Year: {3} Twin Spark? {4}", bike.Make, bike.Model, bike.Price, bike.Year, bike.TwinSpark);
            }
            Console.WriteLine("\n---Lorries---\n");
            foreach (Lorrie lorrie in lorrieList)
            {
                Console.WriteLine("Make: {0} Model: {1} Price: {2} Year: {3} Carry Load: {4}", lorrie.Make, lorrie.Model, lorrie.Price, lorrie.Year, lorrie.CarryLoad);
            }
            Console.ReadLine();
        }
        public int QueryRequest()
        {
            string selection;
            int Selection;

            Console.Clear();
            Console.WriteLine("Query Request \n=========================");
            Console.WriteLine("1. Select \n2. Delete");
            selection = Console.ReadLine();
            int.TryParse(selection, out Selection);
            if ((Selection != 1) && (Selection != 2))
            {
                Console.WriteLine("Option not available, defaulting to Selection");
                Selection = 1;
                Console.ReadLine();
            }
            return Selection;
        }
       public void RemovalQuery (int queryRequest, List<Car> carsList,string vehicleMake)
       {
           if (queryRequest == 2)
           {
               carsList.RemoveAll((x) => x.Make.ToUpper() == vehicleMake);
               Console.WriteLine("\n All vehicles deleted");
           }
       }
       public void RemovalQuery2 (int queryRequest, List<Motobike> bikesList, string vehicleMake)
       {
           if (queryRequest == 2)
           {
               bikesList.RemoveAll((x) => x.Make.ToUpper() == vehicleMake);
               Console.WriteLine("\n All vehicles deleted");
           }
       }
       public void RemovalQuery3(int queryRequest, List<Lorrie> lorrieList, string vehicleMake)
       {
           if (queryRequest == 2)
           {
               lorrieList.RemoveAll((x) => x.Make.ToUpper() == vehicleMake);
               Console.WriteLine("\n All vehicles deleted");
           }
       }
    }
}
