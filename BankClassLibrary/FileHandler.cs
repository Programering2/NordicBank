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


            string[] currentBankFile = FileToArray(FileName);

            int UserKey = bank.getActiveUserKey();

            int UserIndex = -1;

            //check if user exist
            for (int i = 0; i < currentBankFile.Length; i++)
            {

                string name = "";
                for (int j = 0; j < currentBankFile[i].Length; j++)
                {
                    if (j == 0)
                    {
                        if (currentBankFile[i][j] == 'F') //jump to name 
                        {
                            j = 6;
                        }
                        else if (currentBankFile[i][j] == 'T') // jump to name
                        {
                            j = 5;
                        }
                    }

                    if (currentBankFile[i][j].ToString() != "")
                    {
                        name += currentBankFile[i][j];
                    }
                    else
                    {
                        break;
                    }
                }

                if (bank.getUsers().Count() > 0)
                {
                    char z = '^';
                    int a = 0;
                    string temp = "";
                    while (z != ' ')
                    {
                        z = name[a];
                        if (z != ' ')
                        {
                            temp += z;
                        }
                        a++;
                    }
                    if (temp.ToUpper() == bank.getUser(bank.getActiveUserKey()).getName().ToUpper())
                    {
                        UserIndex = i;
                        break;
                    }
                }
            }

                // we need to erase all data
                if (UserIndex == -1)
                {
                    using (StreamWriter file = File.AppendText(FileName))
                    {
                        file.WriteLine(TurnUserToStringData(bank.getUser(bank.getActiveUserKey())));
                    }
                        //writes new line

                }
                else
                {
                    currentBankFile[UserIndex] = TurnUserToStringData(bank.getUser(bank.getActiveUserKey()));
                         using (StreamWriter file = File.CreateText(FileName))
                        {
                            for (int i = 0; i < currentBankFile.Length; i++)
                            {
                                file.WriteLine(currentBankFile[i]);

                            }

                        }
                //user exist already, just change his line
             
            
                 }


        }

        public static Banken ReadFile(string FileName)
        {
            Banken bank= new Banken();
            List<string> list = new List<string>(); 
            int counter = 0;
            string line;
            StreamReader file = new StreamReader(FileName); //skapar file stream 

            while ((line = file.ReadLine()) != null)
            {
                list.Add(line);
                counter++;
            }

                while (list.Count > 0) // go through each line
                {
                    List<string> strings = new List<string>();


                    string temp = "";
                    int j = 0;
                    while (j < list[list.Count-1].Length) //go through each char in each line
                    {
                        if (list[list.Count-1][j].ToString() != " ")
                        {
                            temp += list[list.Count-1][j];
                        }
                        else 
                        {
                            strings.Add(temp);
                            temp = "";
                        }
                        j++;
                    }
                    //update user from list
                    
                    bank.AddUser(int.Parse(strings[3]), int.Parse(strings[4]), int.Parse(strings[2])); //vi skapar user
                    bank.getUser(int.Parse(strings[3])).setName(strings[1]); //lägg till namn
                    bank.getUser(int.Parse(strings[3])).setHasLoggedInOnce(true); //lägg till namn
                    bank.getUser(int.Parse(strings[3])).OpenPersonalAccount();
                    bank.getUser(int.Parse(strings[3])).GetPersonalAccount().setBalance(int.Parse(strings[5]));





                    strings.Clear(); //empty list
                    list.RemoveAt(list.Count - 1);

                }
                
                file.Close();
            return bank;
        }

        public static string[] FileToArray(string FileName)
        {
            List<string> list = new List<string>();
            int counter = 0;
            string line;

            using (StreamReader file = File.OpenText(FileName))
            {
                while ((line = file.ReadLine()) != null)
                {
                    list.Add(line);
                    counter++;
                }

            }


            string[] UserArr = list.ToArray();
            //update bank
            return UserArr;
        }

        public static string TurnUserToStringData(User user)
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


            string data = "";
            foreach (string s in list)
            { 
                data += s + " ";
            }
            return data;
        }


    }
}
