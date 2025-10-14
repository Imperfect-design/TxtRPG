using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtRPG.Game
{
    public class GameManager
    {
        public static Player player;
        private object currentScene;

        public GameManager()
        {
            currentScene = new TitleScene();
        }

        public void Run()
        {
            while (currentScene != null)
            {
                currentScene = 
            
        }
    }
}
