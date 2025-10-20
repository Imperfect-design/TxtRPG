using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.UI;

namespace TxtRPG.Scene
{
    public class NewCharacterScene : Iscene
    {
        public object Run(GameData data)
        {
            //함수의 반환값 name, job에 저장, 합치기 추천
            string name = inputName();
            string job = jobSelect();

            data.Player.name = name;
            data.Player.job = job;
            //직업 선택, 선택시 기본 능력 변환
            switch (data.Player.job)
            {
                case "전사":
                    data.Player.maxHp = 200;
                    data.Player.hp = data.Player.maxHp;
                    data.Player.maxMp = 15;
                    data.Player.mp = data.Player.maxMp;
                    data.Player.damage = 15;
                    break;
                case "궁수":
                    data.Player.maxHp = 150;
                    data.Player.hp = data.Player.maxHp;
                    data.Player.maxMp = 25;
                    data.Player.mp = data.Player.maxMp;
                    data.Player.damage = 25;
                    break;
                case "마법사":
                    data.Player.maxHp = 120;
                    data.Player.hp = data.Player.maxHp;
                    data.Player.maxMp = 50;
                    data.Player.mp = data.Player.maxMp;
                    data.Player.damage = 40;
                    break;
            }

            return new TitleScene();
        }
        //캐릭터 이름 설정.
        private static string inputName()
        {
            string inputYourName = UIManager.ConsoleArray(() =>
            {
                UIManager.PrintTitle("이름 설정");
                UIManager.PrintCenterLine("당신의 이름을 입력하세요");
                UIManager.PrintCenterLine("");
            });
            Console.WriteLine();
            UIManager.PrintYellow($"당신의 이름은 이제부터 {inputYourName}입니다!");
            return inputYourName;
        }
        //캐릭터 직업 설정
        private static string jobSelect()
        {
            string job = "";
            bool isChoosed = false;


            while (!isChoosed)
            {
                Console.WriteLine();
                UIManager.PrintTitle("직업 선택");
                UIManager.PrintYellow("당신의 직업을 선택하세요");
                UIManager.PrintYellow("1. 전사 2. 궁수 3. 마법사");
                UIManager.PrintCenterLine("");
                UIManager.PrintCenter(">>");

                if (!int.TryParse(Console.ReadLine(), out int chooseJob))
                {
                    UIManager.PrintRed("다시 입력해 주세요.");
                    continue;
                }
                //int chooseJob = int.Parse(Console.ReadLine());
                //직업 선택. 선택시 break
                switch (chooseJob)

                {
                    case 1:
                        job = "전사";
                        UIManager.PrintDarkYellow("\"전사를 고르셨습니다.\"");
                        isChoosed = true;
                        Thread.Sleep(1000);
                        break;
                    case 2:
                        job = "궁수";
                        UIManager.PrintDarkYellow("\"궁수를 고르셨습니다.\"");
                        isChoosed = true;
                        Thread.Sleep(1000);
                        break;
                    case 3:
                        job = "마법사";
                        UIManager.PrintDarkYellow("\"마법사를 고르셨습니다.\"");
                        isChoosed = true;
                        Thread.Sleep(1000);
                        break;
                    default:
                        UIManager.PrintDarkYellow("잘못된 입력입니다.");
                        break;
                }
            }
            return job;
        }
    }
}

