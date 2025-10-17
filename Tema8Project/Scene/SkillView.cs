using System.Threading;
using Tema8Project.Data;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.Scene;

class SkillView : Iscene
{
    public object Run(GameData data)
    {

        Skill skill = new Skill();
        Console.Clear();


        if (data.Player.job == "전사")
        {
            List<Skill> warrior = skill.WarriorSkillList(data.Player);
            Skill firstSkill = warrior[1];
            Skill secondSkill = warrior[2];
            Skill thirdSkill = warrior[3];
            Skill fourthSkill = warrior[4];
            Console.WriteLine($"{firstSkill.SkillNumber} {firstSkill.SkillName} 데미지:  {firstSkill.SkillDamage}  체력소모: {firstSkill.SkillHp}   마나소모:  {firstSkill.SkillMp}  해금레벨:  {firstSkill.UnlockLevel}");
            Console.WriteLine($"{secondSkill.SkillNumber} {secondSkill.SkillName} 데미지:  {secondSkill.SkillDamage}  체력소모: {secondSkill.SkillHp}  마나소모:   {secondSkill.SkillMp}  해금레벨:  {secondSkill.UnlockLevel}");
            Console.WriteLine($"{thirdSkill.SkillNumber}   {thirdSkill.SkillName} 데미지:  {thirdSkill.SkillDamage}  체력회복: {thirdSkill.SkillHp}   마나소모: {thirdSkill.SkillMp}  해금레벨:  {thirdSkill.UnlockLevel}");
            Console.WriteLine($"{fourthSkill.SkillNumber}   {fourthSkill.SkillName} 데미지:  {fourthSkill.SkillDamage}  체력소모: {fourthSkill.SkillHp} 마나소모:  {fourthSkill.SkillMp}  해금레벨:  {fourthSkill.UnlockLevel}");
            Console.WriteLine("0. 나가기");
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                return new StatusScene();
            }
        }
        else if (data.Player.job == "마법사")
        {
            List<Skill> mage = skill.MageSkillList(data.Player);
            Skill firstSkill = mage[1];
            Skill secondSkill = mage[2];
            Skill thirdSkill = mage[3];
            Skill fourthSkill = mage[4];
            Console.WriteLine($"{firstSkill.SkillNumber}   {firstSkill.SkillName}  데미지:  {firstSkill.SkillDamage} 체력소모:   {firstSkill.SkillHp}    마나소모: {firstSkill.SkillMp}  해금레벨:  {firstSkill.UnlockLevel}");
            Console.WriteLine($"{secondSkill.SkillNumber}   {secondSkill.SkillName} 데미지:  {secondSkill.SkillDamage}  체력소모:   {secondSkill.SkillHp}    마나소모:   {secondSkill.SkillMp} 해금레벨:  {secondSkill.UnlockLevel}");
            Console.WriteLine($"{thirdSkill.SkillNumber}   {thirdSkill.SkillName} 데미지:  {thirdSkill.SkillDamage}  체력소모:   {thirdSkill.SkillHp}    마나회복:  {thirdSkill.SkillMp}  해금레벨:  {thirdSkill.UnlockLevel}");
            Console.WriteLine($"{fourthSkill.SkillNumber}   {fourthSkill.SkillName} 데미지:  {fourthSkill.SkillDamage}  체력소모:   {fourthSkill.SkillHp}    마나소모:  {fourthSkill.SkillMp}   해금레벨:  {fourthSkill.UnlockLevel}");
            Console.WriteLine("0. 나가기");
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                return new StatusScene();
            }
        }
        else if (data.Player.job == "궁수")
        {
            List<Skill> archer = skill.ArcherSkillList(data.Player);
            Skill firstSkill = archer[1];
            Skill secondSkill = archer[2];
            Skill thirdSkill = archer[3];

            Console.WriteLine($"{firstSkill.SkillNumber}     {firstSkill.SkillName} 데미지:  {firstSkill.SkillDamage}   체력소모:   {firstSkill.SkillHp}      마나소모:  {firstSkill.SkillMp}  해금레벨:  {firstSkill.UnlockLevel}");
            Console.WriteLine($"{secondSkill.SkillNumber}     {secondSkill.SkillName} 데미지:  {secondSkill.SkillDamage}  체력소모:  {secondSkill.SkillHp}     마나소모: {secondSkill.SkillMp}  해금레벨:  {secondSkill.UnlockLevel}");
            Console.WriteLine($"{thirdSkill.SkillNumber}     {thirdSkill.SkillName} 데미지:  {thirdSkill.SkillDamage}   체력소모:  {thirdSkill.SkillHp}   마나소모:   {thirdSkill.SkillMp}  해금레벨:  {thirdSkill.UnlockLevel}");
            Console.WriteLine("0. 나가기");
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                return new StatusScene();
            }
        }
        return this;

    }


}
