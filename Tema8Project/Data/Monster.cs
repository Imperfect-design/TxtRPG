using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TxtRPG;
using TxtRPG.Data;


namespace TxtRPG.Data
{
    public class Monster
    {

        public string monsterName { get; set; }
        public int monsterLevel { get; set; }
        public int monsterHp { get; set; }
        public int monsterMaxhp { get; set; }
        public int monsterAttackPower { get; set; }
        public int monsterIndex { get; set; }
        public bool monsterIsAlive { get; set; }

        public string[] names = new string[] { "임프", "헬하운드", "마그마슬라임", "블레이즈", "헬 나이트", "플레임 위치", "마왕" };
        private static Random random = new Random();
        public Monster(GameData data)
        {
            Random random = new Random();
            monsterName = names[random.Next(names.Length)];
            if (monsterName == "마왕")//이름이 마왕이면 밸런스 조정
            {
                monsterLevel = random.Next(Math.Max(1, data.Player.level - 5), data.Player.level + 6);
                monsterMaxhp = monsterLevel * 40;
                monsterHp = monsterMaxhp;
                monsterAttackPower = monsterLevel * 5;
                monsterIsAlive = true;
                monsterIndex = 0;
            }
            else
            {
                monsterLevel = random.Next(Math.Max(1, data.Player.level - 5), data.Player.level + 6);
                monsterMaxhp = monsterLevel * 40;
                monsterHp = monsterMaxhp;
                monsterAttackPower = monsterLevel * 5;
                monsterIsAlive = true;
                monsterIndex = 0;
            }

        }



        public void TakeDamage(GameData data)
        {
            int itemReward = random.Next(1, 101);
            int critical = random.Next(1, 101);
            int criticalDamage= data.Player.damage * 2;
            if (!monsterIsAlive) return;
            if(data.Player.critical >= critical)
            {
                monsterHp -= criticalDamage;
                LogManager.Add($"{monsterName}을(를) 공격! 크리티컬!! {criticalDamage}만큼 피해를 입혔다!{monsterHp}->{monsterHp - criticalDamage}");
            }
            else
            {
                monsterHp -= data.Player.damage;
                LogManager.Add($"{monsterName}을(를) 공격하여 {data.Player.damage}만큼 피해를 입혔다!{monsterHp}->{monsterHp - data.Player.damage}");
            }
                
            if (monsterHp <= 0)
            {
                monsterIsAlive = false;
                data.Player.ExpUp(monsterLevel);
                LogManager.Add($"{monsterName}이(가) 사망하였다!");
                if (itemReward >= 50)
                {
                    data.Player.inventory.AddItem(new Item("커피", ItemType.Consumable, 1, 0, 0, 2, 2, 10));
                    LogManager.Add($"{monsterName}이(가) 커피를 가지고있었다!!");
                }
                else
                {
                    int rewardGold = 100 + data.Player.level * random.Next(1, 3);
                    data.Player.gold += rewardGold;
                    LogManager.Add($"{monsterName}이(가) {rewardGold}G를 가지고있었다!!");
                }

            }
        }
    }
}
