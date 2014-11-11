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
                //Beginning of Menu display
                //-----------------------------------------------------------------------
                //-----------------------------------------------------------------------

                //used to navigate menu options
                string menu = string.Empty;
                int Menu = 0;

                if (login == "Check Passed!")
                {
                    //class used to display different menus 
                    MenuDisplayClass menuDisplay = new MenuDisplayClass();
                    //Collection of cars
                    List<Car> carsList = new List<Car>();
                    //obtain user input and attempts to parse to int (to avoid exeption in case of string input)
                    menu = Console.ReadLine();
                    int.TryParse(menu, out Menu);
                    //option 4 = exit program
                    while (Menu != 4)
                    {
                        menuDisplay.MainMenu();
                        //obtain user input and attempts to parse to int (to avoid exeption in case of string input)
                        menu = Console.ReadLine();
                        int.TryParse(menu, out Menu);
                        switch (Menu)
                        {
                            case 1:
                                menuDisplay.VehicleTypeMenu();
                                //obtain user input and attempts to parse to int (to avoid exeption in case of string input)
                                menu = Console.ReadLine();
                                int.TryParse(menu, out Menu);
                                switch (Menu)
                                {
                                    case 1:
                                        //Obtain car details and adds it as an instance of car class to car collection
                                        menuDisplay.CarDetailsMenu(carsList);
                                        break;
                                    case 2:
                                        break;
                                    case 3:
                                        break;
                                    default:
                                        Menu = 0;
                                        break;
                                }
                                break;
                            case 2:
                                foreach (Car car in carsList)
                                {
                                    Console.WriteLine("{0} {1} {2} {3} {4}", car.Make, car.Model, car.Price, car.Year, car.CarType);
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
