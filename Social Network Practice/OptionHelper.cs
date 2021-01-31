using System;

namespace OptionHelper
{
    class Option
    {
        public static void PrintOptions(string[] options)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}){options[i]}");
            }
            Console.ResetColor();
        }
    }
}
