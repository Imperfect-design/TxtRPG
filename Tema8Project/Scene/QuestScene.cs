using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtRPG;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.Scene;
using TxtRPG.UI;

namespace TxtRPG.Scene
{
    public class QuestScene : Iscene
    {
        //static으로 선언했기 때문에 BattleScene에도 공유 가능. 그 외 기본 필드.
        public static List<QuestScene> quests = new List<QuestScene>();
        public string monsterName;
        public int killCount;
        public int reward;
        public bool isAccept;
        Random rand = new Random();
        //퀘스트 생성
        public QuestScene(GameData data)
        {
            monsterName = data.monsterNames[rand.Next(data.monsterNames.Length)];
            killCount = 5 + (data.Player.level - 1) * rand.Next(1, 11);
            reward = killCount * 20;
            isAccept = false;
        }
        //퀘스트 3개까지 만든다.
        public void CreateQuests(GameData data)
        {
            if(quests.Count != 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    quests.Add(new QuestScene(data));
                }
            }
        }
        public object Run(GameData data)
        {
            return ShowQuests(data);
        }
        //퀘스트 보여주는 Scene, 
        private object ShowQuests(GameData data)
        {
            CreateQuests(data);
            while (true)
            {
                Console.Clear();
                UIManager.PrintTitle("=== 퀘스트 목록 ===");
                for (int i = 0; i < quests.Count; i++)
                {
                    string status = quests[i].isAccept ? "[수락됨]" : "";
                    UIManager.PrintCenterLine($"[{i + 1}] {quests[i].monsterName} {quests[i].killCount}마리 처치 (보상: {quests[i].reward}G){status}");
                }
                LogManager.Show();

                UIManager.PrintDivider("line");
                UIManager.PrintCenterLine("");
                UIManager.PrintCenterLine("수락할 퀘스트 번호 입력 (0: 거절하고 새로고침 / 4번을 누르면 나갑니다.): ");
                //int input = int.Parse(Console.ReadLine());

                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    LogManager.Add("숫자를 입력해주세요.");
                    continue;
                }
                //수락하지 않은 퀘스트 새로고침
                if (input == 0)
                {
                    for (int i = 0; i < quests.Count; i++)
                    {
                        if (!quests[i].isAccept)
                        {
                            quests[i] = CreateOneQuest(data);
                        }
                    }
                }
                else if (input >= 1 && input <= quests.Count)
                {
                    if (!quests[input - 1].isAccept)
                    {
                        quests[input - 1].isAccept = true;
                        LogManager.Add($"{input}번 퀘스트를 수락하였습니다!");
                    }
                    else
                    {
                        LogManager.Add($"{input}번의 퀘스트는 이미 수락상태입니다.");
                    }
                }
                else
                {
                    return new TitleScene();
                }
            }
        }
        //BattleScene에서 확인 위해 public static으로 선언
        public static void CheckQuest(string MonsterName, GameData data)
        {
            foreach (var check in quests.ToList())
            {
                if (check.isAccept && check.monsterName == MonsterName && check.killCount > 0)
                {
                    check.killCount--;
                    LogManager.Add($"퀘스트 진행: {check.monsterName} 남은 수 {check.killCount}");

                    if (check.killCount == 0)
                    {
                        LogManager.Add($"퀘스트 완료! {check.reward} 골드 획득!");
                        data.Player.gold += check.reward;
                        quests.Remove(check);
                        quests.Add(new QuestScene(data));
                    }
                }
            }
        }
        public QuestScene CreateOneQuest(GameData data)
        {
            return new QuestScene(data);
        }
    }
}
