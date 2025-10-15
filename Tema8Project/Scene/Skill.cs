using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtRPG.Data;
using TxtRPG.Scene;

class Skill 
{
    public string SkillName {  get; set; }
    public int SkillDamage { get; set; }
    public int SkillHp {  get; set; }
    public int SkillMp { get; set; }
    public int SkillLevel {  get; set; }
    public int SkillNumber { get; set; }

    public Skill(string name, int damage, int hp, int mp ,int Level,int number)
    {
        SkillName = name;
        SkillDamage = damage;
        SkillHp = hp;
        SkillMp = mp;
        SkillLevel = Level;
        SkillNumber = number;
    }
    public void warriorSkill(Player player)
    {
        NewCharacterScene status = new NewCharacterScene();
        List<Skill> warrior = new List<Skill>(); //스킬이름, 스킬데미지, 체력소모, MP소모, 스킬해금레벨, 사용할 때 스킬숫자
        warrior.Add(new Skill("두번베기", player.damage * 2, 0,player.hp - 1 ,player.mp - 1, 1));
        warrior.Add(new Skill("달려들기", player.damage + 20, 8,player.hp - 1 ,player.mp - 2 ,2));
        warrior.Add(new Skill("회복", 0, player.hp + 30, 0, 2, 3));
        warrior.Add(new Skill("필살검", player.damage * 3 + 50,player.hp + 30,player.mp - 10, 3, 4));
    }
    public void mageSkill(Player player)
    {
        List<Skill> mage = new List<Skill>();
        mage.Add(new Skill("파이어", player.damage+ 30, 0,player.mp - 8, 1, 1));
        mage.Add(new Skill("불기둥", player.damage + 30, 0,player.mp - 30, 2, 2));
        mage.Add(new Skill("마나회복", 0, 0, player.mp + 30, 2, 3));
        mage.Add(new Skill("필살불", player.damage + 80, 0, player.mp - 50, 3, 4));
    }
    public void archerSkill(Player player)
    {
        List<Skill> archer = new List<Skill>();
        archer.Add(new Skill("세번쏘기", player.damage * 3, 0,player.mp - 4, 1, 1));
        archer.Add(new Skill("네번쏘기", player.damage * 4, 0,player.mp - 8, 2, 2));
        archer.Add(new Skill("다섯번쏘기", player.damage * 5, 0, player.mp - 12, 3, 3));
    }
}