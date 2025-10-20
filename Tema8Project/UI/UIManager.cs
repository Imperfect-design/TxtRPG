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
                
                if(( c >= 0xAC00 && c <= 0xD7A3) || ( c > 127))//받침유무를 체크하는거 그냥 그때 그때 16진법
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
            //최솟값 displayLength이게 계속 움직이는 값이니까
            Console.SetCursorPosition(padding, Console.CursorTop);//Console.CursorTop: 현재 커서의 위치
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
            bool firstDraw = true;//처음 실행하려면 값이 있어야하니까 추가한거
            //커서 숨기기
            if (Console.CursorVisible)
            {
                Console.CursorVisible = false;//커서 끌 때 이렇게 쓰는거
            }

            while(true)
            {
                //콘솔 너비가 바뀌면 콘설 Clear, 새롭게 그리기
                if (Console.WindowWidth != lastwidth || firstDraw)
                {
                    Console.Clear();
                    drawAction.Invoke();//출력내용을 거기에 맞춰서 새로 그려라
                    lastwidth = Console.WindowWidth;
                    firstDraw = false;//처음창으로 돌아가면 안되니까 false로 바꾸기
                }
                //키 입력 감지, 화면을 감지해서 커서 위치 조정. 사용자가 엔터 칠 때 까지 입력 받기.
                if (Console.KeyAvailable) //입력값을 한 번 감지하면 커서가 중앙정렬되는?
                {
                    int promptPos = Math.Max((Console.WindowWidth / 2) - 2, 0);
                    Console.SetCursorPosition(promptPos, Console.CursorTop);
                    Console.Write(">");
                    input = Console.ReadLine() ?? "";//자료형없이도 입력한값을 받아라? ??:null병합연산자 왼쪽이 "null이 아니면 왼쪽 그대로 쓰고 왼쪽 null이면 오른쪽을 써라이어도(그냥 엔터만 쳐도
                    //다른 UI를 건드리기 위해서 받아오는 과정에서 매개변수가 null을 받을 수 없어서 그런 오류를 없애기 위해서
                    break;
                }
                Thread.Sleep(100);//while문을 사용할 때 cpu사용량이 0.1인데 cpu70은 됨 과부하가 올 수 있음 반복문을 쓸 때 제한을 걸어둬야함
            }
            return input;
        }
    }
}
