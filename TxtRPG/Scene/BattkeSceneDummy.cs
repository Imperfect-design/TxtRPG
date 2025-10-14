using System;
using TxtRPG.Scene;
using TxtRPG.TxtRPG.Data;
using TxtRPG.TxtRPG.Data.Scene;
using TxtRPG.TxtRPG.Game;
using TxtRPG.TxtRPG.Game.Scene;

namespace TxtRPG.TxtRPG.Scene
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
