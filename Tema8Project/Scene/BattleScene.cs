
using Tema8Project.Data;
using TxtRPG.Game;


namespace TxtRPG.Scene
{


    public class BattleStartScene(GameData data) : Iscene
    {
        public object Run(GameData data)
        {
            ShowBattle(data);
            return new TitleScene();
        }


       
        List<Monster> monsters = new List<Monster>();


        int showMonstersCount;


        private void ShowBattle(GameData data)
        {
            Console.Clear();

            Random randomMonsterChoice = new Random();
            showMonstersCount = randomMonsterChoice.Next(1, 5);

            Console.WriteLine("Battle!!");



            for (int i = 0; i < showMonstersCount; i++)
            {
                Monster monster = new Monster(data);

                int monsterLevel = randomMonsterChoice.Next(Math.Max(1, data.Player.level -3), data.Player.level + 6); //플레이어의 레벨을 기준으로 +6, -3,사이에서 몬스터의 레벨을 할당하는데 최소레벨이 1 밑으로 내려가지 않게 하기
                monsters.Add(monster);

                Console.WriteLine($"\n\nLV.{monsters[i].monsterLevel} {monsters[i].monsterName} HP {monsters[i].monsterHp}");
            }


            Console.WriteLine($"\\n[내정보]\nLv.{data.Player.level}    {data.Player.name} ({data.Player.job})\nHP {data.Player.hp}/{data.Player.maxHp} ");

            Console.Write("\n\n\n\n1. 공격\n\n원하시는 행동을 입력해주세요.!\n>>");


            string input = Console.ReadLine();

            if (input == "1")
            {
                AttackScene(data);
            }
            else
            {
                while (input != "1")
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.Write(">>");
                    input = Console.ReadLine();
                    if (input == "1")
                    {
                        AttackScene(data);
                    }

                }
            }
        }

        private void AttackScene(GameData data)
        {
            Console.Clear();
            Console.WriteLine("공격할 몬스터를 선택하세요:");

            for (int i = 0; i < showMonstersCount; i++)
            {
                monsters[i].monsterIndex = i + 1;

                string MonsterInfo = ($"\n\n[{monsters[i].monsterIndex}] LV.{monsters[i].monsterLevel} {monsters[i].monsterName} HP {monsters[i].monsterHp}");

                if (!monsters[i].monsterIsAlive)
                {
                    string deadMonsterInfo = MonsterInfo.Replace($"HP {monsters[i].monsterHp}", "Dead");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    MonsterInfo = deadMonsterInfo;
                }
                Console.WriteLine(MonsterInfo);
            }


            Console.Write("\n>> ");
            string inputStr = Console.ReadLine();
            int inputInt = int.Parse(inputStr);


            for (int i = 0; i < monsters.Count; i++)
                if (inputInt-1 == monsters[i].monsterIndex)
            {
                    if (monsters[i].monsterIsAlive)
                    {
                        monsters[i].TakeDamage(data);
                        Console.Clear();

                        

                        Console.WriteLine($"{data.Player.name} 의 공격!\nLv.{monsters[i].monsterLevel} {monsters[i].monsterName} 을(를) 맞췄습니다. [데미지 : monster.playerFinalDamge]\n/n/nLv.{monsters[i].monsterLevel} {monsters[i].monsterName}\nHP"); 
                        //밑에 클래스 정보 수정하고 playerFinalDamge 넣고 실행되게 수정

                    }
                    else if (!monsters[i].monsterIsAlive)
                    {
                        Console.WriteLine($"잘못된 입력입니다.");
                    }
                
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 숫자를 입력하세요.");
            }
        }

        

    }


    
}
