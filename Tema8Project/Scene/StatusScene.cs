using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.UI;

namespace TxtRPG.Scene
{
    public class StatusScene : Iscene
    {
        public object Run(GameData data)
        {
            //상태 표시
            while (true)
            {
                Console.Clear();
                UIManager.PrintTitle("[플레이어 정보]");
                UIManager.PrintCenterLine($"[{data.Player.job}]{data.Player.name} {data.Player.level}.Lv\n");
                UIManager.PrintCenterLine($"체력 {data.Player.hp}/{data.Player.maxHp} 마나 {data.Player.mp}/{data.Player.maxMp}\n");
                UIManager.PrintCenterLine($"공격력 {data.Player.damage} 치명타확률 {data.Player.critical} 회피확률 {data.Player.doge}\n");
                UIManager.PrintCenterLine($"경험치  {data.Player.exp} / {data.Player.maxExp}\n");
                UIManager.PrintCenterLine($"{data.Player.gold} G\n");
                LogManager.Show();
                UIManager.PrintYellow("1.인벤토리 2.스킬보기 0.나가기");
                UIManager.PrintYellow(">>>");
                //int input = int.Parse(Console.ReadLine());
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
                    Console.ReadKey();
                    continue;
                }
                //선택지 출력 및 연결
                switch (input)
                {
                    case 1:
                        return new InvenScene();
                        break;
                    case 2:
                        //스킬보기
                        return new SkillView();
                        break;
                    case 0:
                        return new TitleScene();
                        //나가기
                        break;
                    default:
                        Console.WriteLine("잘못된 입력값입니다. 다시 입력해주세요");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}