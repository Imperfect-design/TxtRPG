using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema8Project.Data;
using TxtRPG;
using TxtRPG.Data;
using static Tema8Project.Scene.QuestScene;

namespace Tema8Project.Scene
{
    public class QuestScene
    {
        public List<QuestScene> quests = new List<QuestScene>();

        public string monsterName;
        public int killCount;
        public int reward;
        public bool isAccept;
        Random rand = new Random();

        public QuestScene(GameData data)
        {
            monsterName = data.monster.names[rand.Next(data.monster.names.Length)];
            killCount = 5 + (data.Player.level - 1) * rand.Next(1, 11);
            reward = killCount * 20;
            isAccept = false;
        }


        public void CreateQuests(GameData data)
        {
            quests.Clear();
            for (int i = 0; i < 3; i++)
            {
                quests.Add(new QuestScene(data));
            }
        }


        public void ShowQuests(GameData data)
        {
            Console.Clear();
            Console.WriteLine("=== 퀘스트 목록 ===");
            for (int i = 0; i < quests.Count; i++)
            {
                string status = quests[i].isAccept ? "[수락됨]" : "";
                Console.WriteLine($"[{i + 1}] {quests[i].monsterName} {quests[i].killCount}마리 처치 (보상: {quests[i].reward}G){status}");
            }

            Console.WriteLine("수락할 퀘스트 번호 입력 (0: 거절하고 새로고침): ");
            int input = int.Parse(Console.ReadLine());

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

                ShowQuests(data);
            }
            else
            {
                LogManager.Add("다시입력해주세요");
                ShowQuests(data);
            }

        }

        public void CheckQuest(string MonsterName, GameData data)
        {
            foreach (var check in quests)
            {
                if (check.isAccept && check.monsterName == MonsterName && check.killCount > 0)
                {
                    check.killCount--;
                    Console.WriteLine($"퀘스트 진행: {check.monsterName} 남은 수 {check.killCount}");

                    if (check.killCount == 0)
                    {
                        LogManager.Add($"퀘스트 완료! {check.reward} 골드 획득!");
                        data.Player.gold += check.reward;
                        quests.Remove(check);
                        quests.Add(CreateOneQuest(data));
                        break;
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
