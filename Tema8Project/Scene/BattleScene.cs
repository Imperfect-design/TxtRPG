using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using Tema8Project.Data;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.UI;


namespace TxtRPG.Scene
{


    public class BattleStartScene : Iscene
    {
        public object Run(GameData data)
        {
            ShowBattle(data);
            return null;
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

               
                monsters.Add(monster);

                Console.WriteLine($"\n\nLV.{monsters[i].monsterLevel} {monsters[i].monsterName} HP {monsters[i].monsterHp}");
            }


            Console.WriteLine($"\n\n[내정보]\nLv.{data.Player.level}    {data.Player.name} ({data.Player.job})\nHP {data.Player.hp}/{data.Player.maxHp} ");

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
            Console.WriteLine("공격할 몬스터를 선택하세요");

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

            //변수 하나에 체력 정보를 넣기 반복문은 데미지 받기 전에 데미지를 주기 전에 미포hp에 변수에 저장을 해두고 데미지깎는 메서드 실행하기

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
                        //여기 체력 떨어지는 시스템 만들어두기
                        Console.WriteLine($"{data.Player.name} 의 공격!\nLv.{monsters[i].monsterLevel} {monsters[i].monsterName} 을(를) 맞췄습니다. [데미지 : monster.playerFinalDamge]\n\n\nLv.{monsters[i].monsterLevel} {monsters[i].monsterName}\nHP 추가하기 -> 추가하기\n\n0. 다음\n\n\n>>");
                        Console.Read();
                    }
                    else if(inputInt==0)
                    {
                        EnemyPhase();
                    }

                    else if (!monsters[i].monsterIsAlive)
                    {
                        while (inputInt - 1 != monsters[i].monsterIndex && !monsters[i].monsterIsAlive)
                        {
                            Console.WriteLine($"잘못된 입력입니다.");
                            Console.ReadLine();
                        }
                    }

                    else
                    {
                        while (inputInt - 1 != monsters[i].monsterIndex && !monsters[i].monsterIsAlive)
                        {
                            Console.WriteLine($"잘못된 입력입니다.");
                            Console.ReadLine();
                        }
                    }
                }
        }

        private void EnemyPhase()
        {
            foreach (Monster monster in monsters)
            {
                if (monster.monsterIsAlive == false)
                {
                    continue;
                }

                Console.Clear();
                Console.WriteLine($"Battle!!\n\nLv.{monsters.monsterLevel}");
            }
        }

        public void TakeDamage(GameData data)//플레이어가 입힌 피해에 따라 몬스터의 체력이 감소하며 사망하는 메서드
        {
            double plusMinusDouble = data.Player.damage * 0.1f;


            int playerDamage = (int)data.Player.damage;//Player 클래스 데미지 자체를 int로 수정하는게 더 낫지 않을까?.?
            int plusMinusInt = (int)Math.Round(plusMinusDouble);


            Random randomPlayerDamge = new Random();
            int playerFinalDamage = randomPlayerDamge.Next(playerDamage - plusMinusInt, playerDamage + plusMinusInt);//Player가 가지는 계산식은 플레이어 클래스에 넣는게? 매서드 밖에 선언하고 클래스 받아서 가져오기


            ////int beforeMonsterHP = monsters[i].monsterHp;
            //int currentMonsterHP;


            //monsters[i].monsterHp -= playerFinalDamage;
            //if (monster.monsterHp <= 0)
            //{
            //    monster.monsterIsAlive = false;
            //    //드랍템 추가?
            //}
            //data.Player.inventory.AddItem(new Item { });
            //currentMonsterHP = monster.monsterHp;



        }


    }


    
}
