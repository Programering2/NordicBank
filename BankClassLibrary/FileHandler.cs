using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;

namespace BankClassLibrary
{
    public static class FileHandler
    {
        
       public static string FileName = @"C:\Users\lilje\Desktop\Programing\NordicBank\UsersData\Users.txt";

        public static void UpdateUser(string FileName, Banken bank) // if user exist add user on same line, else add on new line
        {


            // Läs in alla rader i filen till en array
            string[] currentBankFile = FileToArray(FileName);
            int UserIndex = -1;

            // Loopa igenom alla rader
            for (int i = 0; i < currentBankFile.Length; i++)
            {
                // Hämta namnet från raden
                string name = "";
                // Kontrollera om raden börjar med "F" eller "T"
                if (currentBankFile[i].StartsWith("F"))
                {
                    // Plocka ut namnet från raden, börjar på indexplats 6
                    name = currentBankFile[i].Substring(6);
                }
                else if (currentBankFile[i].StartsWith("T"))
                {
                    // Plocka ut namnet från raden, börjar på indexplats 5
                    name = currentBankFile[i].Substring(5);
                }

                // Jämför namnet med namnet på den aktiva användaren
                if (name.ToUpper() == bank.getUser(bank.getActiveUserKey()).getName().ToUpper())
                {
                    // Spara indexplatsen för raden och avbryt loopen
                    UserIndex = i;
                    break;
                }
            }

            /* Nu när vi letat efter användaren så updaterar vi vår databas i txt filen*/


            // Om användaren inte hittades
            if (UserIndex == -1)
            {
                // Lägg till användaren som en ny rad i filen
                using (StreamWriter file = File.AppendText(FileName))
                {
                    file.WriteLine(TurnUserToStringData(bank.getUser(bank.getActiveUserKey())));
                }
            }
            else
            {
                // Uppdatera användarens rad i filen
                currentBankFile[UserIndex] = TurnUserToStringData(bank.getUser(bank.getActiveUserKey()));
                using (StreamWriter file = File.CreateText(FileName))
                {
                    for (int i = 0; i < currentBankFile.Length; i++)
                    {
                        file.WriteLine(currentBankFile[i]);
                    }
                }
            }


        }

public static Banken ReadFile(string FileName)
    {
        Banken bank= new Banken();
        List<string> list = new List<string>(); 
        int counter = 0;
        string line;
        StreamReader file = new StreamReader(FileName); //skapar file stream 

        while ((line = file.ReadLine()) != null) // så länge det finns mer rader att läsa in
        {
            list.Add(line); // lägg in varje rad i en array
            counter++;
        }

        while (list.Count > 0) // go through each line
        {
                List<string> strings = new List<string>(); //skapa en lista med strings

                string temp = ""; //temporär sträng för att läsa in nuvarande line i filen
                int j = 0;

                        //en algoritm som delar in varje ord i en lista med strings
                        while (j < list[list.Count-1].Length) //gå igenom varje sträng
                        {
                            if (list[list.Count-1][j].ToString() != " ") //om det inte är ett mellanslag finns det fler bokstäver kvar i ordet
                            {
                                temp += list[list.Count-1][j]; //lägg till bokstaven 
                            } 
                            else //nu finns det inget kvar på ordet
                            {
                                strings.Add(temp); //lägg till ordet i listan
                                temp = ""; //nollställ temp
                            }
                            j++; // increasa itterator
                        }
                        //update user from list
                    
                // i denna lista finns nu all data för att sätta upp en användare
                bank.AddUser(int.Parse(strings[3]), int.Parse(strings[4]), int.Parse(strings[2])); //vi skapar user
                bank.getUser(int.Parse(strings[3])).setName(strings[1]); //lägg till namn
                bank.getUser(int.Parse(strings[3])).setHasLoggedInOnce(true); //vi sätter att användaren har loggat in
                bank.getUser(int.Parse(strings[3])).OpenPersonalAccount();  //öppnar personligt konto
                bank.getUser(int.Parse(strings[3])).GetPersonalAccount().setBalance(int.Parse(strings[5])); //vi sätter balansen på personligt konto

                strings.Clear(); //nollställer listan för nästa itteration
                list.RemoveAt(list.Count - 1); //vi tar bort den översta användaren så vi kan läsa in nästa

        }
                
            file.Close(); //vi måste va noga med att stänga filen
            return bank; //return type är banken, vi skickar med den bank version vi ändrat i
        }

        public static string[] FileToArray(string FileName)
        {
            List<string> list = new List<string>();
            int counter = 0;
            string line;

            // Öppnar en filström för att läsa filen
            using (StreamReader file = File.OpenText(FileName))
            {
                // Så länge det finns rader att läsa i filen
                while ((line = file.ReadLine()) != null)
                {
                    list.Add(line); // lägg till raden i listan
                    counter++;
                }
            }

            // Konverterar listan till en array och returnerar den
            string[] UserArr = list.ToArray();
            return UserArr;
        }

        public static string TurnUserToStringData(User user) //när vi vill göra om en användare till en string av data
        {
            List<string> list = new List<string>();

            //first 6 strings

            list.Add(user.getHasLoggedInOnce().ToString());
            list.Add(user.getName());
            list.Add(user.getPhoneNumber().ToString());
            list.Add(user.getSocialNumber().ToString());
            list.Add(user.getPincode().ToString());
            list.Add(user.GetPersonalAccount().getBalance().ToString());

            //2 strings for every account except personal account

            for (int i = 1; i < user.getNumberOfAccounts(); i++)
            {
                list.Add(user.getAccountByIndex(i).getBalance().ToString());
                list.Add(user.getAccountByIndex(i).getBankNumber().ToString());

            }

            
            //vi separerar all data med ett mellanslag så vi kan urskilja på den vid inläsning 

            string data = "";
            foreach (string s in list)
            { 
                data += s + " ";
            }
            return data;
        }


    }
}
