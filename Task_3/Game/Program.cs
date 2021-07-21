using System;
using System.Linq;

namespace Game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //args = new[] {"1", "2", "3"};
            //args = new string[] { "rock", "scissors", "paper" };
            //args = new[] { "paper", "rock", "Spock", "scissors", "lizardddd"};
            if (!AreArgsOk(ref args)) return;

            var choiceOfPC = new Random().Next(1, args.Length + 1);
            var secretKey = Hash.RandomNumberGenerator();
            var HMAC = Hash.HashHMAC(secretKey, BitConverter.GetBytes(choiceOfPC));

            Console.WriteLine($"HMAC: {BitConverter.ToString(HMAC).Replace("-", "").ToUpper()}");

            Menu.ShowMenu(args);

            var choiceOfUser = -1;

            var flag = false;
            while (!flag)
            {
                Console.Write("Enter your move:");
                if (!int.TryParse(Console.ReadLine(), out choiceOfUser) ||
                    !Enumerable.Range(0, args.Length + 1).Contains(choiceOfUser))
                    Console.WriteLine("Wrong input! Example: 2");
                else flag = true;
            }

            if (choiceOfUser == 0) return;

            Console.WriteLine($"Your move:{args[choiceOfUser - 1]}");
            Console.WriteLine($"Computer move:{args[choiceOfPC - 1]}");
            Console.WriteLine(Decision.Decide(choiceOfUser - 1, choiceOfPC - 1, args.Length));
            Console.WriteLine($"HMAC key: {BitConverter.ToString(secretKey).Replace("-", "").ToUpper()}");
        }


        // Kind of like checking for correctness (it's better not to write like that)
        private static bool AreArgsOk(ref string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Args are less than 3. Example: dotnet Game.dll 1 2 3 4 5");
                return false;
            }

            if (args.Length % 2 == 0)
            {
                Console.WriteLine("Count of args is even numbers. Example: dotnet Game.dll 1 2 3 4 5");
                return false;
            }

            int a;
            if (int.TryParse(args[0], out a))
            {
                var prev = 0;
                foreach (var str in args)
                    if (!int.TryParse(str, out a))
                    {
                        Console.WriteLine("Args aren't numbers. Example: dotnet Game.dll 1 2 3 4 5");
                        return false;
                    }
                    else if (prev + 1 == a)
                    {
                        prev++;
                    }
                    else
                    {
                        Console.WriteLine("Args numbers are not in order. Example: dotnet Game.dll 1 2 3 4 5");
                        return false;
                    }

                return true;
            }

            if (args.Length == 3)
            {
                var strItems = Enum.GetNames(typeof(Item));
                foreach (var arg in args)
                    if (strItems.Select(x => x).Where(x => string.Equals(x, arg.ToLower())).Count() != 1)
                    {
                        Console.WriteLine("Args are wrong. Example: dotnet Game.dll rock scissors paper");
                        return false;
                    }

                args = strItems;
                return true;
            }

            if (args.Length == 5)
            {
                var strItemsExtention = Enum.GetNames(typeof(ItemExtension));
                foreach (var arg in args)
                    if (strItemsExtention.Select(x => x).Where(x => string.Equals(x, arg.ToLower())).Count() != 1)
                    {
                        Console.WriteLine("Args are wrong. Example: dotnet Game.dll paper spock rock scissors lizard");
                        return false;
                    }

                args = strItemsExtention;
                return true;
            }

            Console.WriteLine("Args are wrong. Example: dotnet Game.dll paper spock rock scissors lizard");
            return false;
        }
    }
}