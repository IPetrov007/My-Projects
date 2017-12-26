using System;
using System.Threading;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! What is your name?");
            Console.WriteLine();

            var name = Console.ReadLine();
            Console.WriteLine();

            var yes = "Y";
            while (yes == "Y")
            {
                int score = 0;

                Console.Write("Hi ");
                PrintMessage(ConsoleColor.Yellow, name + "!");
                Console.WriteLine();
                Console.WriteLine("The program was set the number between 1 and 20. Try to guess this number!");
                Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine("And... your choice is:");
                Console.WriteLine();
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("Think!");
                    Thread.Sleep(200);
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write("...");
                        Thread.Sleep(200);
                    }

                }
                Console.WriteLine();

                Random random = new Random();
                var exactNumber = random.Next(1, 21);

                var enteredNumber = int.MinValue;

                while (enteredNumber != exactNumber)
                {
                    score++;

                    var enteredInput = Console.ReadLine();

                    enteredNumber = 0;

                    while (!Int32.TryParse(enteredInput, out enteredNumber))
                    {
                        PrintMessage(ConsoleColor.Yellow, "Please enter a real number!");
                        enteredInput = Console.ReadLine();
                    }
                    if (enteredNumber > exactNumber)
                    {
                        PrintDouwn();
                    }
                    else if (enteredNumber < exactNumber)
                    {
                        PrintUp();
                    }
                    else
                    {
                        PrintMessage(ConsoleColor.Green, $"Congratulation {name}! Your score is {score}");
                    }
                }
                Console.WriteLine("Do you whant to play again? Y/N");
                yes = Console.ReadLine().ToUpper();
                Console.Clear();
            }
        }

        private static void PrintUp()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Sorry, choose another number! / \\ ");
            Console.WriteLine("                             / | \\");
            Console.WriteLine("                               |  ");
            Console.WriteLine("                               |  ,  UP!");

            Console.ResetColor();
        }

        private static void PrintDouwn()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Sorry, choose another number!  |  ");
            Console.WriteLine("                               |  ");
            Console.WriteLine("                             \\ | /");
            Console.WriteLine("                              \\ / , DOWN!");

            Console.ResetColor();
        }

        public static void PrintMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
