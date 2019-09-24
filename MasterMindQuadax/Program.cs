using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindQuadax
{
    class Program
    {
        private static string randomNumber;

        private static string numberEntered;
        
        static void Main(string[] args)
        {
            randomNumber = FourDigitRandomNumber();
            Play();
        }

        private static void Play()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Please Enter 4 digits with each digit between 1 and 6\n");

                numberEntered = Console.ReadLine();

                int number = 0;

                int.TryParse(numberEntered, out number);

                // vaidate entry
                if (numberEntered.Count() != 4 || number == 0)
                {
                    Console.Write("Invalid Entry\n\n");
                    continue;
                }

                var result = GetFeedBack().ToString();

                Console.WriteLine(result + "\n");

                if (result == "++++")
                {
                    Console.WriteLine("You Won\n");
                    Console.Read();
                    return;
                }

                else
                    continue;
            }

            Console.WriteLine("You Lost\n");
            Console.Read();
        }

        private static string FourDigitRandomNumber()
        {
            Random random = new Random();

            int result = 0;

            for (int i = 0; i < 4; i++)
            {
                result = result * 10 + random.Next(1, 6);
            }

            return result.ToString();
        }

        private static bool IsDigitPresentInTheRandomNumber(char digit)
        {
            return randomNumber.Contains(digit);
        }

        private static StringBuilder GetFeedBack()
        {
            StringBuilder returnValue = new StringBuilder();

            for(int i = 0; i < 4; i++)
            {
                if (IsDigitPresentInTheRandomNumber(numberEntered[i]))
                {
                    if (randomNumber[i] == numberEntered[i])
                        returnValue.Insert(i, '+');

                    else
                        returnValue.Insert(i, '-');
                }

                else
                    returnValue.Insert(i, ' ');
            }

            return returnValue;
        }
    }
}
