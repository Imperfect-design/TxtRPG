using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using TxtRPG.Data;
using TxtRPG.Game;

namespace TxtRPG.Scene
{
    

    public class BattleStartScene: Iscene //붙여서 수정해서 푸시하기
    {
        
        public object Run(Player player)//다시 run으로 돌려놓고 푸시하기
        {
            ShowBattle(player);
            return new TitleScene();
        }

        List<Monster> showMonsters = new List<Monster>()
            {
            //반복문 안에서 선택된 몬스터 정보 저장하기 위한 저장소
            };

         List<Monster> monsters = new List<Monster>()
            {
            new Monster("마왕", 99, 99, 99),//몬스터의 이름. 레벨, 체력, 공격력
            new Monster("사천왕", 4, 25, 40),
            new Monster("쫄따구", 1, 10, 10) //몬스터 종류를 추가하려면 여기에
            };

        int showMonsterCount;

        private void ShowBattle(Player player)
        {
            Console.Clear();

            Random randomMonsterChoice = new Random();

            showMonsterCount = randomMonsterChoice.Next(1, 5);

            Console.WriteLine("Battle!!");



            for (int i = 0; i < showMonsterCount; i++)
            {
                Monster enemy = monsters[randomMonsterChoice.Next(monsters.Count)];

                showMonsters.Add(new Monster(enemy.monsterName,enemy.monsterLevel,enemy.monsterHp,enemy.monsterAttackPower,i + 1));// 마지막은 순서
           
              Console.WriteLine($"\n\nLV.{enemy.monsterLevel} {enemy.monsterName} HP {enemy.monsterHp}");
            }

            //player Class에 접근해서 플레이어 정보 출력

            Console.WriteLine("\r\n1. 공격\r\n\r\n원하시는 행동을 입력해주세요.!");

           



            string input = Console.ReadLine();

            if (input == "1")
            {
                AttackScene();
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
                        AttackScene();
                    }

                }
            }
        }

        private void AttackScene()
        {

            Console.WriteLine("공격할 몬스터를 선택하세요:");

            List<int> monsterIndexes = new List<int>();

            for (int i = 0; i < showMonsterCount; i++)
            {
                Monster willAtkMonster = showMonsters[i];
                Console.WriteLine($"\n\n[{willAtkMonster.indexmonster}] LV.{willAtkMonster.monsterLevel} {willAtkMonster.monsterName} HP {willAtkMonster.monsterHp}");
                monsterIndexes.Add(willAtkMonster.indexmonster);
            }

            Console.Write("\n>> ");
            string input = Console.ReadLine();


            if (int.TryParse(input, out int selectedIndex)) 
            {
                if (monsterIndexes.Contains(selectedIndex))
                {
                    Monster target = showMonsters.Find(m => m.indexmonster == selectedIndex);

                    if (target.monsterIsAlive)
                    {
                        Console.WriteLine($"\n{target.monsterName}을(를) 공격합니다!");
                        
                        target.TakeDamage(10);
                        Console.WriteLine($"{target.monsterName} HP: {target.monsterHp}");

                        if (!target.monsterIsAlive)
                            Console.WriteLine($"{target.monsterName}을(를) 처치했습니다!");
                    }
                    else
                    {
                        Console.WriteLine($"{target.monsterName}은(는) 이미 쓰러졌습니다.");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 존재하지 않는 몬스터 번호입니다.");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 숫자를 입력하세요.");
            }
        }
    }
}


    public class Monster
    {
        public string monsterName { get; private set; }
        public int monsterLevel { get; private set; }
        public int monsterHp { get; private set; }
        public int monsterAttackPower { get; private set; }
        public int indexmonster { get; private set; }
        public bool monsterIsAlive { get; private set; }

        public Monster(string name, int level, int hp, int attackPower, int indexShowMonster = 0)
        {
            monsterName = name;
            monsterLevel = level;
            monsterHp = hp;
            monsterAttackPower = attackPower;
            monsterIsAlive = true;
            indexmonster = indexShowMonster;
        }

        public void TakeDamage(int damage)//플레이어가 입힌 피해에 따라 몬스터의 체력이 감소하며 사망하는 메서드
        {
            monsterHp -= damage;
            if (monsterHp <= 0)
            {
                monsterIsAlive = false;
            }
        }

    }
