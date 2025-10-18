using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using Tema8Project.Data;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.UI;
using TxtRPG.Scene;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace TxtRPG.Scene
{


    public class BattleStartScene : Iscene
    {
        public List<Monster> monsters = new List<Monster>();


        public object Run(GameData data)
        {
            return ShowBattle(data);
        }




        Random rand = new Random();


        private object ShowBattle(GameData data)
        {
            for (int i = 0; i < rand.Next(1, 5); i++)
                monsters.Add(new Monster(data));
            LogManager.Add("전투시작!");
            while (true)
            {
                if (data.Player.hp <= 0)
                {
                    LogManager.Add("플레이어가 사망하여 마을에서 다시 태어납니다.");
                    return new TitleScene();
                }
                    
                if (monsters.Count == 0)
                {
                    LogManager.Add("모든 몬스터를 처치하여 마을로 돌아왔다!");
                    return new TitleScene();
                }
                int potionCount = data.Player.inventory.items.Where(item => item.name == "커피" && item.type == ItemType.Consumable).Sum(item => item.count);
                Console.Clear();
                for (int i = 0; i < monsters.Count; i++)
                    UIManager.PrintCenter($"{monsters[i].monsterName} {monsters[i].monsterLevel}.LV HP : {monsters[i].monsterHp}/{monsters[i].monsterMaxhp} DMG : {monsters[i].monsterAttackPower}");
                Console.WriteLine("\n\n\n\n");
                UIManager.PrintCenter($"[{data.Player.name} {data.Player.level}.Lv  HP : {data.Player.hp}/{data.Player.maxHp} MP : {data.Player.mp}/{data.Player.maxMp} DMG : {data.Player.damage}  EXP : {data.Player.exp}/{data.Player.maxExp}]");
                LogManager.Show();
                Console.WriteLine($"\n\n\n\n\n1.공격하기 2.커피사용하기[{potionCount}]개 3.도망가기");
                int input = int.Parse(Console.ReadLine());
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
        public void ShowAtack(GameData data)
        {
            while (true)
            {
                int monsterCount = rand.Next(monsters.Count);
                Console.Clear();
                for (int i = 0; i < monsters.Count; i++)
                    UIManager.PrintCenter($"[{i + 1}]{monsters[i].monsterName} {monsters[i].monsterLevel}.LV HP : {monsters[i].monsterHp}/{monsters[i].monsterMaxhp} DMG : {monsters[i].monsterAttackPower}");
                Console.WriteLine("\n\n\n\n");
                UIManager.PrintCenter($"[{data.Player.name} {data.Player.level}.Lv  HP : {data.Player.hp}/{data.Player.maxHp} MP : {data.Player.mp}/{data.Player.maxMp} DMG : {data.Player.damage}  EXP : {data.Player.exp}/{data.Player.maxExp}]");
                LogManager.Show();
                Console.Write($"\n\n\n\n\n공격대상의 번호를 입력하세요 0.뒤로가기 : ");
                int input = int.Parse(Console.ReadLine()) - 1;
                if (input == -1)
                    break;
                else if (input >= 0 && input < monsters.Count)
                {
                    var target = monsters[input];
                    LogManager.Add($"{monsters[input].monsterName}을(를) 공격하여 {data.Player.damage}만큼 피해를 입혔다!{monsters[input].monsterHp}->{monsters[input].monsterHp - data.Player.damage}");
                    target.TakeDamage(data);

                    if (target.monsterHp <= 0)
                    {
                        LogManager.Add($"{target.monsterName} 처치 완료!");
                        QuestScene.CheckQuest(target.monsterName,data);
                        monsters.RemoveAt(input);
                    }
                    else
                    {
                        data.Player.TakeDamage(monsters[monsterCount].monsterAttackPower);
                        LogManager.Add($"{monsters[monsterCount].monsterName}한테 공격당하여 {monsters[monsterCount].monsterAttackPower}의 데미지를 받았다!");
                    }
                    break;
                }
                else
                    LogManager.Add("다시입력해주세요");
                continue;
            }
        }
        private void UsePotion(GameData data)
        {
            var potion = data.Player.inventory.items
                .FirstOrDefault(item => item.name == "커피" && item.type == ItemType.Consumable && item.count > 0);

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
                    data.Player.hp = data.Player.maxHp;

                if (data.Player.mp > data.Player.maxMp)
                    data.Player.mp = data.Player.maxMp;
                potion.count--;
                LogManager.Add($"커피를 마셔 +{healHp}HP +{healMp}MP 회복했습니다!");

                if (potion.count == 0)
                    data.Player.inventory.items.Remove(potion);
            }
            else
            {
                LogManager.Add("커피가 없습니다!");
            }
        }

    }
}
