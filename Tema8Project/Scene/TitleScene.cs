using System;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.UI;

namespace TxtRPG.Scene
{
    public class TitleScene : Iscene
    {
        public object Run(Player player)
        {
            string input = UIManager.ConsoleArray(() =>
            {
                UIManager.PrintTitle("시작부터 마왕나옴");
                UIManager.PrintCenter("시작부터 마왕을 만나실 당신을 환영합니다.");
                UIManager.PrintDivider("dash");
                Console.WriteLine();
                UIManager.PrintYellow("1. 상태 보기");
                UIManager.PrintRed("2. 전투 시작");
                UIManager.PrintCenter("0. 게임 종료");
                Console.WriteLine();
                UIManager.PrintCenter(">>");
            });

            switch (input)
            {
                case "1":
                    return new StatusScene();
                case "2":
                    return new BattleStartScene();
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("혹시 잘못 적으시지 않으셨습니까?.");
                    Console.ReadKey();
                    break;
            }
            return this;
        }
    }
}
