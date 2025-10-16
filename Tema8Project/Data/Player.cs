using System;
using System.Net.Security;
using Tema8Project.Data;

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
            damage = 10;
            gold = 1000;
            doge = 30;
            critical = 50;
        }
        public void ExpUp(GameData data)
        {
            exp += data.monster.monsterLevel*10;//밸런스 조정 필요
            if(exp >= maxExp)
            {
                exp -= maxExp;
                level++;
                playerLevelStat();
                hp = maxHp;
                mp = maxMp;
            }
        }
        public void playerLevelStat()
        {
            maxHp = 100 + ((level-1) * 20);
            maxMp = 10 + ((level - 1) * 2);
            damage = 10 + ((level - 1) * 5);
        }
        public void TakeDamage(GameData data, int num)
        {
            hp -= data.monster.monsters[num].monsterAttackPower;
        }
    }
}