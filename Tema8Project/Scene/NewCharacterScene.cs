using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtRPG.Data;
using TxtRPG.Game;

namespace TxtRPG.Scene
{
    public class NewCharacterScene : Iscene
    {
        public object Run(Player player)
        {
            string name = inputName();
            string job = jobSelect();

            player.name = name;
            player.job = job;

            return new TitleScene();
        }
        private static string inputName()
        {
            Console.Write("=====캐릭터 생성=====\n당신의 이름을 입력해주세요.\n>>");
            string inputYourName = Console.ReadLine();

            Console.WriteLine($"당신의 이름은 이제부터 {inputYourName}입니다!");
            return inputYourName;
        }

        private static string jobSelect()
        {

            string job = "";
            bool isChoosed = false;


            while (!isChoosed)
            {
                Console.Write("=====직업 선택=====\n당신의 직업을 선택하세요. (1. 전사 2. 궁수 3. 마법사 )\n>>");
                int chooseJob = int.Parse(Console.ReadLine());



                switch (chooseJob)

                {
                    case 1:
                        job = "전사";
                        Console.WriteLine("1. 전사 : \"전사를 고르셨습니다.\"");
                        isChoosed = true;
                        break;
                    case 2:
                        job = "궁수";
                        Console.WriteLine("2. 궁수 : \"궁수를 고르셨습니다.\"");
                        isChoosed = true;
                        break;
                    case 3:
                        job = "마법사";
                        Console.WriteLine("3. 마법사 : \"마법사를 고르셨습니다.\"");
                        isChoosed = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
            return job;
        }
    }
}

