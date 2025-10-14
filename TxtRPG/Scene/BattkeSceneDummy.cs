using System;
using TxtRPG.Scene;
using TxtRPG.TxtRPG.Data;
using TxtRPG.TxtRPG.Game;
using TxtRPG.TxtRPG.Scene;

namespace TxtRPG.TxtRPG.Game.Scene
{
    public class BattleScene : Iscene
    {
        public object Run(Player player)
        {
            Console.Clear();
            Console.WriteLine("전투 기능.");
            Console.ReadKey();
            return new TitleScene();
        }
    }
}
