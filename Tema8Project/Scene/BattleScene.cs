using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.UI;
using TxtRPG.Scene;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TxtRPG.Scene
{
    //Iscene의 규칙에 상속
    public class BattleStartScene : Iscene
    {
        //외부에서 수정 가능한 몬스터의 초기 리스트 및 난수.
        public List<Monster> monsters = new List<Monster>();
        Random rand = new Random();

        public object Run(GameData data)
        {
            return ShowBattle(data);
        }
        //배틀 보여주기 함수
        private object ShowBattle(GameData data)
        {
            //랜덤 몬스터 생성 및 전투 루프
            for (int i = 0; i < rand.Next(1, 5); i++)            {
                monsters.Add(new Monster(data));
            }
            LogManager.Add("전투시작!");

            while (true)
            {
                bool isAlive = true;
                if (data.Player.hp <= 0)
                {
                    LogManager.Add("플레이어가 사망하여 마을에서 다시 태어납니다.");
                    BattleResultLose(data);
                    Console.WriteLine("아무 키나 입력해주세요.");
                    Console.ReadKey();
                    return new TitleScene();
                    
                }
                for (int i = 0; i < monsters.Count; i++)
                {
                    if (monsters[i].monsterIsAlive == true)
                    {
                        isAlive = false;
                        break;
                    }
                }
                if (isAlive)
                {
                    LogManager.Add("모든 몬스터가 쓰러졌습니다! 마을로 돌아갑니다!");
                    Thread.Sleep(1000);
                    BattleResultVictory(data);
                    Console.WriteLine("아무 키나 입력해주세요.");
                    Console.ReadKey();
                    return new TitleScene();
                }
                //인벤토리에서 포션 가져오기
                int potionCount = 0;
                for (int i = 0; i < data.Player.inventory.items.Count; i++)
                {
                    if (data.Player.inventory.items[i].name == "커피"&& data.Player.inventory.items[i].type == ItemType.Consumable)
                    {
                        potionCount += data.Player.inventory.items[i].count;
                    }
                }

                Console.Clear();

                //몬스터, 플레이어, 선택지 출력
                for (int i = 0; i < monsters.Count; i++)
                {
                    UIManager.PrintCenter($"{monsters[i].monsterName} {monsters[i].monsterLevel}.LV HP : {monsters[i].monsterHp}/{monsters[i].monsterMaxhp} DMG : {monsters[i].monsterAttackPower}");
                }
                Console.WriteLine("\n\n\n\n");
                UIManager.PrintCenter($"[{data.Player.name} {data.Player.level}.Lv  HP : {data.Player.hp}/{data.Player.maxHp} MP : {data.Player.mp}/{data.Player.maxMp} DMG : {data.Player.damage}  EXP : {data.Player.exp}/{data.Player.maxExp}]");
                
                LogManager.Show();

                Console.WriteLine($"\n\n\n\n\n1.공격하기 2.커피사용하기[{potionCount}]개 3.도망가기");

                //int input = int.Parse(Console.ReadLine());
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    LogManager.Add("잘못된 입력입니다. 다시 입력해주세요");
                    continue;
                }

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        ShowAtack(data);
                        break;
                    case 2:
                        UsePotion(data);
                        continue;
                    case 3:
                        LogManager.Add("도망쳤습니다.");
                        return new TitleScene();
                    default:
                        LogManager.Add("다시입력해주세요");
                        break;
                }
            }
        }

        

        //공격하기 선택시 로직
        public void ShowAtack(GameData data)
        {
            while (true)
            {
                //반격할 몬스터 랜덤(난수) 선택
                int monsterCount = rand.Next(monsters.Count);

                Console.Clear();
                //인덱스 표시 -> 공격 대상 선택 가능
                for (int i = 0; i < monsters.Count; i++)
                {
                    UIManager.PrintCenter($"[{i + 1}]{monsters[i].monsterName} {monsters[i].monsterLevel}.LV HP : {monsters[i].monsterHp}/{monsters[i].monsterMaxhp} DMG : {monsters[i].monsterAttackPower}");
                }
                Console.WriteLine("\n\n\n\n");

                UIManager.PrintCenter($"[{data.Player.name} {data.Player.level}.Lv  HP : {data.Player.hp}/{data.Player.maxHp} MP : {data.Player.mp}/{data.Player.maxMp} DMG : {data.Player.damage}  EXP : {data.Player.exp}/{data.Player.maxExp}]");
                LogManager.Show();

                Console.Write($"\n\n\n\n\n공격대상의 번호를 입력하세요 0.뒤로가기 : ");

                //int input = int.Parse(Console.ReadLine()) - 1;

                if (!int.TryParse(Console.ReadLine(), out int inputRaw))
                {
                    LogManager.Add("숫자를 입력해주세요.");
                    continue;
                }

                int input = inputRaw - 1;

                if (input == -1)
                {
                    break;
                }
                //퀘스트 체크 및 회피, 몬스터 반격
                else if (input >= 0 && input < monsters.Count)
                {
                    if (monsters[input].monsterHp <= 0)
                    {
                        LogManager.Add($"{monsters[input].monsterName}은(는) 이미 쓰러져 있습니다!");
                        continue;
                    }
                    monsters[input].TakeDamage(data);
                    if (monsters[input].monsterHp <= 0)
                    {
                        monsters[input].monsterHp = 0;
                        monsters[input].monsterName = $"{monsters[input].monsterName} 사망";
                    }
                    else if (monsters.Count != 0)
                    {
                        int dogeRand = rand.Next(1, 101);
                        if (data.Player.doge >= dogeRand)
                        {
                            LogManager.Add($"{monsters[monsterCount].monsterName}이(가) 공격하였지만 회피하였다!");
                        }
                        else
                        {
                            data.Player.TakeDamage(monsters[monsterCount].monsterAttackPower);
                            LogManager.Add($"{monsters[monsterCount].monsterName}한테 공격당하여 {monsters[monsterCount].monsterAttackPower}의 데미지를 받았다!");
                        }
                    }
                    break;
                }
                else
                {
                    LogManager.Add("다시입력해주세요");
                }
                continue;
            }
        }
        //포션 선택시 로직
        private void UsePotion(GameData data)
        {
            var potion = data.Player.inventory.items.FirstOrDefault(item => item.name == "커피" && item.type == ItemType.Consumable && item.count > 0);

            if (potion != null)
            {
                if (data.Player.hp == data.Player.maxHp && data.Player.mp == data.Player.maxMp)
                {
                    LogManager.Add("이미 카페인 한도초과다!");
                    return;
                }

                int healHp = data.Player.maxHp / potion.healHp;
                int healMp = data.Player.maxMp / potion.healMp;
                data.Player.hp += healHp;
                data.Player.mp += healMp;

                if (data.Player.hp > data.Player.maxHp)
                {
                    data.Player.hp = data.Player.maxHp;
                }

                if (data.Player.mp > data.Player.maxMp)
                {
                    data.Player.mp = data.Player.maxMp;
                }
                potion.count--;

                LogManager.Add($"커피를 마셔 +{healHp}HP +{healMp}MP 회복했습니다!");

                if (potion.count == 0)
                {
                    data.Player.inventory.items.Remove(potion);
                }
            }
            else
            {
                LogManager.Add("커피가 없습니다!");
            }
        }


        public void BattleResultVictory(GameData data)
        {
            Console.Clear();
            string a = $"Battle!! - Result" +
                $"\n" +
                $"Victory" +
                $"\n" +
                $"던전에서 몬스터 {monsters.Count}를 잡았습니다." +
                $"\n" +
                $"Lv.{data.Player.level} {data.Player.name}" +
                $"HP {data.Player.maxHp} -> {data.Player.hp}" +
                $"\n";

            Console.WriteLine(a);
        }

        public void BattleResultLose(GameData data)
        {
            Console.Clear();
            string a = $"Battle!! - Result" +
                $"\n" +
                $"You Lose" +
                $"\n" +
                $"Lv.{data.Player.level} {data.Player.name}" +
                $"HP {data.Player.maxHp} -> {data.Player.hp}" +
                $"\n";

            Console.WriteLine(a);
        }
    }
}

    
    
    
    
    
    
    
    

