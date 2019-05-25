using GTL.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace GTL.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connection ..

            bool userDone = false;
            string userCommand = "";

       

            try
            {
                ShowInstructions();
                do
                {
                    Write("\nPlease enter your command: ");
                    userCommand = ReadLine();
                    WriteLine();
                    switch (userCommand?.ToUpper() ?? "")
                    {
                        case "L":
                            // list all books 
                            WriteLine("List of all books");
                            break;
                        case "T":
                            // look up by book title
                            WriteLine("List of all books");
                            break;
                        case "Q":
                            userDone = true;
                            break;
                        default:
                            WriteLine("Bad data! Try again..");
                            break;
                    }
                } while (!userDone);
            }
            catch(Exception e)
            {
                WriteLine(e.Message);
            }
            finally
            {
                // close db connection
            }
        }

        public static void ShowInstructions()
        {
            WriteLine("*** Welcome to the Georgia Tech Library ***");
            WriteLine();
            WriteLine("L: List all the books");
            WriteLine("I: Insert new book");
            WriteLine("Q: Quits program");
        }
    }
}
