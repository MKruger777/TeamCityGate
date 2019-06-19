
namespace TeamCityGate
{
    using System;

    public static class ConsoleHelper
    {
        /// <summary>
        /// WriteLine to console in a Color, resetting to White afterwards
        /// </summary>
        /// <param name="value"></param>
        /// <param name="color"></param>
        public static void WriteLine(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Logger.Log(value);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// WriteLine to console in Cyan by Default
        /// </summary>
        /// <param name="value"></param>
        public static void WriteLine(string value)
        {
            WriteLine(value, ConsoleColor.Cyan);
        }
    }
}
