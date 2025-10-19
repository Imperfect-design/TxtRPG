using System;
using TxtRPG.Data;
using TxtRPG.Scene;

namespace TxtRPG.Game
{
    public class GameManager
    {
        //전역으로 선언. Iscene이 이 역할을 해주고 있기 때문에 불필요.
        public static GameData data;
        private object currentScene;
        public void Run()
        {
            //게임 데이터 생성 및 시작 화면 설정
            data = new GameData();
            currentScene = new NewCharacterScene();

            //Iscene을 상속한 클래스만 실행 Or 종료
            while (currentScene != null)
            {
                if (currentScene is Iscene scene)
                {
                    LogManager.Clear();
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
