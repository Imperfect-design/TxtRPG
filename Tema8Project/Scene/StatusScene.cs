using System;
using Tema8Project.Data;
using TxtRPG.Data;
using TxtRPG.Game;

namespace TxtRPG.Scene
{
    public class StatusScene : Iscene
    {
        public object Run(GameData data)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@$"
{data.Player.name} {data.Player.level}.Lv
HP {data.Player.hp}/{data.Player.maxHp}   MP {data.Player.mp}/{data.Player.maxMp}
DMG {data.Player.damage}      {data.Player.gold}G
EXP  {data.Player.exp} / {data.Player.maxExp}");
                Console.WriteLine("\n1.인벤토리 \n2.스킬보기 \n0.나가기");
                Console.Write(">>>");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        //인벤토리
                        break;
                    case 2:
                        //스킬보기
                        break;
                    case 0:
                        return new TitleScene();
                        //나가기
                        break;
                    default:
                        Console.WriteLine("잘못된 입력값입니다. 다시 입력해주세요");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}