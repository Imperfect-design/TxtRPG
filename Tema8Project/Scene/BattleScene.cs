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

        List<Monster> monsters = new List<Monster>()
            {
            new Monster("마왕", 99, 99, 99),//몬스터의 이름. 레벨, 체력, 공격력
            new Monster("사천왕", 4, 25, 40),
            new Monster("쫄따구", 1, 10, 10) //몬스터 종류를 추가하려면 여기에
            };

        int showMonsterCount;
       

        private void ShowBattle(Player player, Monster monster)
        {
            Console.Clear();

            Random randomMonsterChoice = new Random();

            showMonsterCount = randomMonsterChoice.Next(1, 5);

            Console.WriteLine("Battle!!");



            for (int i = 0; i < showMonsterCount; i++)
            {
                Monster enemy = monsters[randomMonsterChoice.Next(monsters.Count)];

                showMonsters.Add(new Monster(enemy.monsterName, enemy.monsterLevel, enemy.monsterHp, enemy.monsterAttackPower, i + 1));// 마지막은 순서

                Console.WriteLine($"\n\nLV.{enemy.monsterLevel} {enemy.monsterName} HP {enemy.monsterHp}");
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

              for (int i = 0; i < showMonsterCount; i++)
              {
                monster.monsterIndex = i + 1;
                Console.WriteLine($"\n\n[{monster.monsterIndex}] LV.{monster.monsterLevel} {monster.monsterName} HP {monster.monsterHp}");
              }

            Console.Write("\n>> ");
            string input = Console.ReadLine();


            if (int.TryParse(input, out int selectIndex))
            {
                if (selectIndex-1== 1)
                {
                    monster.TakeDamage(player, monster);
                    
                    if (monster.monsterIsAlive)
                    {
                        Console.WriteLine($"\n{target.monsterName}을(를) 공격합니다!");

                        target.TakeDamage(player.damage);

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

        public void TakeDamage(Player player, Monster monster, intmonsterIndex )//플레이어가 입힌 피해에 따라 몬스터의 체력이 감소하며 사망하는 메서드
        {

            monster -= player.damage;
            if (monster.monsterHp <= 0)
            {
                monster.monsterIsAlive = false;

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

        

    }
}
