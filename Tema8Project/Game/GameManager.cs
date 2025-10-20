using System;
using TxtRPG.Data;
using TxtRPG.Scene;
using System.Text.Json;
using System.IO;


namespace TxtRPG.Game
{
    public class GameManager
    {
        //전역으로 선언. Iscene이 이 역할을 해주고 있기 때문에 불필요.
        private object currentScene;
        public void Run()
        {
            //게임 데이터 생성 및 시작 화면 설정
            GameData data = new GameData();
            currentScene = new NewCharacterScene();

            //Iscene을 상속한 클래스만 실행 Or 종료
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

    private const string Save = "saveData.json";

        public void SaveGame(GameData data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(Save, json);
                LogManager.Add("저장 성공");
            }
            catch (Exception ex)
            {
                LogManager.Add($"저장 실패: {ex.Message}");
            }
        }
        public GameData Load()
        {
            try
            {
                if (File.Exists(Save))
                {
                    string json = File.ReadAllText(Save);
                    GameData loadedData = JsonSerializer.Deserialize<GameData>(json, new JsonSerializerOptions
                    {
                        IncludeFields = true, 
                        PropertyNameCaseInsensitive = true,  
                        WriteIndented = true
                    }) ?? new GameData();
                    LogManager.Add("저장된 게임을 불러왔습니다.");
                    return loadedData;
                }
                else
                {
                    LogManager.Add("저장된 데이터가 없습니다.");
                    return new GameData();
                }
            }
            catch (Exception ex)
            {
                LogManager.Add($"불러오기 실패: {ex.Message}");
                return new GameData();
            }
        }
    }
}
