using System;
using Tema8Project;
using TxtRPG.Game;

namespace TxtRPG
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
