using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TxtRPG.Scene;
using TxtRPG.TxtRPG.Data;
using TxtRPG.TxtRPG.Game;
using TxtRPG.TxtRPG.Scene;
using static System.Net.Mime.MediaTypeNames;

namespace TxtRPG.TxtRPG.Game.Scene
{
    public class StatusScene : Iscene
    {
        public object Run(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@$"
{player.name} {player.level}.Lv
HP {player.hp}/{player.maxHp}   MP {player.mp}/{player.maxMp}
DMG {player.damage}      {player.gold}G
EXP  {player.exp} / {player.maxExp}");
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