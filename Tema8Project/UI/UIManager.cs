using System;
using TxtRPG.Data;

namespace TxtRPG.UI
{
    public static class UIManager
    {
        public static void PrintTitle(string title)
        {
            Console.WriteLine("=====");
            Console.WriteLine($"{title}");
            Console.WriteLine("=====");
        }
        public static void PrintText(string text)
        {
            Console.WriteLine(text);
        }
        public static void PrintStatus(Player player)
        {
            Console.WriteLine($@"
{player.name} {player.level}.Lv
HP {player.hp}/{player.maxHp}   MP {player.mp}/{player.maxMp}
DMG {player.damage}      {player.gold}G
EXP  {player.exp} / {player.maxExp}");
        }

    }
}
