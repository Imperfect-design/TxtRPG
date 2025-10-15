using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TitleScene
{
    public void Mainmenu()
    {
        Console.Clear();
        Console.WriteLine(" 1. 상태보기");
        Console.WriteLine(" 2. 전투시작");
        Status status = new Status();

        while (true)
        {
            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                status.view();
            }

            else if (input == 2)
            {

            }
            else
            {
                Console.Write("잘못입력했습니다");
            }
        }


    }
}