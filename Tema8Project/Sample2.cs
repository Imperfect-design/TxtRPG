


/////////// 클래스 전환

//    using System;
//using System.Collections.Generic;
//using System.Threading;
//using TxtRPG.Data;
//using TxtRPG.Game;
//using TxtRPG.Scene;

//namespace TxtRPG.Scene
//    {
//        class SkillView : Iscene
//        {
//            public object Run(GameData data)
//            {
//                Skill skill = new Skill();
//                Console.Clear();


//                if (data.Player.job == "전사")
//                {
//                    Dictionary<string, Skill> warrior = skill.WarriorSkillList(data);
//                    Skill firstSkill = warrior["두번베기"];
//                    Skill secondSkill = warrior["달려들기"];
//                    Skill thirdSkill = warrior["회복"];
//                    Skill fourthSkill = warrior["필살검"];
//                    Console.WriteLine($"{firstSkill.SkillNumber} {firstSkill.SkillName} 데미지:  {firstSkill.SkillDamage}  체력소모: {firstSkill.SkillHp}   마나소모:  {firstSkill.SkillMp}  해금레벨:  {firstSkill.UnlockLevel}");
//                    Console.WriteLine($"{secondSkill.SkillNumber} {secondSkill.SkillName} 데미지:  {secondSkill.SkillDamage}  체력소모: {secondSkill.SkillHp}  마나소모:   {secondSkill.SkillMp}  해금레벨:  {secondSkill.UnlockLevel}");
//                    Console.WriteLine($"{thirdSkill.SkillNumber}   {thirdSkill.SkillName} 데미지:  {thirdSkill.SkillDamage}  체력회복: {thirdSkill.SkillHp}   마나소모: {thirdSkill.SkillMp}  해금레벨:  {thirdSkill.UnlockLevel}");
//                    Console.WriteLine($"{fourthSkill.SkillNumber}   {fourthSkill.SkillName} 데미지:  {fourthSkill.SkillDamage}  체력소모: {fourthSkill.SkillHp} 마나소모:  {fourthSkill.SkillMp}  해금레벨:  {fourthSkill.UnlockLevel}");
//                    Console.WriteLine("0. 나가기");
//                    int input = int.Parse(Console.ReadLine());
//                    if (input == 0)
//                    {
//                        return new StatusScene();
//                    }
//                }
//                else if (data.Player.job == "마법사")
//                {
//                    Dictionary<string, Skill> mage = skill.MageSkillList(data);
//                    Skill firstSkill = mage["파이어"];
//                    Skill secondSkill = mage["불기둥"];
//                    Skill thirdSkill = mage["마나회복"];
//                    Skill fourthSkill = mage["필살불"];
//                    Console.WriteLine($"{firstSkill.SkillNumber}   {firstSkill.SkillName}  데미지:  {firstSkill.SkillDamage} 체력소모:   {firstSkill.SkillHp}    마나소모: {firstSkill.SkillMp}  해금레벨:  {firstSkill.UnlockLevel}");
//                    Console.WriteLine($"{secondSkill.SkillNumber}   {secondSkill.SkillName} 데미지:  {secondSkill.SkillDamage}  체력소모:   {secondSkill.SkillHp}    마나소모:   {secondSkill.SkillMp} 해금레벨:  {secondSkill.UnlockLevel}");
//                    Console.WriteLine($"{thirdSkill.SkillNumber}   {thirdSkill.SkillName} 데미지:  {thirdSkill.SkillDamage}  체력소모:   {thirdSkill.SkillHp}    마나회복:  {thirdSkill.SkillMp}  해금레벨:  {thirdSkill.UnlockLevel}");
//                    Console.WriteLine($"{fourthSkill.SkillNumber}   {fourthSkill.SkillName} 데미지:  {fourthSkill.SkillDamage}  체력소모:   {fourthSkill.SkillHp}    마나소모:  {fourthSkill.SkillMp}   해금레벨:  {fourthSkill.UnlockLevel}");
//                    Console.WriteLine("0. 나가기");
//                    int input = int.Parse(Console.ReadLine());
//                    if (input == 0)
//                    {
//                        return new StatusScene();
//                    }
//                }
//                else if (data.Player.job == "궁수")
//                {
//                    Dictionary<string, Skill> archer = skill.ArcherSkillList(data);
//                    Skill firstSkill = archer["세번쏘기"];
//                    Skill secondSkill = archer["네번쏘기"];
//                    Skill thirdSkill = archer["다섯번쏘기"];

//                    Console.WriteLine($"{firstSkill.SkillNumber}     {firstSkill.SkillName} 데미지:  {firstSkill.SkillDamage}   체력소모:   {firstSkill.SkillHp}      마나소모:  {firstSkill.SkillMp}  해금레벨:  {firstSkill.UnlockLevel}");
//                    Console.WriteLine($"{secondSkill.SkillNumber}     {secondSkill.SkillName} 데미지:  {secondSkill.SkillDamage}  체력소모:  {secondSkill.SkillHp}     마나소모: {secondSkill.SkillMp}  해금레벨:  {secondSkill.UnlockLevel}");
//                    Console.WriteLine($"{thirdSkill.SkillNumber}     {thirdSkill.SkillName} 데미지:  {thirdSkill.SkillDamage}   체력소모:  {thirdSkill.SkillHp}   마나소모:   {thirdSkill.SkillMp}  해금레벨:  {thirdSkill.UnlockLevel}");
//                    Console.WriteLine("0. 나가기");
//                    //int input = int.Parse(Console.ReadLine());
//                    if (!int.TryParse(Console.ReadLine(), out int input))
//                    {
//                        return this;
//                    }
//                    if (input == 0)
//                    {
//                        return new StatusScene();
//                    }
//                }
//                return this;

//            }


//        }
//    }
