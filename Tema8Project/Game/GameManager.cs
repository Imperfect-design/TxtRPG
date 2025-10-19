using System;
using TxtRPG.Data;
using TxtRPG.Scene;

namespace TxtRPG.Game
{
    public class GameManager
    {
        public static GameData data;
        private object currentScene;
        public void Run()
        {
            data = new GameData();
            currentScene = new NewCharacterScene();

            while (currentScene != null)
            {
                if (currentScene is Iscene scene)
                {
                    currentScene = scene.Run(data);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
