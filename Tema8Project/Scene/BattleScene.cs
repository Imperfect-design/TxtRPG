using System;
using System.Collections.Generic;
using TxtRPG.Data;
using TxtRPG.Game;

namespace TxtRPG.Scene
{
    public class BattleStartScene : Iscene
    {
        public object Run(Player player)
        {
            ShowBattle(player);
            return new TitleScene();
        }

        private void ShowBattle(Player player)
        {
            Console.Clear();

            Random randomMonsterChoice = new Random();


            List<Monster> monsters = new List<Monster>()
    {
            new Monster("마왕", 99, 99, 99),//몬스터의 이름. 레벨, 체력, 공격력
            new Monster("사천왕", 4, 25, 40),
            new Monster("쫄따구", 1, 10, 10)
    };

            int monsterCount = randomMonsterChoice.Next(1, 5);

            Console.WriteLine("Battle!!");
            for (int i = 0; i < monsterCount; i++)
            {
                Monster enemy = monsters[randomMonsterChoice.Next(monsters.Count)];
                Console.WriteLine($"\n\nLV.{enemy.monsterLevel} {enemy.monsterName} HP {enemy.monsterHp}");
            }
            Console.WriteLine("\r\n1. 공격\r\n\r\n원하시는 행동을 입력해주세요.!");

            //player Class에 접근해서 플레이어 정보 출력

            string input = Console.ReadLine();

            if (input == "1")
            {
                Attack();//디버그용 메서드
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
                        Attack();//디버그용 메서드
                    }

                }
            }
        }

        private void Attack()//디버그용 메서드
        {
            Console.WriteLine("공격화면 창");
        }
    }


    public class Monster
    {
        public string monsterName { get; private set; }
        public int monsterLevel { get; private set; }
        public int monsterHp { get; private set; }
        public int monsterAttackPower { get; private set; }
        public bool monsterIsAlive { get; private set; }

        public Monster(string name, int level, int hp, int attackPower)
        {
            monsterName = name;
            monsterLevel = level;
            monsterHp = hp;
            monsterAttackPower = attackPower;
            monsterIsAlive = true;
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
}