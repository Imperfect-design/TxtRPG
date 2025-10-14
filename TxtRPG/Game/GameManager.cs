using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtRPG.TxtRPG.Data;

namespace TxtRPG.TxtRPG.Game
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
      