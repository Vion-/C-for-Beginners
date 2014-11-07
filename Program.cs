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
                byte menu = 0;

                if (login == "Check Passed!")
                {
                    //class used to display different menus 
                    MenuDisplayClass menuDisplay = new MenuDisplayClass();
                    //option 4 = exit program
                    while (menu != 4)
                    {
                        menuDisplay.MainMenu();
                        menu = byte.Parse(Console.ReadLine());
                        switch (menu)
                        {
                            case 1:
                                menuDisplay.VehicleTypeMenu();
                                menu = byte.Parse(Console.ReadLine());
                                switch (menu)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        break;
                                    case 3:
                                        break;
                                    default:
                                        menu = 0;
                                        break;
                                }
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
