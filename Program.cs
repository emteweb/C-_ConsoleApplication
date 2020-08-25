using System;
using System.IO;
using System.Collections.Generic;

namespace RB_ver._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            // A array of people  
            // string[] sollutionDesk = { "APK","MTR","JLO","PDA","NLE","DGU","OPA","LMA","MAR" };

            Console.WriteLine("###################################################");
            Console.WriteLine("########################   ########################");
            Console.WriteLine("###################             ###################");
            Console.WriteLine("###############                     ###############");
            Console.WriteLine("############                           ############");
            Console.WriteLine("##########                               ##########");
            Console.WriteLine("########                                   ########");
            Console.WriteLine("#######              Welcome to             #######");
            Console.WriteLine("#######                                     #######");
            Console.WriteLine("######             RB-Application            ######");
            Console.WriteLine("######                                       ######");
            Console.WriteLine("######                                       ######");
            Console.WriteLine("#######                                     #######");
            Console.WriteLine("#######                                     #######");
            Console.WriteLine("########            Copyright              ########");
            Console.WriteLine("##########              by               ##########");
            Console.WriteLine("############       Marcin Trebacz      ############");
            Console.WriteLine("###############                     ###############");
            Console.WriteLine("###################             ###################");
            Console.WriteLine("########################   ########################");
            Console.WriteLine("###################################################");

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("How many people do you want to add to the list? ");
            int size = Convert.ToInt32(Console.ReadLine());

            string[] sollutionDesk = new string[size];

            for (int i = 0; i < sollutionDesk.Length; i++)
            {
                Console.Write("Please enter the name: ");
                sollutionDesk[i] = Console.ReadLine();
            }
            Console.WriteLine();
            Console.Write("You added the following names: ");

            for (int i = 0; i < sollutionDesk.Length; i++)
            {
                if (i < sollutionDesk.Length - 1)
                {
                    Console.Write(sollutionDesk[i] + ", ");
                }
                else
                {
                    Console.Write(sollutionDesk[i]);
                }
            }

            Console.WriteLine();

            List<string> list = new List<string>(sollutionDesk);
            List<string> chosen = new List<string>();
            List<string> dates = new List<string>();

            for (int i = 0; i < sollutionDesk.Length; i++)
            {
                Console.WriteLine();
                Console.Write("Do you want to choose a person? ");
                string answer = Console.ReadLine();
                Random rand = new Random();
                int index = rand.Next(list.ToArray().Length);

                if (answer == "yes" || answer == "YES")
                {
                    // Create a Random object  
                    //Random rand = new Random();
                    // Generate a random index less than the size of the array. 
                    //int index = rand.Next(list.ToArray().Length);
                    // Display the result.  
                    Console.WriteLine();
                    Console.Write("Please enter the date [DD-MM-YYYY] ");
                    dates.Add(Console.ReadLine());
                    Console.WriteLine($"Randomly selected person is: {list[index]}");
                    chosen.Add(list[index]);
                    list.Remove(list[index]);
                    Console.WriteLine();
                    Console.Write("Remaining candidates: ");

                    for (int j = 0; j < list.ToArray().Length; j++)
                    {
                        if (j < list.ToArray().Length - 1)
                        {
                            Console.Write(list[j] + ", ");
                        }
                        else
                        {
                            Console.Write(list[j] + " [Press Enter]");
                        }
                    }
                    Console.WriteLine();
                }
                else if (answer == "no" || answer == "NO")
                {
                    Console.WriteLine();
                    Console.WriteLine("Thank you and see next time :)");
                    i = 100;
                }
                else
                {
                    Console.WriteLine("Hey man! WTF! Why don't you enter 'yes' or 'no'");
                }
                Console.ReadKey();
            }

            // write to file yyyy-MM-dd

            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                //ostrm = new FileStream("d:\\RB_" + DateTime.Now.ToString(format: "dd-MM-yyyy") + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                //writer = new StreamWriter(ostrm);

                ostrm = new FileStream("d:\\RB_" + DateTime.Now.ToString(format: "dd-MM-yyyy") + ".txt", FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(ostrm);

            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            // this goes to file

            Console.SetOut(writer);

            var x = 0;
            
            foreach (var date in dates)
            {
                Console.Write(date + ": ");
                Console.WriteLine(chosen[x]);
                x++;
            }

            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
        }
    }
}
