using System;

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
        //public Inven inventory = new Inven();
        //public Item equipWeapon;
        //public Item equipArmor;

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
    }
}