using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordGenerator
{
    public class Generate
    {

        public string AnswerUpperCase { get; set; }
        public string AnswerLowercase { get; set; }
        public string AnswerSpecialCharacter { get; set; }
        public string AnswerDigit { get; set; }
        public int LengthPassword { get; set; }

        public string AnswerAnotherPassword { get; set; }

        public string GeneratePassword()
        {
            Generate generate=new Generate();
            generate = GetInput();

          

            string[] lowerCase = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] upperCase = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] number = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] speacilChar = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "-", ".", "`", "~", "|", "<", ">", "=", "-", "_" };
            List<string> finalList = new List<string>();

            string generatedPassword="";
            if(generate.AnswerLowercase== "y") {


                finalList.AddRange(lowerCase);
                    
               }
            if (generate.AnswerUpperCase == "y")
            {

                finalList.AddRange(upperCase);
            }
            if(generate.AnswerDigit== "y")
            {

                finalList.AddRange(number);
            }
            if (generate.AnswerSpecialCharacter == "y")
            {

                finalList.AddRange(speacilChar);
            }

            Random rnd=new Random();
            var builder = new StringBuilder(generatedPassword);
            if (finalList.Count != 0)
            {
                for (int i = 0; i < generate.LengthPassword; i++)
                {

                    int index = rnd.Next(finalList.Count);
                    string value = finalList[index];
                    builder.Append(value);
                    Console.WriteLine("YOUR GENERATED PASSWORD IS: " + builder.ToString());


                }
            }
            else
            {

                Console.WriteLine("You answered no to all questions. It is impossible to generate password in this way");

            }
           
            
            Console.WriteLine("///////////////////////////////////////");
            if (generate.AnswerAnotherPassword== "y")
            {

                GeneratePassword();

            }
            else
            {

                Environment.Exit(0);
            }

            return builder.ToString();
        }

        public Generate GetInput()
        {

            Generate generate= new Generate();
            Console.WriteLine("WELCOME TO THE PASSWORD GENERATOR :) ");
            Console.WriteLine("Do you want to include numbers? ");
            generate.AnswerDigit = Console.ReadLine();
            if((generate.AnswerDigit.ToLower()== "y"|| generate.AnswerDigit.ToLower() == "n" )==false) {

              
                while ((generate.AnswerDigit.ToLower() == "y" || generate.AnswerDigit.ToLower() == "n")==false)
                {
                    Console.WriteLine("Please  enter the answer in the correct format (y/n) ");
                    Console.WriteLine("Do you want to include numbers? ");
                    generate.AnswerDigit = Console.ReadLine();

                }
            }

            Console.WriteLine("Do you want to include special charecters? ");
            generate.AnswerSpecialCharacter = Console.ReadLine();
            if ((generate.AnswerSpecialCharacter.ToLower() == "y" || generate.AnswerSpecialCharacter.ToLower() == "n")==false)
            {


                while ((generate.AnswerSpecialCharacter.ToLower() == "y" || generate.AnswerSpecialCharacter.ToLower() == "n")==false)
                {
                    Console.WriteLine("Please  enter the answer in the correct format (y/n) ");
                    Console.WriteLine("Do you want to include special charecters? ");
                    generate.AnswerSpecialCharacter = Console.ReadLine();

                }
            }


            Console.WriteLine("Do you want to include lowercase charecters? ");
            generate.AnswerLowercase = Console.ReadLine();
            if ((generate.AnswerLowercase.ToLower() == "y" || generate.AnswerLowercase.ToLower() == "n")==false)
            {


                while ((generate.AnswerLowercase.ToLower() == "y" || generate.AnswerLowercase.ToLower() == "n") == false)
                {
                    Console.WriteLine("Please  enter the answer in the correct format (y/n) ");
                    Console.WriteLine("Do you want to include special charecters? ");
                    generate.AnswerLowercase = Console.ReadLine();

                }
            }

            Console.WriteLine("Do you want to include uppercase charecters? ");
            generate.AnswerUpperCase = Console.ReadLine();
            if ((generate.AnswerUpperCase.ToLower() == "y" || generate.AnswerUpperCase.ToLower() == "n") == false)
            {


                while ((generate.AnswerUpperCase.ToLower() == "y" || generate.AnswerUpperCase.ToLower() == "n") == false)
                {
                    Console.WriteLine("Please  enter the answer in the correct format (y/n) ");
                    Console.WriteLine("Do you want to include special charecters? ");
                    generate.AnswerUpperCase = Console.ReadLine();

                }
            }
            Console.WriteLine("Do you want to include special charecters? ");
            generate.AnswerUpperCase = Console.ReadLine();
            if ((generate.AnswerSpecialCharacter.ToLower() == "y" || generate.AnswerSpecialCharacter.ToLower() == "n") == false)
            {


                while ((generate.AnswerSpecialCharacter.ToLower() == "y" || generate.AnswerSpecialCharacter.ToLower() == "n") == false)
                {
                    Console.WriteLine("Please  enter the answer in the correct format (y/n) ");
                    Console.WriteLine("Do you want to include special charecters? ");
                    generate.AnswerSpecialCharacter = Console.ReadLine();

                }
            }

            Console.WriteLine("How long dou you want to keep your password length? ");
            string number = Console.ReadLine();
            int value;
            bool isNumber = int.TryParse(number, out value);
         
      
            if (!isNumber)
            {
                while (!isNumber)
                {


                    Console.WriteLine("Please enter the number not string! ");
                    Console.WriteLine("How long dou you want to keep your password length? ");
                    number
                        = Console.ReadLine();
                    isNumber = int.TryParse(number, out value);

                }


            }
            generate.LengthPassword = value;

            
            Console.WriteLine("Lastly, do you want to generate another password? ");
            generate.AnswerAnotherPassword = Console.ReadLine();

            if ((generate.AnswerAnotherPassword.ToLower() == "y" || generate.AnswerAnotherPassword.ToLower() == "n") == false)
            {


                while ((generate.AnswerAnotherPassword.ToLower() == "y" || generate.AnswerAnotherPassword.ToLower() == "n") == false)
                {
                    Console.WriteLine("Please  enter the answer in the correct format (y/n) ");
                    Console.WriteLine("Lastly, do you want to generate another password? ");
                    generate.AnswerAnotherPassword = Console.ReadLine();

                }
            }

            return generate;

        }
    }
}
