using System;
using System.Collections.Generic;
using System.Threading;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.Scene;
using TxtRPG.UI;

namespace TxtRPG.Scene
{
    class SkillView : Iscene
    {
        public object Run(GameData data)
        {
            Skill skill = new Skill();
            Console.Clear();


            if (data.Player.job == "전사")
            {
                Dictionary<string, Skill> warrior = skill.WarriorSkillList(data);
                Skill firstSkill = warrior["두번베기"];
                Skill secondSkill = warrior["달려들기"];
                Skill thirdSkill = warrior["회복"];
                Skill fourthSkill = warrior["필살검"];
                UIManager.PrintCenterLine($"{firstSkill.SkillNumber,-3} {firstSkill.SkillName,-8} 데미지: {firstSkill.SkillDamage,-4} 체력소모: {firstSkill.SkillHp,-4} 마나소모: {firstSkill.SkillMp,-4} 해금레벨: {firstSkill.UnlockLevel,-2}");
                UIManager.PrintCenterLine($"{secondSkill.SkillNumber,-3} {secondSkill.SkillName,-8} 데미지: {secondSkill.SkillDamage,-4} 체력소모: {secondSkill.SkillHp,-4} 마나소모: {secondSkill.SkillMp,-4} 해금레벨: {secondSkill.UnlockLevel,-2}");
                UIManager.PrintCenterLine($"{thirdSkill.SkillNumber,-5} {thirdSkill.SkillName,-8} 데미지: {thirdSkill.SkillDamage,-4} 체력회복: {thirdSkill.SkillHp,-4} 마나소모: {thirdSkill.SkillMp,-4} 해금레벨: {thirdSkill.UnlockLevel,-2}");
                UIManager.PrintCenterLine($"{fourthSkill.SkillNumber,-4} {fourthSkill.SkillName,-8} 데미지: {fourthSkill.SkillDamage,-4} 체력소모: {fourthSkill.SkillHp,-4} 마나소모: {fourthSkill.SkillMp,-4} 해금레벨: {fourthSkill.UnlockLevel,-1}");
                UIManager.PrintYellow("0. 나가기");
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    return new StatusScene();
                }
            }
            else if (data.Player.job == "마법사")
            {
                Dictionary<string, Skill> mage = skill.MageSkillList(data);
                Skill firstSkill = mage["파이어"];
                Skill secondSkill = mage["불기둥"];
                Skill thirdSkill = mage["마나회복"];
                Skill fourthSkill = mage["필살불"];
                UIManager.PrintCenterLine($"{firstSkill.SkillNumber,-3} {firstSkill.SkillName,-10} 데미지: {firstSkill.SkillDamage,-5} 체력소모: {firstSkill.SkillHp,-5} 마나소모: {firstSkill.SkillMp,-5} 해금레벨: {firstSkill.UnlockLevel,-3}");
                UIManager.PrintCenterLine($"{secondSkill.SkillNumber,-3} {secondSkill.SkillName,-10} 데미지: {secondSkill.SkillDamage,-5} 체력소모: {secondSkill.SkillHp,-5} 마나소모: {secondSkill.SkillMp,-5} 해금레벨: {secondSkill.UnlockLevel,-3}");
                UIManager.PrintCenterLine($"{thirdSkill.SkillNumber,-3} {thirdSkill.SkillName,-10} 데미지: {thirdSkill.SkillDamage,-5} 체력소모: {thirdSkill.SkillHp,-4} 마나회복: {thirdSkill.SkillMp,-5} 해금레벨: {thirdSkill.UnlockLevel,-3}");
                UIManager.PrintCenterLine($"{fourthSkill.SkillNumber,-3} {fourthSkill.SkillName,-10} 데미지: {fourthSkill.SkillDamage,-5} 체력소모: {fourthSkill.SkillHp,-5} 마나소모: {fourthSkill.SkillMp,-5} 해금레벨: {fourthSkill.UnlockLevel,-3}");

                UIManager.PrintYellow("0. 나가기");
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    return new StatusScene();
                }
            }
            else if (data.Player.job == "궁수")
            {
                Dictionary<string, Skill> archer = skill.ArcherSkillList(data);
                Skill firstSkill = archer["세번쏘기"];
                Skill secondSkill = archer["네번쏘기"];
                Skill thirdSkill = archer["다섯번쏘기"];

                UIManager.PrintCenterLine($"{firstSkill.SkillNumber,-3} {firstSkill.SkillName,-10} 데미지: {firstSkill.SkillDamage,-5} 체력소모: {firstSkill.SkillHp,-5} 마나소모: {firstSkill.SkillMp,-5} 해금레벨: {firstSkill.UnlockLevel,-3}");
                UIManager.PrintCenterLine($"{secondSkill.SkillNumber,-3} {secondSkill.SkillName,-10} 데미지: {secondSkill.SkillDamage,-5} 체력소모: {secondSkill.SkillHp,-5} 마나소모: {secondSkill.SkillMp,-5} 해금레벨: {secondSkill.UnlockLevel,-3}");
                UIManager.PrintCenterLine($"{thirdSkill.SkillNumber,-3} {thirdSkill.SkillName,-10} 데미지: {thirdSkill.SkillDamage,-5} 체력소모: {thirdSkill.SkillHp,-4} 마나소모: {thirdSkill.SkillMp,-5} 해금레벨: {thirdSkill.UnlockLevel,-2}");
                UIManager.PrintYellow("0. 나가기");
                //int input = int.Parse(Console.ReadLine());
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    return this;
                }
                if (input == 0)
                {
                    return new StatusScene();
                }
            }
            return this;

        }


    }
}
