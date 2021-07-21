using System;

namespace Game
{
    public class Menu
    {
        public static void ShowMenu(string[] steps)
        {
            Console.WriteLine("Available moves:");
            for (var i = 0; i < steps.Length; i++) Console.WriteLine($"{i + 1} - {steps[i]}");
            Console.WriteLine($"{0} - exit");
        }
    }
}