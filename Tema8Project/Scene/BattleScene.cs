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



        List<Monster> monsters = new List<Monster>();
        Random rand = new Random();


        private void ShowBattle(GameData data)
        {
            string str = "";
            for (int i = 0; i < rand.Next(1, 5); i++)
                monsters.Add(new Monster(data));
            LogManager.Add("전투시작!");
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < monsters.Count; i++)
                    UIManager.PrintCenter($"{monsters[i].monsterName} {monsters[i].monsterLevel}.LV HP : {monsters[i].monsterHp}/{monsters[i].monsterMaxhp} DMG : {monsters[i].monsterAttackPower}");
                LogManager.Show();
                Console.WriteLine("\n\n\n\n\n1.공격하기 2.포션사용하기 3.도망가기");
                Console.WriteLine(str);
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        ShowAtack(data);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        str = "다시입력해주세요";
                        break;
                }
            }
        }
        public void ShowAtack(GameData data)
        {
            string str = "";
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < monsters.Count; i++)
                    UIManager.PrintCenter($"[{i+1}]{monsters[i].monsterName} {monsters[i].monsterLevel}.LV HP : {monsters[i].monsterHp}/{monsters[i].monsterMaxhp} DMG : {monsters[i].monsterAttackPower}");
                LogManager.Show();
                Console.Write($"\n\n\n\n\n공격대상의 번호를 입력하세요 0.뒤로가기{str} : ");
                int input = int.Parse(Console.ReadLine())-1;
                if (input >= 0 && input < monsters.Count)
                {
                    LogManager.Add($"{monsters[input].monsterName}을(를) 공격하여 {data.Player.damage}만큼 피해를 입혔다!");
                    monsters[input].TakeDamage(data);
                    if (monsters[input].monsterHp <= 0)
                        monsters.RemoveAt(input);
                    break;
                }
                else
                    str = "다시입력해주세요";
                    continue;
            }
        }

            /*
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
                PlayerTurn(data);
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
                        PlayerTurn(data);
                    }

                }
            }
        }

        private void PlayerTurn(GameData data)
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


            for (int i = 0; i < monsters.Count; i++)//리스트에 있는 몬스터를 싹 다 훑어서
                if (inputInt-1 == monsters[i].monsterIndex)//유저가 입력한 값이랑 몬스터 리스트의 인덱스가 같으면
                {
                    if (monsters[i].monsterIsAlive)//일단 살아있는지 먼저 확인하고 살아있으면 TakeDamage를 실행시켜
                    {
                        Console.Clear();

                        beforeMonsterHP = monsters[i].monsterHp;
                        int finalDamage= TakeDamageMonster(data);
                        
                        currentMonsterHP = monsters[i].monsterHp;

                        string a= $"{data.Player.name} 의 공격!" +
                            $"Lv.{monsters[i].monsterLevel} {monsters[i].monsterName} 을(를) 맞췄습니다. [데미지 : {finalDamage}]" +
                            $"" +
                            $"" +
                            $"" +
                            $"Lv.{monsters[i].monsterLevel} {monsters[i].monsterName}" +
                            $"" +
                            $"HP {beforeMonsterHP} -> {currentMonsterHP}" +
                            $"" +
                            $"" +
                            $"0. 다음" +
                            $"" +
                            $"" +
                            $"" +
                            $">>";
                        Console.WriteLine(a);
                        Console.ReadLine();
                    }
                    

                    else if(inputInt - 1 != monsters[i].monsterIndex || !monsters[i].monsterIsAlive)
                    {
                        while (inputInt - 1 != monsters[i].monsterIndex || !monsters[i].monsterIsAlive)
                        {
                            Console.WriteLine($"잘못된 입력입니다.");
                            Console.ReadLine();
                        }
                    }

                    else if (inputInt == 0)
                    {
                        EnemyTurn(data);
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
            foreach (Monster monster in monsters)
            {
                if (monster.monsterIsAlive == false)
                {
                    continue;
                }

                beforePlayerHP=data.Player.hp;
                TakeDamagePlayer(data);
                currentPlayerHP=data.Player.hp;

                string a = $"Lv.{monster.monsterLevel} {monster.monsterName} 의 공격!" +
                           $"{data.Player.name}을(를) 맞췄습니다.    [데미지 : {monster.monsterAttackPower}]" +
                           $"Lv.{data.Player.name}" +
                           $"HP {beforePlayerHP}->{currentPlayerHP}" +
                           $"" +
                           $"" +
                           $"0. 다음 " +
                           $"" +
                           $"대상을 선택해주세요" +
                           $">>";
                Console.Write(a);
                string input=Console.ReadLine();

                if (input == "0")
                {
                    PlayerTurn(data);
                }
                else
                {
                    while (input != "0")
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.Write(">>");
                        input = Console.ReadLine();
                        if (input == "0")
                        {
                            PlayerTurn(data);
                        }

                    }
                }

            }
        }

        
         public void TakeDamagePlayer(GameData data)
         {
            data.Player.hp -= data.monster.monsterAttackPower;
         }



        public int playerFinalDamage(GameData data)//너무 이상하게 만들어둠 수정 필요
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
            if (data.monster.monsterIsAlive = false)
            {
                data.Player.inventory.AddItem(new Item("낡은 마법서", 0, 1, 5, 0, 0, 0, 20));
            }


        }


    }



}*/
        }
    }
