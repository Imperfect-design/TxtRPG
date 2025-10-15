using System;
using TxtRPG.Data;
using TxtRPG.Scene;

namespace TxtRPG.Game
{
    public class GameManager
    {
        public static Player player;
        private object currentScene;

        public void Run()
        {
            Console.Write("플레이어의 이름을 입력하시오: ");
            string name = Console.ReadLine();
            player = new Player(name);

            currentScene = new TitleScene();

            while (currentScene != null)
            {
                if (currentScene is Iscene scene)
                {
                    currentScene = scene.Run(player);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
