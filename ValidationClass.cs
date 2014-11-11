using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class ValidationClass
    {
        private string text {get; set;}
        //copy = 1 if "Username" heading found on txt. copy = 2 if "Password" heading found. 
        //copy = 0 if neither are found
        private byte copy { get; set; }
        //True = username check passed
        private bool usernamePassed {get; set;}
        //True = password check passed
        private bool passwordPassed {get; set;}
        //Name of file containing username & password (which is assigned value in constructor)
        private string file { get; set; }    

        //Class constructor
        public ValidationClass()
        {
            copy = 0;
            usernamePassed = false;
            passwordPassed = false;
        }

        public  string Validate (string username, string password, StreamReader userValidation)
        {
            text = userValidation.ReadLine();
            while (text != null)
            {
                //Will execute when below IFs are true
                if (copy != 0)
                {
                    switch (copy)
                    {
                        case 1:
                            if (text == username)
                                usernamePassed = true;
                            copy = 0;
                            break;
                        case 2:
                            if (text == password)
                                passwordPassed = true;
                            copy  = 0;
                            break;
                        default:
                            break;
                    }
                }
                if (text.ToUpper() == "USERNAME")
                    copy = 1;
                //Above IFs will only execute if this is true
                if (text.ToUpper() == "PASSWORD")
                    copy = 2;
                text = userValidation.ReadLine();
            }
            //Validates if both username and password checks were passed
            switch (usernamePassed && passwordPassed)
            {
                case true:
                    return "Check Passed!";
                default:
                    return "Check Failed!";
            }
        }
    }
}
