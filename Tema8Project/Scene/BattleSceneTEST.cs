//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata.Ecma335;
//using System.Threading;
//using System.Xml.Linq;
//using Tema8Project.Data;
//using TxtRPG.Data;
//using TxtRPG.Game;
//using TxtRPG.UI;
//using static System.Runtime.InteropServices.JavaScript.JSType;



//namespace TxtRPG.Scene
//{


//    public class BattleStartScene : Iscene
//    {
//        public object Run(GameData data)
//        {
//            return ShowBattle(data);
//        }

//        int showMonstersCount;

//        bool cheakAllMonsterNoDead = true;

//        string monsterList;



//        private void printList(GameData data)
//        {
//            data.monsters.Clear();

//            for (int i = 0; i < showMonstersCount; i++)//몬스터 정보를 저장하기 위해서 몬스터 생성하는 반복문 분리 
//            {
//                Monster monster = new Monster(data);
//                monster.monsterIndex = i + 1;
//                data.monsters.Add(monster);


//                if (!data.monsters[i].monsterIsAlive)
//                {
//                    Console.ForegroundColor = ConsoleColor.DarkGray;
//                    monsterList = $"\n\nLV.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName} Dead";
//                }
//                else
//                {
//                    monsterList = $"\n\nLV.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName} HP {data.monsters[i].monsterHp}";
//                }

//                if (monster.monsterIsAlive)
//                {
//                    cheakAllMonsterNoDead = true;
//                }
//                else
//                {
//                    cheakAllMonsterNoDead = false;
//                    //결과화면 가기
//                }


//                Console.WriteLine(monsterList);
//            }
//        }


//        private void printList2(GameData data)
//        {
//            for (int i = 0; i < data.monsters.Count; i++)//몬스터 정보를 저장하기 위해서 몬스터 생성하는 반복문 분리 
//            {
//                Monster monster = data.monsters[i];

//                if (!monster.monsterIsAlive)
//                {
//                    monsterList = $"\n\n[{i + 1}] LV.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName} Dead";
//                }
//                else
//                {
//                    monsterList = $"\n\n[{i + 1}] LV.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName} HP {data.monsters[i].monsterHp}";
//                }

//                if (monster.monsterIsAlive)
//                {
//                    cheakAllMonsterNoDead = true;
//                }
//                else
//                {
//                    cheakAllMonsterNoDead = false;
//                    //결과화면 가기
//                }


//                Console.WriteLine(monsterList);
//            }
//        }





//        private object ShowBattle(GameData data)//매서드 사용해서 하나로 묶어서 AttackScene 없애기
//        {
//            Random randomMonsterChoice = new Random();
//            showMonstersCount = randomMonsterChoice.Next(1, 5);

//            Console.Clear();
//            Console.WriteLine("Battle!!");

//            printList(data);

//            while (true)
//            {
//                Console.WriteLine($"\n\n[내정보]\nLv.{data.Player.level}    {data.Player.name} ({data.Player.job})\nHP {data.Player.hp}/{data.Player.maxHp} ");
//                Console.Write("\n\n\n\n1.공격\n\n2.취소\n\n원하시는 행동을 입력해주세요.!\n>>");
//                int input = int.Parse(Console.ReadLine());

//                if (input == 1)
//                {
//                    object result = PlayerTurn(data);
//                    if (result is TitleScene) return result;
//                }

//                else if (input == 2)
//                {
//                    return new TitleScene();
//                }
//                else
//                {
//                    Console.WriteLine("잘못된 입력입니다.");
//                }
//            }
//        }


//        private object PlayerTurn(GameData data)
//        {
//            Console.Clear();
//            Console.WriteLine("공격할 몬스터를 선택하세요");
//            printList2(data);

//            Console.Write("\n>> ");
//            string inputStr = Console.ReadLine();//입력값 받아서
//            int inputInt = int.Parse(inputStr);
//            data.PlayerInput = inputInt - 1;

//            for (int i = 0; i < data.monsters.Count; i++)//리스트에 있는 몬스터를 싹 다 훑어서
//            {
//                if (inputInt == data.monsters[i].monsterIndex)//리스트에 있는걸 유저가 선택하면(Length 활용)
//                {
//                    if (data.monsters[i].monsterIsAlive)//일단 살아있는지 먼저 확인하고 살아있으면 TakeDamage를 실행시켜
//                    {
//                        Console.Clear();

//                        beforeMonsterHP = data.monsters[i].monsterHp;
//                        int finalDamage = playerFinalDamage(data);
//                        HitMonster(data);
//                        currentMonsterHP = data.monsters[i].monsterHp;

//                        string a = $"{data.Player.name} 의 공격!" +
//                    $"\nLv.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName} 을(를) 맞췄습니다. [데미지 : {finalDamage}]" +
//                    $"\n\nLv.{data.monsters[i].monsterLevel} {data.monsters[i].monsterName}" +
//                    $"\nHP {beforeMonsterHP} -> {(currentMonsterHP <= 0 ? "Dead" : currentMonsterHP.ToString())}" +
//                    $"\n\n0. 다음 (몬스터 턴으로 이동)\n\n>>";
//                        Console.WriteLine(a);

//                        if (data.monsters.All(m => !m.monsterIsAlive))
//                        {
//                            Console.WriteLine("\n모든 몬스터를 처치했습니다!");
//                            Console.ReadLine();
//                            new TitleScene().Run(data);
//                            return new TitleScene();
//                        }

//                        string next = Console.ReadLine();

//                        if (next == "0" && data.monsters.Any(m => m.monsterIsAlive))
//                        {
//                            Console.Clear();
//                            Console.WriteLine("몬스터의 턴으로 넘어갑니다...");
//                            Thread.Sleep(500);
//                            object result = EnemyTurn(data);
//                            if (result is TitleScene) return result;
//                        }
//                        else
//                        {
//                            Console.WriteLine("잘못된 입력입니다. 0을 입력하세요.");
//                            Console.ReadLine();
//                        }
//                    }
//                    else
//                    {
//                        Console.WriteLine($"이미 쓰러진 몬스터입니다.");
//                        Console.ReadLine();
//                    }
//                }


//                else if (!data.monsters[i].monsterIsAlive)
//                {

//                    Console.WriteLine($"잘못된 입력입니다.");
//                    Console.ReadLine();

//                }
//                if (data.monsters.All(m => !m.monsterIsAlive))
//                {
//                    Console.WriteLine("\n모든 몬스터를 처치했습니다!");
//                    Console.ReadLine();
//                    new TitleScene().Run(data);
//                    return;
//                }
//            }
//        }


//        int beforeMonsterHP;
//        int currentMonsterHP;
//        int beforePlayerHP;
//        int currentPlayerHP;
//        private void EnemyTurn(GameData data)
//        {
//            if (data.monsters.All(m => !m.monsterIsAlive))
//            {
//                Console.WriteLine("\n몬스터가 모두 쓰러졌습니다. 전투 종료!");
//                Console.ReadLine();
//                new TitleScene().Run(data);
//                return;
//            }

//            Console.Clear();
//            Console.WriteLine("몬스터의 턴!");

//            foreach (Monster monster in data.monsters)
//            {
//                if (monster.monsterIsAlive == false)
//                {
//                    continue;
//                }

//                beforePlayerHP = data.Player.hp;
//                HitPlayer(data);
//                currentPlayerHP = data.Player.hp;

//                Console.WriteLine($"\nLv.{monster.monsterLevel} {monster.monsterName} 의 공격!");
//                Console.WriteLine($"{data.Player.name}이(가) {monster.monsterAttackPower} 피해를 입었습니다!");
//                Console.WriteLine($"HP {beforePlayerHP} -> {currentPlayerHP}");
//                Thread.Sleep(500);

//            }
//            if (data.Player.hp <= 0)
//            {
//                Console.WriteLine("\n당신은 쓰러졌습니다...");
//                Console.ReadLine();
//                data.Player.hp = data.Player.maxHp; // 임시 회복
//                new TitleScene().Run(data);
//                return;
//            }

//            Console.WriteLine("\n0. 내 턴으로 돌아가기");
//            Console.Write(">> ");
//            string input = Console.ReadLine();

//            if (input == "0")
//            {
//                Console.Clear();
//                Console.WriteLine("플레이어의 턴입니다!");
//                Thread.Sleep(700);
//                PlayerTurn(data);
//            }
//            else
//            {
//                Console.WriteLine("잘못된 입력입니다. 0을 입력하세요.");
//                Console.ReadLine();
//            }
//            if (data.monsters.All(m => !m.monsterIsAlive))
//            {
//                Console.WriteLine("\n몬스터가 모두 쓰러졌습니다. 전투 종료!");
//                Console.ReadLine();
//                new TitleScene().Run(data);
//                return;
//            }

//        }

//        public void HitPlayer(GameData data)
//        {
//            Monster attacker = data.monsters.FirstOrDefault(mbox => mbox.monsterIsAlive);
//            if (attacker == null) return;
//            data.Player.hp -= attacker.monsterAttackPower;
//            if (data.Player.hp < 0) data.Player.hp = 0;

//        }

//        public void HitMonster(GameData data)//여기에 input값을 넣어서 쓰고 싶어서 playerInput을 만들어서 여기 리드라인 썼다가 빠꾸
//        {
//            data.monsters[data.PlayerInput].monsterHp -= data.Player.damage;
//            if (data.monsters[data.PlayerInput].monsterHp <= 0)
//            {
//                data.monsters[data.PlayerInput].monsterIsAlive = false;
//                data.monsters[data.PlayerInput].monsterHp = 0;
//            }
//        }


//        public int playerFinalDamage(GameData data)//좀... 너저분하게 만들어둠 수정 필요ㅠ 이거 매서드 밖으로 빼서 수정

//        {
//            double plusMinusDouble = data.Player.damage * 0.1f;
//            int playerDamage = (int)data.Player.damage;//Player 클래스 데미지 자체를 int로 수정하는게 더 낫지 않을까?.?
//            int plusMinusInt = (int)Math.Round(plusMinusDouble);


//            Random randomPlayerDamge = new Random();
//            int playerFinalDamage = randomPlayerDamge.Next(playerDamage - plusMinusInt, playerDamage + plusMinusInt);//Player가 가지는 계산식은 플레이어 클래스에 넣는게? 매서드 밖에 선언하고 클래스 받아서 가져오기

//            return playerFinalDamage;
//        }

//        public void AddItems(GameData data)//요런식으로 추가
//        {
//            if (data.monsters.Any(m => !m.monsterIsAlive))
//            {
//                data.Player.inventory.AddItem(new Item("낡은 마법서", ItemType.Weapon, 1, 5, 0, 0, 0, 20));
//            }
//        }

//        private void UsePotion(GameData data)
//        {
//            var potion = data.Player.inventory.items
//                .FirstOrDefault(item => item.name == "커피" && item.type == ItemType.Consumable && item.count > 0);

//            if (potion != null)
//            {
//                if (data.Player.hp == data.Player.maxHp && data.Player.mp == data.Player.maxMp)
//                {
//                    LogManager.Add("이미 카페인 한도초과다!");
//                    return;
//                }
//                int healHp = data.Player.maxHp / potion.healHp;
//                int healMp = data.Player.maxMp / potion.healMp;
//                data.Player.hp += healHp;
//                data.Player.mp += healMp;

//                if (data.Player.hp > data.Player.maxHp)
//                    data.Player.hp = data.Player.maxHp;

//                if (data.Player.mp > data.Player.maxMp)
//                    data.Player.mp = data.Player.maxMp;
//                potion.count--;
//                LogManager.Add($"커피를 마셔 +{healHp}HP +{healMp}MP 회복했습니다!");

//                if (potion.count == 0)
//                    data.Player.inventory.items.Remove(potion);
//            }
//            else
//            {
//                LogManager.Add("커피가 없습니다!");
//            }
//        }
//    }
//}
