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
            //Contains user provided username
            string username;
            //Contains user provided password
            string password;
            //Name of file containing username & password

            try
            {
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
                Console.WriteLine(validateUser.Validate(username, password, userValidation));
                userValidation.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! Something went wrong: \n\n {0}", e);
            }
            Console.ReadLine();
        }
    }
}
