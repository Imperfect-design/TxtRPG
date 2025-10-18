using System;
using System.Net.Security;
using Tema8Project.Data;
using TxtRPG.Scene;

namespace TxtRPG.Data
{




    public class Player
    {
        public string name;
        public int level;
        public int exp;
        public int maxExp;
        public int hp;
        public int maxHp;
        public int mp;
        public int maxMp;
        public int damage;
        public int gold;
        public string job;
        public int doge;
        public int critical;
        public Inven inventory = new Inven();
        public Item equipWeapon;
        public Item equipArmor;

        public Player(string Name)
        {
            name = Name;
            level = 1;
            exp = 0;
            maxExp = 100;
            maxHp = 100;
            maxMp = 10;
            hp = maxHp;
            mp = maxMp;
            damage = 25;
            gold = 1000;
            doge = 30;
            critical = 50;
        }
        public void ExpUp(int Exp)
        {
            exp += Exp * 30;//밸런스 조정 필요
            LogManager.Add($"{Exp}의 경험치를 얻었다!");
            while(exp >= maxExp)
            {
                exp -= maxExp;
                level++;
                playerLevelStat();
                hp = maxHp;
                mp = maxMp;
                LogManager.Add($"레벨업! +1! {level}.lv");
            }
        }
        public void playerLevelStat()
        {
            maxHp = 150 + ((level-1) * 25);
            maxMp = 15 + ((level - 1) * 3);
            damage = 25 + ((level - 1) * 8);
        }
        public void TakeDamage(int damage)
        {
            hp -= damage;
            if(hp <= 0)
            {
                hp = 0;
            }
        }
    }
}