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
            player = new Player("");
            currentScene = new NewCharacterScene();

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
