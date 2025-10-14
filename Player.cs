using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtRPG
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
            gold = 1000;
        }
        public void Run()
        {
            Console.WriteLine(@$"
{name} {level}.Lv
HP {hp}/{maxHp}   MP {mp}/{maxMp}
DMG {damage}      {gold}G
EXP  {exp} / {maxExp}");
            Console.WriteLine("\n\n\n1.인벤토리 2.스킬보기 3.나가기");
            Console.Write(">>>");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    //인벤토리
                    break;
                case 2:
                    //스킬보기
                    break;
                case 3:
                    //나가기
                    break;
                default:
                    Console.WriteLine("잘못된 입력값입니다. 다시 입력해주세요");
            }
        }
    }
}
