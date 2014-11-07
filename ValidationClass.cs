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
        //True = "Username" heading was found on txt file and so on next loop it will compare
        //the value on file against the one provided by user
        private bool usernameCopy {get; set;}
        //True = "Password" heading was found on txt file and so on next loop it will compare
        //the value on file against the one provided by user
        private bool passwordCopy {get; set;}
        //True = username check passed
        private bool usernamePassed {get; set;}
        //True = password check passed
        private bool passwordPassed {get; set;}
        //Name of file containing username & password (which is assigned value in constructor)
        private string file { get; set; }    

        //Class constructor
        public ValidationClass()
        {
            text = "";
            usernameCopy = false;
            passwordCopy = false;
            usernamePassed = false;
            passwordPassed = false;
        }

        public  string Validate (string username, string password, StreamReader userValidation)
        {
            while (text != null)
            {
                text = userValidation.ReadLine();
                if (text != null)
                {
                    //Will execute when below IFs are true
                    if (usernameCopy == true)
                    {
                        if (text == username)
                        {
                            usernamePassed = true;
                            usernameCopy = false;
                        }
                        else
                            usernameCopy = false;
                    }
                    //Will execute when below IFs are true
                    if (passwordCopy == true)
                    {
                        if (text == password)
                        {
                            passwordPassed = true;
                            passwordCopy = false;
                        }
                        else
                            passwordCopy = false;
                    }
                    //Above IFs will only execute if this is true
                    if (text.ToUpper() == "USERNAME")
                        usernameCopy = true;
                    //Above IFs will only execute if this is true
                    if (text.ToUpper() == "PASSWORD")
                        passwordCopy = true;
                }
            }
            //Validates if both username and password checks were passed
            switch (usernamePassed && passwordPassed)
            {
                case true:
                    return "Check Passed!";
                    break;
                default:
                    return "Check Failed!";
                    break;
            }
            userValidation.Close();
        }
    }
}
