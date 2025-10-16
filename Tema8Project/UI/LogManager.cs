using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TxtRPG.UI;
using TxtRPG.Game;
using System.Threading.Tasks;

namespace TxtRPG
{
    public static class LogManager
    {
        private static string[] logLines = new string[3] { "- ", "- ", "- ", };

        public static void Add(string message)
        {
            logLines[0] = logLines[1];
            logLines[1] = logLines[2];
            logLines[2] = message;
        }

        public static void Show()
        {
            Console.WriteLine("\n[이벤트 로그]---------------");

            foreach (var line in logLines)
            {
                if (!string.IsNullOrEmpty(line))
                    Console.WriteLine(line);
            }

            Console.WriteLine("----------------------------");
        }

        public static void Clear()
        {
            for (int i = 0; i < logLines.Length; i++)
                logLines[i] = string.Empty;
        }
    }

}