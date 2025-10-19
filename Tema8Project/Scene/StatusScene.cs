using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.UI;

namespace TxtRPG.Scene
{
    public class StatusScene : Iscene
    {
        public object Run(GameData data)
        {
            while (true)
            {
                Console.Clear();
                UIManager.PrintCenter("[플레이어 정보]\n");
                UIManager.PrintCenter($"[{data.Player.job}]{data.Player.name} {data.Player.level}.Lv\n");
                UIManager.PrintCenter($"체력 {data.Player.hp}/{data.Player.maxHp} 마나 {data.Player.mp}/{data.Player.maxMp}\n");
                UIManager.PrintCenter($"공격력 {data.Player.damage} 치명타확률 {data.Player.critical} 회피확률 {data.Player.doge}\n");
                UIManager.PrintCenter($"경험치  {data.Player.exp} / {data.Player.maxExp}\n");
                UIManager.PrintCenter($"{data.Player.gold} G\n");
                LogManager.Show();
                Console.WriteLine("1.인벤토리 2.스킬보기 0.나가기");
                Console.Write(">>>");
                //int input = int.Parse(Console.ReadLine());
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
                    Console.ReadKey();
                    continue;
                }
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