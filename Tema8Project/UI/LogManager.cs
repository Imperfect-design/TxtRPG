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
        //로그 라인 로직, 한줄씩 밀기, 저장 공간 디자인
        private static string[] logLines = new string[3] { "- ", "- ", "- ", };
        public static void Add(string message)
        {
            logLines[0] = logLines[1];
            logLines[1] = logLines[2];
            logLines[2] = message;
        }
        //로그 출력 디자인
        public static void Show()
        {
            Console.WriteLine("\n");
            UIManager.PrintCenterLine("[이벤트 로그]---------------");

            foreach (var line in logLines)
            {
                if (!string.IsNullOrEmpty(line))
                    UIManager.PrintCenterLine(line);
            }
            UIManager.PrintCenterLine("----------------------------");
            Console.WriteLine("\n");
        }
        //로그 초기화, GamaManager에서 사용
        public static void Clear()
        {
            for (int i = 0; i < logLines.Length; i++)
                logLines[i] = string.Empty;
        }
    }
}

