using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //-----------------------------------------------------------------------
                //-----------------------------------------------------------------------
                //Beginning of Login validation
                //-----------------------------------------------------------------------
                //-----------------------------------------------------------------------

                //Contains user provided username
                string username;
                //Contains user provided password
                string password;
                // "Check Passed!" = login validation passed
                string login = "Check Failed!";

                StreamReader userValidation = new StreamReader("Users.txt");
                Console.WriteLine("Vehicle Management System \n=========================\n");
                Console.WriteLine("Username: ");
                username = Console.ReadLine().Trim();
                Console.WriteLine("Password: ");
                password = Console.ReadLine().Trim();

                ValidationClass validateUser = new ValidationClass();
                //This method accepts the username and password entered that will be compared
                //against the one on file. It also takes the Streamreader. This class will work
                //to validate any credentials as long as the text file has the following format
                //Username
                //[Value of username]
                //Password
                //[Value of Password]
                login = validateUser.Validate(username, password, userValidation);
                Console.WriteLine(login);
                userValidation.Close();
                userValidation = null;
                validateUser = null;
                Console.ReadLine();

                //-----------------------------------------------------------------------
                //-----------------------------------------------------------------------
                //Beginning of Menu display
                //-----------------------------------------------------------------------
                //-----------------------------------------------------------------------

                //used to navigate menu options
                int Menu = 0;

                if (login == "Check Passed!")
                {
                    //class used to display different menus 
                    MenuDisplayClass menuDisplay = new MenuDisplayClass();
                    //Collection of vehicles
                    List<Car> carsList = new List<Car>();
                    List<Motobike> bikesList = new List<Motobike>();
                    List<Lorrie> lorrieList = new List<Lorrie>();
                    //obtain user input and attempts to parse to int (to avoid exeption in case of string input)
                    Console.ReadLine();
                    //option 4 = exit program
                    while (Menu != 4)
                    {
                        //obtain user input and attempts to parse to int (to avoid exeption in case of string input)
                        Menu = menuDisplay.MainMenu();
                        switch (Menu)
                        {
                            case 1:
                                //obtain user input and attempts to parse to int (to avoid exeption in case of string input)
                                Menu = menuDisplay.VehicleTypeMenu();
                                switch (Menu)
                                {
                                    case 1:
                                        //Obtain car details and adds it as an instance of car class to car collection
                                        menuDisplay.CarDetailsMenu(carsList);
                                        break;
                                    case 2:
                                        menuDisplay.MotorbikeDetailsMenu(bikesList);
                                        break;
                                    case 3:
                                        menuDisplay.LorrieDetailsMenu(lorrieList);
                                        break;
                                    default:
                                        Menu = 0;
                                        break;
                                }
                                break;
                            case 2:
                                menuDisplay.DisplayAllVehicle(carsList, bikesList, lorrieList);
                                break;
                            case 3:
                                //selected query type here : select, delete
                                int queryRequest;
                                //vehicle type for above query
                                int queryVehicle;
                                queryRequest = menuDisplay.QueryRequest();
                                queryVehicle = menuDisplay.VehicleTypeMenu();
                                if ((queryVehicle != 1) && (queryVehicle != 2) && (queryVehicle != 3))
                                {
                                    Console.WriteLine("Option not available, defaulting to Car");
                                    queryVehicle = 1;
                                    Console.ReadLine();
                                }
                                //will contain Make for vehicle search
                                string vehicleMake;
                                Console.Clear();
                                if (queryRequest == 1)
                                    Console.WriteLine("Selection Request \n=========================");
                                else
                                    Console.WriteLine("Deletion Request \n=========================");
                                Console.WriteLine("Provide vehicle Make to search by: ");
                                vehicleMake = Console.ReadLine().Trim().ToUpper();
                                Console.Clear();
                                Console.WriteLine("Query Request \n=========================");
                                switch (queryVehicle)
	                            {
                                    case 1:
                                            var carsQuery = from car in carsList
                                                            where car.Make.ToUpper() == vehicleMake
                                                            select car;
                                            foreach (var car in carsQuery)
                                            {
                                                Console.WriteLine("Make: {0} Model: {1} Price: {2} Year: {3} Type: {4}", car.Make, car.Model, car.Price, car.Year, car.CarType);
                                            }
                                        //removes the matching item from the list based on vehicleMake
                                            menuDisplay.RemovalQuery(queryRequest, carsList, vehicleMake);
                                        break;
                                    case 2:
                                        var bikeQuery = from bike in bikesList
                                                            where bike.Make.ToUpper() == vehicleMake
                                                            select bike;
                                            foreach (var bike in bikeQuery)
                                            {
                                                Console.WriteLine("Make: {0} Model: {1} Price: {2} Year: {3} Twin Spark?: {4}", bike.Make, bike.Model, bike.Price, bike.Year, bike.TwinSpark);
                                            }
                                            //removes the matching item from the list based on vehicleMake
                                            menuDisplay.RemovalQuery2 (queryRequest, bikesList, vehicleMake);
                                        break;
                                    case 3:
                                        var lorrieQuery = from lorrie in lorrieList
                                                            where lorrie.Make.ToUpper() == vehicleMake
                                                            select lorrie;
                                            foreach (var lorrie in lorrieQuery)
                                            {
                                                Console.WriteLine("Make: {0} Model: {1} Price: {2} Year: {3} Carry Load: {4}", lorrie.Make, lorrie.Model, lorrie.Price, lorrie.Year, lorrie.CarryLoad);
                                            }
                                            //removes the matching item from the list based on vehicleMake
                                            menuDisplay.RemovalQuery3 (queryRequest, lorrieList, vehicleMake);
                                        break;
		                            default:
                                        break;
	                            }
                                Console.ReadLine();
                                break;
                            case 4:
                                menuDisplay.ExitMessage();
                                break;
                            default:
                                menuDisplay.OptionNotAvailableMessage();
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Oops! Something went wrong: \n\n {0}", e);
                Console.ReadLine();
            }
        }
    }
}
