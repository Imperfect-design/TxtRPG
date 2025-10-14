using System;

public class TitleScene
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("이제 전투를 시작할 수 있습니다\n");
        Console.WriteLine("1. 상태 보기");
        Console.WriteLine("2. 전투 시작");
        Console.WriteLine("\n원하시는 행동을 입력해 주세요. \n >> ");

        string input = Console.ReadLine();

        switch(input)
        {
            case "1": StatusScene.Run();
                break;
            case "2": BattleScene.Run();
                break;
            default: Console.WriteLine("잘못된 입력입니다.");
                Console.ReadKey();
                Run();
                break;
        }
    }
}