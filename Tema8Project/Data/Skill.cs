using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.Scene;
using static System.Net.Mime.MediaTypeNames;

namespace TxtRPG.Data
{

    class Skill
    {
        public string SkillName { get; set; }
        public int SkillDamage { get; set; }
        public int SkillHp { get; set; }
        public int SkillMp { get; set; }
        public int SkillLevel { get; set; }
        public int SkillNumber { get; set; }
        public int UnlockLevel { get; set; }

        public Skill()
        {

        }

        public Skill(string name, int damage, int hp, int mp, int number, int unlockLevel) //생성자 매개변수 추가 추가한 매개변수를 리스트 값에 적용
        {
            SkillName = name;
            SkillDamage = damage;
            SkillHp = hp;
            SkillMp = mp;
            SkillNumber = number;
            UnlockLevel = unlockLevel;
        }


        public List<Skill> WarriorSkillList(Player player)
        {
            List<Skill> warrior = new List<Skill>(); //스킬이름, 스킬데미지, 체력소모, MP소모, 사용할 때 스킬숫자
            warrior.Add(new Skill("", 0, 0, 0, 0, 0));
            warrior.Add(new Skill("두번베기", player.damage * 2, 0, 1, 1, 1));
            warrior.Add(new Skill("달려들기", player.damage + 30, 8, 1, 2, 2));
            warrior.Add(new Skill("회복", 0, 30, 0, 3, 2));
            warrior.Add(new Skill("필살검", player.damage * 3 + 50, 30, 10, 4, 3));

            return warrior;

        }


        public List<Skill> MageSkillList(Player player)
        {
            List<Skill> mage = new List<Skill>();
            mage.Add(new Skill("", 0, 0, 0, 0, 0));
            mage.Add(new Skill("파이어", player.damage + 30, 0, 8, 1, 1));
            mage.Add(new Skill("불기둥", player.damage + 40, 0, 30, 2, 2));
            mage.Add(new Skill("마나회복", 0, 0, player.mp + 30, 3, 3));
            mage.Add(new Skill("필살불", player.damage + 80, 0, 50, 4, 3));


            return mage;
        }

        public List<Skill> ArcherSkillList(Player player)
        {
            List<Skill> archer = new List<Skill>();
            archer.Add(new Skill("", 0, 0, 0, 0, 0));
            archer.Add(new Skill("세번쏘기", player.damage * 3, 0, 4, 1, 1));
            archer.Add(new Skill("네번쏘기", player.damage * 4, 0, 8, 2, 2));
            archer.Add(new Skill("다섯번쏘기", player.damage * 5, 0, 12, 3, 3));

            return archer;
        }

    }
}