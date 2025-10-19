using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtRPG
{
    //열거형으로 아이템 타입 정의
    public enum ItemType
    {
        Weapon,
        Armor,
        Consumable,
        Loot
    }
    public class Item
    {
        public string name;
        public int healHp, healMp, dmg, hp, count, buy, sell; // 아이템 정보를 담는 변수선언
        public ItemType type;

        public Item(string name, ItemType type, int count = 1, int Damage = 0, int Hp = 0, int healHp = 0, int healMp = 0, int buy = 0)//매개변수 방식
        {
            this.name = name;
            this.type = type;
            this.count = count;
            this.dmg = Damage;
            this.hp = Hp;
            this.healHp = healHp;
            this.healMp = healMp;
            this.buy = buy;
            this.sell = buy / 2;
        }
    }
}
