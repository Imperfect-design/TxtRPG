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

    public class Skill
    {
        public string SkillName { get; set; }
        public int SkillDamage { get; set; }
        public int SkillHp { get; set; }
        public int SkillMp { get; set; }
        public int SkillLevel { get; set; }
        public int SkillNumber { get; set; }
        public int UnlockLevel { get; set; }


        public Dictionary<string, Skill> WarriorSkillList(GameData data)
        {
            Dictionary<string, Skill> warrior = new Dictionary<string, Skill>(); //스킬이름, 스킬데미지, 체력소모, MP소모, 사용할 때 스킬숫자
            warrior.Add("두번베기", new Skill
            {
                SkillNumber = 1,
                SkillName = "두번베기",
                SkillDamage = data.Player.damage * 2,
                SkillHp = 0,
                SkillMp = 15,
                UnlockLevel = 1
            });
            warrior.Add("달려들기", new Skill
            {
                SkillNumber = 2,
                SkillName = "달려들기",
                SkillDamage = data.Player.damage + 30 * 2,
                SkillHp = 8,
                SkillMp = 1,
                UnlockLevel = 2
            });
            warrior.Add("회복", new Skill
            {
                SkillNumber = 3,
                SkillName = "회복",
                SkillDamage = 0,
                SkillHp = (data.Player.damage / 2) + 30,
                SkillMp = 3,
                UnlockLevel = 2
            });
            warrior.Add("필살검", new Skill
            {
                SkillNumber = 4,
                SkillName = "필살검",
                SkillDamage = data.Player.damage * 3 + 50,
                SkillHp = 30,
                SkillMp = 10,
                UnlockLevel = 3
            });
            return warrior;

        }
    
        public Dictionary<string, Skill> MageSkillList(GameData data)
        {
            Dictionary<string, Skill> mage = new Dictionary<string, Skill>();
            mage.Add("파이어", new Skill
            {
                SkillNumber = 1,
                SkillName = "파이어",
                SkillDamage = data.Player.damage,
                SkillHp = 0,
                SkillMp = 8,
                UnlockLevel = 1
            });
            mage.Add("불기둥", new Skill
            {
                SkillNumber = 2,
                SkillName = "불기둥",
                SkillDamage = data.Player.damage + 40,
                SkillHp = 0,
                SkillMp = 30,
                UnlockLevel = 2
            });
            mage.Add("마나회복", new Skill
            {
                SkillNumber = 3,
                SkillName = "마나회복",
                SkillDamage = 0,
                SkillHp = 0,
                SkillMp = 30,
                UnlockLevel = 2
            });
            mage.Add("필살불", new Skill
            {
                SkillNumber = 4,
                SkillName = "필살불",
                SkillDamage = data.Player.damage + 80,
                SkillHp = 0,
                SkillMp = 50,
                UnlockLevel = 3
            });
            return mage;
        }

        public Dictionary<string, Skill> ArcherSkillList(GameData data)
        {
            Dictionary<string, Skill> archer = new Dictionary<string, Skill>();
            archer.Add("세번쏘기", new Skill
            {
                SkillNumber = 1,
                SkillName = "세번쏘기",
                SkillDamage = data.Player.damage * 3,
                SkillHp = 0,
                SkillMp = 4,
                UnlockLevel = 1
            });
            archer.Add("네번쏘기", new Skill
            {
                SkillNumber = 2,
                SkillName = "네번쏘기",
                SkillDamage = data.Player.damage * 4,
                SkillHp = 0,
                SkillMp = 8,
                UnlockLevel = 2
            });
            archer.Add("다섯번쏘기", new Skill
            {
                SkillNumber = 3,
                SkillName = "다섯번쏘기",
                SkillDamage = data.Player.damage * 5,
                SkillHp = 0,
                SkillMp = 12,
                UnlockLevel = 3
            });

            return archer;
        }

    }
}
