/*=================================================
 * Tristan Reilly
 * S00199625  
 * 13/03/2020
 * Lab 12 q4)
 * file handling 
 * ================================================*/
using System;
using System.IO;

namespace ca3_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            bool isValid;
            do
            {
                isValid = true;

                Console.WriteLine("\nMenu");
                Console.WriteLine("\n1. Vessel Report");
                Console.WriteLine("2. Location Analysis Report"); //Menu
                Console.WriteLine("3. Search for a Vessel");
                Console.WriteLine("4. Exit");

                Console.Write("\nEnter your choice : ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    VesselReport();
                }
                else if (choice == 2) //Choice
                {
                    LocationAnaylsesReport();
                }
                else if (choice == 3)
                {
                    SearchForVessel();
                }
                else if (choice > 5 || choice < 0)
                {
                    Console.WriteLine("Enter Correct Number");
                    isValid = false;
                }
            }
            while (choice != 4 && isValid == true);
        }

        static void VesselReport() //choice 1 vessel report
        {
            string[] fields = new string[5];

            string tableFormat = "{0,-25}{1,-25}{2,-25}{3,-25}{4,-25}";
            string lineIn;

            FileStream fs = new FileStream("c://Users/Tristan/Desktop/programming/FrenchMF.txt", FileMode.Open, FileAccess.Read);
            StreamReader inputStream = new StreamReader(fs);

            Console.WriteLine("\nVessel Report\n-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(tableFormat,"Vessel Name","Vessel Type","Tonnage","Crew","Location");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");

            lineIn = inputStream.ReadLine();
            while (lineIn != null)
            {
                string location = ""; //variables
                string vesselType = "";

                fields = lineIn.Split(','); //csv
                
                if(fields[4] == "1") //location codes
                {
                    location = "Pacific";
                }
                else if (fields[4] == "2")
                {
                    location = "Athlantic";
                }
                else if (fields[4] == "3")
                {
                    location = "Mediterranian";
                }
                else if (fields[4] == "4")
                {
                    location = "Indian";
                }
                else if (fields[4] == "5")
                {
                    location = "Other";
                }


                if (fields[1] == "1") //type of vessel codes
                {
                    vesselType = "Aircraft Carrier";
                }
                else if (fields[1] == "2")
                {
                    vesselType = "Cruiser/Battleship";
                }
                else if (fields[1] == "3")
                {
                    vesselType = "Destroyer";
                }
                else if (fields[1] == "4")
                {
                    vesselType = "Frigate";
                }
                else if (fields[1] == "5")
                {
                    vesselType = "Nuclear Submarine";
                }
                else if (fields[1] == "6")
                {
                    vesselType = "Minelayer/Sweeper";
                }

                Console.WriteLine(tableFormat,fields[0], vesselType, fields[2], fields[3], location); //ouput

                lineIn = inputStream.ReadLine();
            }
            inputStream.Close();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        }

        static void LocationAnaylsesReport() //choice 2 location anayleses report
        {
            string[] fields = new string[5]; //arrays
            int[] locationCount = new int[5];
            string[] location = new string[5];
            location[0] = "Pacific";
            location[1] = "Athlantic";
            location[2] = "Mediteraninan";
            location[3] = "Indian";
            location[4] = "Other";

            string lineIn;

            string tableFormat = "{0,-25}{1,-25}";

            FileStream fs = new FileStream("c://Users/Tristan/Desktop/programming/FrenchMF.txt", FileMode.Open, FileAccess.Read);
            StreamReader inputStream = new StreamReader(fs);

            lineIn = inputStream.ReadLine();

            while (lineIn != null)
            {
                fields = lineIn.Split(','); //csv

                if (fields[4] == "1") //location codes
                {
                    locationCount[0] += 1; // location count
                }
                else if (fields[4] == "2")
                {
                    locationCount[1] += 1;
                }
                else if (fields[4] == "3")
                {
                    locationCount[2] += 1;
                }
                else if (fields[4] == "4")
                {
                    locationCount[3] += 1;
                }
                else if (fields[4] == "5")
                {
                    locationCount[4] += 1;
                }

                lineIn = inputStream.ReadLine();
            }
            inputStream.Close();
            Console.WriteLine(tableFormat, "\nLocation", "Count");
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(tableFormat, location[i], locationCount[i]);
            }
        }

        static void SearchForVessel() // choice 3 search for vessel
        {
            string[] fields = new string[5];
            bool exsisits;
            string location = "";

            FileStream fs = new FileStream("c://Users/Tristan/Desktop/programming/FrenchMF.txt", FileMode.Open, FileAccess.Read);
            StreamReader inputStream = new StreamReader(fs);

            Console.Write("Enter Vessel Name : ");
            string vesselName = UppercaseFirst(Console.ReadLine());

            string lineIn = inputStream.ReadLine();

            while (lineIn != null && lineIn != vesselName)
            {
                fields = lineIn.Split(','); //csv

                lineIn = inputStream.ReadLine();
                
                if (fields[0] == vesselName)
                {
                   exsisits = true;
                }
                else if (fields[0] != vesselName)
                {
                    exsisits = false;
                }
            }

            if(fields[4] == "1")
            {
                location = "Pacific";
            }
            else if (fields[4] == "2")
            {
                location = "Athlantic";
            }
            else if (fields[4] == "3")
            {
                location = "Medditernian";
            }
            else if (fields[4] == "4")
            {
                location = "Indian";
            }
            else if (fields[4] == "5")
            {
                location = "Other";
            }

            if (exsisits = true)
            {
                Console.WriteLine("Location : {0}", location);
            }
            else if (exsisits = false)
            {
                Console.WriteLine("Vessel does not exisist in this directory");
            }
        }

        static string UppercaseFirst(string s) //found online https://www.dotnetperls.com/uppercase-first-letter
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}

