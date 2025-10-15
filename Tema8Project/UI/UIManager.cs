using System;
using System.Security.Cryptography.X509Certificates;
using TxtRPG.Data;

namespace TxtRPG.UI
{
    public static class UIManager
    {
        public static void PrintCenter(string text)
        {
            int width = Console.WindowWidth;
            int padding = Math.Max((width - text.Length) / 2, 0);
            Console.SetCursorPosition(padding, Console.CursorTop);
            Console.WriteLine(text);
        }
        public static void PrintText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            PrintCenter(text);
            Console.ResetColor();
        }
        public static void PrintYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintCenter(text);
            Console.ResetColor();
        }
        public static void PrintDivider(string style = "brick")
        {
            if (style == "brick")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                PrintCenter("🟫🟫🟫🟫🟫🟫🟫🟫🟫🟫🟫🟫🟫🟫🟫🟫");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                PrintCenter("════════════════════════════════");
            }
            Console.ResetColor();
        }
        public static void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintCenter("✦✦✦✦✦✦✦✦✦✦✦✦✦✦✦✦✦✦");
            PrintCenter($"𝟠 {title} 𝟠");
            PrintCenter("✦✦✦✦✦✦✦✦✦✦✦✦✦✦✦✦✦✦");
            Console.ResetColor();
        }

        public static string ReadInput(string prompt = ">>")
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            PrintCenter(prompt);
            Console.ResetColor();
            return Console.ReadLine() ?? "";
        }
    }
}
