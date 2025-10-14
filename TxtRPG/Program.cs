using System;
using TxtRPG.TxtRPG.Game;

namespace TxtRPG.TxtRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager game = new GameManager();
            game.Run();
        }
    }
}
