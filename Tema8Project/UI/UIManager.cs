using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using TxtRPG.Data;

namespace TxtRPG.UI
{
    //static으로 선언
    public static class UIManager
    {
       
        //중앙 정렬 매소드
        public static void PrintCenterLine(string text)
        {
            int width = Console.WindowWidth;
            int displayLength = 0;
            //한글이 영어보다 크기 2배 차지해서, 각가에 맞게 크기 맞추기
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
            //왼쪽 공백과 커서, 출력 정의
            int padding = Math.Max((width - displayLength) / 2, 0);
            Console.SetCursorPosition(padding, Console.CursorTop);
            Console.WriteLine(text);
        }
        //중앙 정렬에 줄 이동 없이
        public static void PrintCenter(string text)
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
        //색 변화 및 가운데 정렬
        public static void PrintYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintCenterLine(text);
            Console.ResetColor();
        }
        public static void PrintDarkYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintCenterLine(text);
            Console.ResetColor();
        }
        public static void PrintRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintCenterLine(text);
            Console.ResetColor();
        }
        public static void PrintDarkRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            PrintCenterLine(text);
            Console.ResetColor();
        }
        public static void PrintBlue(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintCenterLine(text);
            Console.ResetColor();
        }
        public static void PrintCyan(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintCenterLine(text);
            Console.ResetColor();
        }
        //분리 선 정의
        public static void PrintDivider(string style = "brick")
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            switch (style)
            {
                case "brick":
                    PrintCenterLine("============================================");
                    break;
                case "cross":
                    PrintCenterLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    break;
                case "line":
                    PrintCenterLine("___________________________________________");
                    break;
            }
            Console.ResetColor();
        }
        //타이틀 정의
        public static void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintCenterLine("===========================================");
            Console.ResetColor();
            PrintCenterLine($"★  {title} ★");
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintCenterLine("===========================================");
            Console.ResetColor();
        }
        //창 변경시 중앙 정렬
        //공개적으로, 전역에 사용할 수 있는, 문자열로 받고, 화면을 그리는 액션을 롤백으로 받는다.
        public static string ConsoleArray(Action drawAction)
        {
            int lastwidth = Console.WindowWidth;
            string input = "";
            bool firstDraw = true;
            //커서 숨기기
            if (Console.CursorVisible)
            {
                Console.CursorVisible = false;
            }

            while(true)
            {
                //콘솔 너비가 바뀌면 콘설 Clear, 새롭게 그리기
                if (Console.WindowWidth != lastwidth || firstDraw)
                {
                    Console.Clear();
                    drawAction.Invoke();
                    lastwidth = Console.WindowWidth;
                    firstDraw = false;
                }
                //키 입력 감지, 화면을 감지해서 커서 위치 조정. 사용자가 엔터 칠 때 까지 입력 받기.
                if (Console.KeyAvailable)
                {
                    int promptPos = Math.Max((Console.WindowWidth / 2) - 2, 0);
                    Console.SetCursorPosition(promptPos, Console.CursorTop);
                    Console.Write(">");
                    input = Console.ReadLine() ?? "";
                    break;
                }
                Thread.Sleep(100);
            }
            return input;
        }
    }
}
