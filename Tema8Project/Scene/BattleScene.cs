using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using Tema8Project.Data;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace TxtRPG.Scene
{


    public class BattleStartScene : Iscene
    {
        public object Run(GameData data)
        {
            ShowBattle(data);
            return null;
        }

        int showMonstersCount;

        bool cheakAllMonsterNoDead=true;

        string monsterList;
        


        private void printList(GameData data)
        {
            for (int i = 0; i < showMonstersCount; i++)//몬스터 정보를 저장하기 위해서 몬스터 생성하는 반복문 분리 
            {
                Monster monster = new Monster(data);
                data.monsters.Add(monster);
                
                
                if (!data.monsters[i].monsterIsAlive)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    monsterList = $"\n\nLV.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName} Dead";
                }
                else
                {
                    monsterList = $"\n\nLV.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName} HP {data.monsters[i].monsterHp}";
                }

                if (monster.monsterIsAlive)
                {
                    cheakAllMonsterNoDead = true;
                }
                else
                {
                    cheakAllMonsterNoDead = false;
                    //결과화면 가기
                }


                    Console.WriteLine(monsterList);
            }
        }


        private void printList2(GameData data)
        {
            for (int i = 0; i < showMonstersCount; i++)//몬스터 정보를 저장하기 위해서 몬스터 생성하는 반복문 분리 
            {
                Monster monster = new Monster(data);
                data.monsters.Add(monster);


                if (!data.monsters[i].monsterIsAlive)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    monsterList = $"\n\n[{i+1}] LV.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName} Dead";
                }
                else
                {
                    monsterList = $"\n\n[{i+1}] LV.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName} HP {data.monsters[i].monsterHp}";
                }

                if (monster.monsterIsAlive)
                {
                    cheakAllMonsterNoDead = true;
                }
                else
                {
                    cheakAllMonsterNoDead = false;
                    //결과화면 가기
                }


                Console.WriteLine(monsterList);
            }
        }





        private void ShowBattle(GameData data)//매서드 사용해서 하나로 묶어서 AttackScene 없애기
        {
            Random randomMonsterChoice = new Random();
            showMonstersCount = randomMonsterChoice.Next(1, 5);

            Console.Clear();
            Console.WriteLine("Battle!!");

            printList(data);


                Console.WriteLine($"\n\n[내정보]\nLv.{data.Player.level}    {data.Player.name} ({data.Player.job})\nHP {data.Player.hp}/{data.Player.maxHp} ");
                Console.Write("\n\n\n\n1. 공격\n\n2.취소\n\n원하시는 행동을 입력해주세요.!\n>>");
                int input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    PlayerTurn(data);
                }

                else if(input == 2)
                {
                    //TitleScene?
                }
                else
                {
                    while (input != 1)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.Write(">>");
                        input = int.Parse(Console.ReadLine());
                        if (input == 1)
                        {
                            PlayerTurn(data);
                        }
                    }
                }
        }
        

        private void PlayerTurn(GameData data)
        {
            Console.Clear();

            Console.WriteLine("공격할 몬스터를 선택하세요");
            
            printList2(data);


            Console.Write("\n>> ");
            string inputStr = Console.ReadLine();//입력값 받아서
            int inputInt = int.Parse(inputStr);
            data.PlayerInput = inputInt-1;

            for (int i = 0; i < data.monsters.Count; i++)//리스트에 있는 몬스터를 싹 다 훑어서
            {
                if (inputInt == data.monsters[i].monsterIndex)//리스트에 있는걸 유저가 선택하면(Length 활용)
                {
                    if (data.monsters[i].monsterIsAlive)//일단 살아있는지 먼저 확인하고 살아있으면 TakeDamage를 실행시켜
                    {
                        Console.Clear();

                        beforeMonsterHP = data.monsters[i].monsterHp;
                        int finalDamage = playerFinalDamage(data);
                        HitMonster(data);
                        currentMonsterHP = data.monsters[i].monsterHp - finalDamage;

                        
                        

                        string a = $"{data.Player.name} 의 공격!" +
                            $"\nLv.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName} 을(를) 맞췄습니다. [데미지 : {finalDamage}]" +
                            $"\n\n\nLv.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName}" +
                            $"\nHP {beforeMonsterHP} -> {currentMonsterHP}" +
                            $"\n\n0. 다음" +
                            $"\n\n\n>>";


                        if(currentMonsterHP<=0)
                        {
                            a=a.Replace($"{currentMonsterHP}", "Dead");
                        }

                        Console.WriteLine(a);
                        inputStr = Console.ReadLine();
                        inputInt = int.Parse(inputStr);

                        if (inputInt == 0)
                        {
                            EnemyTurn(data);
                        }


                    }


                    else if (inputInt - 1 != data.monsters[i].monsterIndex || !data.monsters[i].monsterIsAlive)
                    {
                        while (inputInt - 1 != data.monsters[i].monsterIndex || !data.monsters[i].monsterIsAlive)
                        {
                            Console.WriteLine($"잘못된 입력입니다.");
                            Console.ReadLine();
                        }
                    }


                }
            }
        }
        int beforeMonsterHP;
        int currentMonsterHP;
        int beforePlayerHP;
        int currentPlayerHP;
        private void EnemyTurn(GameData data)
        {
            Console.Clear();
             
                foreach (Monster monster in data.monsters)
                {
                    if (monster.monsterIsAlive == false)
                    {
                        continue;
                    }

                    beforePlayerHP = data.Player.hp;
                    HitPlayer(data);
                    currentPlayerHP = data.Player.hp;

                    string a = $"Lv.{monster.monsterLevel} {monster.monsterName} 의 공격!" +
                               $"\n{data.Player.name}을(를) 맞췄습니다.    [데미지 : {monster.monsterAttackPower}]" +
                               $"\nLv.{data.Player.level} {data.Player.name}" +
                               $"\nHP {beforePlayerHP}->{currentPlayerHP}" +
                               $"\n\n\n0. 계속하기 " +
                               $"\n1. 도망치기"+
                               $"\n대상을 선택해주세요" +
                               $"\n>>";
                    Console.Write(a);
                }

            string input = Console.ReadLine();

            if (input == "0" && cheakAllMonsterNoDead == false)
            {
                Console.WriteLine("결과화면으로");//결과화면
            }

            else if (input == "0")
            {
                PlayerTurn(data);
            }

            else if (input == "1")
            {
                //Title로 돌아가기?
            }

            else
            {
                while (input != "0")
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.Write(">>");
                    input = Console.ReadLine();

                }
            }
            
        }

        public void HitPlayer(GameData data)
        {
            data.Player.hp -= data.Monster.monsterAttackPower;
            
        }

        public void HitMonster(GameData data)//여기에 input값을 넣어서 쓰고 싶어서 playerInput을 만들어서 여기 리드라인 썼다가 빠꾸
        {
            data.monsters[data.PlayerInput].monsterHp -= data.Player.damage;
            if (data.monsters[data.PlayerInput].monsterHp <= 0)
            {
                data.monsters[data.PlayerInput].monsterIsAlive = false;
            }
        }


        public int playerFinalDamage(GameData data)//좀... 너저분하게 만들어둠 수정 필요ㅠ 이거 매서드 밖으로 빼서 수정

        {
            double plusMinusDouble = data.Player.damage * 0.1f;
            int playerDamage = (int)data.Player.damage;//Player 클래스 데미지 자체를 int로 수정하는게 더 낫지 않을까?.?
            int plusMinusInt = (int)Math.Round(plusMinusDouble);


            Random randomPlayerDamge = new Random();
            int playerFinalDamage = randomPlayerDamge.Next(playerDamage - plusMinusInt, playerDamage + plusMinusInt);//Player가 가지는 계산식은 플레이어 클래스에 넣는게? 매서드 밖에 선언하고 클래스 받아서 가져오기

            return playerFinalDamage;
        }

        public void AddItems(GameData data)//요런식으로 추가
        {
            if (data.Monster.monsterIsAlive ==false)
            {
                data.Player.inventory.AddItem(new Item("낡은 마법서", 0, 1, 5, 0, 0, 0, 20));
            }


        }
    }
}
