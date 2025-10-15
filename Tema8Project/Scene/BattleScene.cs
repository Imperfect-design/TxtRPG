//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Security.Cryptography;
//using System.Threading;
//using TxtRPG.Data;
//using TxtRPG.Game;

//namespace TxtRPG.Scene
//{


//    public class BattleStartScene : Iscene
//    {

//        public object Run(Player player,Monster monster)
//        {
//            ShowBattle(player,monster);
//            return new TitleScene();
//        }

//        List<Monster> showMonsters = new List<Monster>()
//        {
//            //반복문 안에서 선택된 몬스터 정보 저장하기 위한 저장소
//        };

//        List<Monster> monsters = new List<Monster>()
//            {
//            new Monster("마왕", 99, 99, 99),//몬스터의 이름. 레벨, 체력, 공격력
//            new Monster("사천왕", 4, 25, 40),
//            new Monster("쫄따구", 1, 10, 10) //몬스터 종류를 추가하려면 여기에
//            };

//        int showMonsterCount;
       

//        private void ShowBattle(Player player, Monster monster)
//        {
//            Console.Clear();

//            Random randomMonsterChoice = new Random();

//            showMonsterCount = randomMonsterChoice.Next(1, 5);

//            Console.WriteLine("Battle!!");



//            for (int i = 0; i < showMonsterCount; i++)
//            {
//                Monster enemy = monsters[randomMonsterChoice.Next(monsters.Count)];

//                showMonsters.Add(new Monster(enemy.monsterName, enemy.monsterLevel, enemy.monsterHp, enemy.monsterAttackPower, i + 1));// 마지막은 순서

//                Console.WriteLine($"\n\nLV.{enemy.monsterLevel} {enemy.monsterName} HP {enemy.monsterHp}");
//            }

//            int playerLevel = player.level;
//            string playername= player.name;
//            string playerJob = player.job; ;
//            int playerCurrentHP = player.hp;
//            int playerMaxHp = player.maxHp; ;


//            Console.WriteLine($"\\n[내정보]\nLv.{playerLevel}    {playername} ({playerJob})\nHP {playerCurrentHP}/{playerMaxHp} ");

//            Console.Write("\n\n\n\n1. 공격\n\n원하시는 행동을 입력해주세요.!\n>>");


//            string input = Console.ReadLine();

//            if (input == "1")
//            {
//                AttackScene(player, monster);
//            }
//            else
//            {
//                while (input != "1")
//                {
//                    Console.WriteLine("잘못된 입력입니다.");
//                    Console.Write(">>");
//                    input = Console.ReadLine();
//                    if (input == "1")
//                    {
//                        AttackScene(player, monster);
//                    }

//                }
//            }
//        }

//        private void AttackScene(Player player,Monster monster)
//        {
//            Console.Clear();
//            Console.WriteLine("공격할 몬스터를 선택하세요:");

//            List<int> monsterIndexes = new List<int>();

//            for (int i = 0; i < showMonsterCount; i++)
//            {
//                Monster willAtkMonster = showMonsters[i];
//                Console.WriteLine($"\n\n[{willAtkMonster.indexmonster}] LV.{willAtkMonster.monsterLevel} {willAtkMonster.monsterName} HP {willAtkMonster.monsterHp}");
//                monsterIndexes.Add(willAtkMonster.indexmonster);

//            }

//            Console.Write("\n>> ");
//            string input = Console.ReadLine();


//            if (int.TryParse(input, out int selectIndex))
//            {
//                if (selectIndex== monster.indexmonster)
//                {
//                    Monster target = showMonsters.);

//                    if (target.monsterIsAlive)
//                    {
//                        Console.WriteLine($"\n{target.monsterName}을(를) 공격합니다!");

//                        target.TakeDamage(player.damage);

//                        Console.WriteLine($"{target.monsterName} HP: {target.monsterHp}");

//                        if (!target.monsterIsAlive)
//                            Console.WriteLine($"{target.monsterName}을(를) 처치했습니다!");
//                    }
//                    else
//                    {
//                        Console.WriteLine($"{target.monsterName}은(는) 이미 쓰러졌습니다.");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("잘못된 입력입니다. 존재하지 않는 몬스터 번호입니다.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("잘못된 입력입니다. 숫자를 입력하세요.");
//            }
//        }




//    }


//    public class Monster
//    {
//        public string monsterName { get; private set; }
//        public int monsterLevel { get; private set; }
//        public int monsterHp { get; private set; }
//        public int monsterAttackPower { get; private set; }
//        public int indexmonster { get; private set; }
//        public bool monsterIsAlive { get; private set; }

//        public Monster(string name, int level, int hp, int attackPower, int indexShowMonster = 0)
//        {
//            monsterName = name;
//            monsterLevel = level;
//            monsterHp = hp;
//            monsterAttackPower = attackPower;
//            monsterIsAlive = true;
//            indexmonster = indexShowMonster;
//        }

//        public void TakeDamage(int playerDamege)//플레이어가 입힌 피해에 따라 몬스터의 체력이 감소하며 사망하는 메서드
//        {

//            monsterHp -= playerDamege;
//            if (monsterHp <= 0)
//            {
//                monsterIsAlive = false;

//            }
//        }

//    }
//}
