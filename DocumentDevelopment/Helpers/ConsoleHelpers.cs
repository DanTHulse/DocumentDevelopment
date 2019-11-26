using System;

namespace DocumentDevelopment.Helpers
{
    public static class ConsoleHelpers
    {
        public static int ReadNumber()
        {
            var value = "";
            ConsoleKeyInfo key;

            int numValue;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    var x = int.TryParse(key.KeyChar.ToString(), out _);
                    if (x)
                    {
                        value += key.KeyChar;
                        Console.Write(key.KeyChar.ToString());
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && value.Length > 0)
                    {
                        value = value.Substring(0, value.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();

            numValue = int.TryParse(value, out var newNumValue) == true ? newNumValue : 0;

            return numValue;
        }
    }
}
