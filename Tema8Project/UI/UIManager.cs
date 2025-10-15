using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using TxtRPG.Data;

namespace TxtRPG.UI
{
    public static class UIManager
    {
        public static void PrintCenter(string text)
        {
            int width = Console.WindowWidth;
            int displayLength = 0;

            foreach (char c in text)
            {
                
                if(( c >= 0xAC00 && c <= 0xD7A3) || ( c > 127))
                {
                    displayLength += 2;
                }
                else
                {
                    displayLength += 1;
                }
            }
            int padding = Math.Max((width - displayLength) / 2, 0);
            Console.SetCursorPosition(padding, Console.CursorTop);
            Console.WriteLine(text);
        }
        public static void PrintCenterLine(string text)
        {
            int width = Console.WindowWidth;
            int displayLength = 0;

            foreach (char c in text)
            {

                if ((c >= 0xAC00 && c <= 0xD7A3) || (c > 127))
                {
                    displayLength += 2;
                }
                else
                {
                    displayLength += 1;
                }
            }
            int padding = Math.Max((width - displayLength) / 2, 0);
            Console.SetCursorPosition(padding, Console.CursorTop);
            Console.Write(text);
        }

        public static void PrintYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintCenter(text);
            Console.ResetColor();
        }
        public static void PrintDarkYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintCenter(text);
            Console.ResetColor();
        }
        public static void PrintRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintCenter(text);
            Console.ResetColor();
        }
        public static void PrintDarkRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            PrintCenter(text);
            Console.ResetColor();
        }
        public static void PrintBlue(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintCenter(text);
            Console.ResetColor();
        }
        public static void PrintCyan(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintCenter(text);
            Console.ResetColor();
        }
        public static void PrintDivider(string style = "brick")
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            switch (style)
            {
                case "brick":
                    PrintCenter("============================================");
                    break;
                case "dash":
                    PrintCenter("--------------------------------------------");
                    break;
                case "cross":
                    PrintCenter("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    break;
                case "block":
                    PrintCenter("████████████████████████████████████████████");
                    break;
                case "line":
                    PrintCenter("___________________________________________");
                    break;
            }
            Console.ResetColor();
        }
        public static void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintCenter("===========================================");
            Console.ResetColor();
            PrintCenter($"★  {title} ★");
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintCenter("===========================================");
            Console.ResetColor();
        }
        public static string ConsoleArray(Action drawAction, int refreshDelayMs = 100)
        {
            int lastwidth = Console.WindowWidth;
            string input = "";
            bool firstDraw = true;

            while(true)
            {
                if ( Console.WindowWidth != lastwidth || firstDraw)
                {
                    Console.Clear();
                    drawAction.Invoke();
                    lastwidth = Console.WindowWidth;
                    firstDraw = false;
                }

                if (Console.KeyAvailable)
                {
                    int promptPos = Math.Max((Console.WindowWidth / 2) - 2, 0);
                    Console.SetCursorPosition(promptPos, Console.CursorTop);
                    Console.Write(" ");
                    input = Console.ReadLine() ?? "";
                    break;
                }

                Thread.Sleep(refreshDelayMs);
            }
            return input;
        }
    }
}
