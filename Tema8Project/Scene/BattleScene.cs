using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using TxtRPG.Data;
using TxtRPG.Game;

namespace TxtRPG.Scene
{


    public class BattleStartScene : Iscene
    {

        public object Run(Player player,Monster monster)
        {
            ShowBattle(player,monster);
            return new TitleScene();
        }

        List<Monster> showMonsters = new List<Monster>()
        {
            //반복문 안에서 선택된 몬스터 정보 저장하기 위한 저장소
        };

        List<Monster> monsters = new List<Monster>();


        int showMonstersCount;


        private void ShowBattle(Player player, Monster monster)
        {
            Console.Clear();

            Random randomMonsterChoice = new Random();
            showMonstersCount = randomMonsterChoice.Next(1, 5);

            Console.WriteLine("Battle!!");



            for (int i = 0; i < showMonstersCount; i++)
            {
                monster = new Monster(player);
                monsters.Add(monster);

                Console.WriteLine($"\n\nLV.{monsters[i].monsterLevel} {monsters[i].monsterName} HP {monsters[i].monsterHp}");
            }


            Console.WriteLine($"\\n[내정보]\nLv.{player.level}    {player.name} ({player.job})\nHP {player.hp}/{player.maxHp} ");

            Console.Write("\n\n\n\n1. 공격\n\n원하시는 행동을 입력해주세요.!\n>>");


            string input = Console.ReadLine();

            if (input == "1")
            {
                AttackScene(player, monster);
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
                        AttackScene(player, monster);
                    }

                }
            }
        }

        private void AttackScene(Player player,Monster monster)
        {
            Console.Clear();
            Console.WriteLine("공격할 몬스터를 선택하세요:");

            for (int i = 0; i < showMonstersCount; i++)
            {
                monster.monsterIndex = i + 1;

                // monster.monsterIsAlive? monster.monsterHp.ToString() : "Dead";
                string MonsterInfo = ($"\n\n[{monster.monsterIndex}] LV.{monster.monsterLevel} {monster.monsterName} HP {monster.monsterHp}");

                if (!monster.monsterIsAlive)
                {
                    string deadMonsterInfo = MonsterInfo.Replace($"HP {monster.monsterHp}", "Dead");
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
                        monster.TakeDamage(player, monster);
                        Console.Clear();

                        while (monster.monsterIsAlive = false)
                        {
                            monster.totalMonsterHP = monster.monsterHp;

                            if ()
                            {
                                moster.currentMonsterHP = monster.monsterHp;
                            }
                        }

                        Console.WriteLine($"{player.name} 의 공격!\nLv.{monsters[i].monsterLevel} {monsters[i].monsterName} 을(를) 맞췄습니다. [데미지 : monster.playerFinalDamge]\n/n/nLv.{monsters[i].monsterLevel} {monsters[i].monsterName}\nHP {}"); //밑에 클래스 정보 수정하고 playerFinalDamge 넣고 실행되게 수정

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


    public class Monster
    {
        Random random = new Random();
        public string monsterName { get;  set; }
        public int monsterLevel { get; set; }
        public int monsterHp { get; set; }
        public int monsterAttackPower { get; set; }
        public int monsterIndex { get; set; }
        public bool monsterIsAlive { get; set; }

        public string[] names=new string[] {"마왕", "사천왕", "쫄따구"};

        int totalMonsterHP;
        int currentMonsterHP;

        public Monster(Player player)
        {
            
            monsterName = names[random.Next(names.Length)];
            monsterLevel = random.Next(Math.Max(1, player.level - 5), player.level + 6);
            monsterHp = monsterLevel*100;//밸런스 조절은 if문 써서
            monsterAttackPower = monsterLevel*20;
            monsterIsAlive = true;
            monsterIndex=0;
            
        }

        public void EnemyPhase()
        {

        }


        public void TakeDamage(Player player, Monster monster)//플레이어가 입힌 피해에 따라 몬스터의 체력이 감소하며 사망하는 메서드
        {
            double plusMinusDouble = player.damage * 0.1f;
            
           
            int playerDamage = (int)player.damage;//Player 클래스 데미지 자체를 int로 수정해야 할 것 같음
            int plusMinusInt = (int)Math.Round(plusMinusDouble);


            Random randomPlayerDamge = new Random();
            int playerFinalDamge= randomPlayerDamge.Next(playerDamage-plusMinusInt, playerDamage+plusMinusInt);//Player가 가지는 계산식은 플레이어 클래스에 넣는게? 매서드 밖에 선언하고 클래스 받아서 가져오기


           

           

            monster.monsterHp -= playerFinalDamge;
            if (monster.monsterHp <= 0)
            {
                monster.monsterIsAlive = false;
            }
        }

    }
}
