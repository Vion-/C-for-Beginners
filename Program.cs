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
