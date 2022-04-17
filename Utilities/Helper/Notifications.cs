
using System;

namespace Utilities
{
    public static class Notifications
    {
        public static void Alert(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static int TryParse()
        {

            bool isNum = false;
            int input = 0;
            while (isNum == false)
            {
                string num = Console.ReadLine();
                isNum = int.TryParse(num, out input);
                if (isNum)
                    return input;
                else
                    Alert(ConsoleColor.Red, "Wrong Format !");
            }
            return input;

        }
        public enum Role
        {
            admin=1,
            director,
            doctor,
            staff
        };
        
        
	

	}
}

