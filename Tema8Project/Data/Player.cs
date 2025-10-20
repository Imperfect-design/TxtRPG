using System;
using System.Net.Security;
using TxtRPG.Scene;

namespace TxtRPG.Data
{
    public class Player
    {
        public Player() { }

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

        //플레이어의 초기 스탯
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
            damage = 70;
            gold = 1000;
            doge = 30;
            critical = 50;
        }
        //플레이어의 경험치 로직
        public void ExpUp(int Exp)
        {
            exp += Exp * 30;//밸런스 조정 필요
            LogManager.Add($"{Exp}의 경험치를 얻었다!");
            while (exp >= maxExp)
            {
                exp -= maxExp;
                level++;
                playerLevelStat();
                hp = maxHp;
                mp = maxMp;
                LogManager.Add($"레벨업! +1! {level}.lv");
            }
        }
        //플레이어 레벨업 시 로직
        public void playerLevelStat()
        {
            maxHp = 150 + ((level - 1) * 25);
            maxMp = 15 + ((level - 1) * 3);
            damage = 25 + ((level - 1) * 8);
        }
        //플레이어의 피격 로직
        //Monster의 로직과 비슷하기 때문에, Monster의 로직을 간소화 시킨 후 루트 로직을 따로 추가하는 것이 좋다.
        public void TakeDamage(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                hp = 0;
            }
        }
    }
}