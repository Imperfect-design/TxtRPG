using System;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.UI;


namespace TxtRPG.Scene
{
    public class TitleScene : Iscene
    {
        public object Run(GameData data)
        {
            GameManager gm = new GameManager();
            //초기 주어지는 장비.
            if (data.Player.inventory.items.Count == 0)
            {
                if (data.Player.job == "궁수")
                    data.Player.inventory.AddItem(new Item("활처럼 휘어진 키보드", ItemType.Weapon, 1, 50, 0, 0, 0, 10));
                else if (data.Player.job == "전사")
                    data.Player.inventory.AddItem(new Item("날카롭게 갈린 키보드", ItemType.Weapon, 1, 50, 0, 0, 0, 10));
                else if (data.Player.job == "마법사")
                    data.Player.inventory.AddItem(new Item("수정구를 붙힌 키보드", ItemType.Weapon, 1, 50, 0, 0, 0, 10));

                data.Player.inventory.AddItem(new Item("마우스선으로 감은 갑옷", ItemType.Armor, 1, 0, 50, 0, 0, 10));
                data.Player.inventory.AddItem(new Item("커피", ItemType.Consumable, 10, 0, 0, 2, 2, 10));
                LogManager.Add("기본 장비가 추가되었다");
            }
            string input = UIManager.ConsoleArray(() =>
            {
                UIManager.PrintTitle("==== 시작부터 마왕나옴 ====");
                UIManager.PrintCenterLine("시작부터 마왕을 만나실 당신을 환영합니다.");
                UIManager.PrintDivider("line");
                Console.WriteLine();
                LogManager.Show();
                UIManager.PrintYellow("1. 상태 보기");
                UIManager.PrintYellow("2. 전투 시작");
                UIManager.PrintYellow("3. 퀘스트 보기");
                UIManager.PrintDarkYellow("4. 게임 저장");
                UIManager.PrintDarkYellow("5. 불러오기");
                UIManager.PrintCenterLine("0. 게임 종료");
                Console.WriteLine();
                UIManager.PrintCenter(">>    ");
            });

            switch (input)
            {
                case "1":
                    return new StatusScene();
                case "2":
                    return new BattleStartScene();
                case "3":
                    return new QuestScene(data);
                case "4":
                    new GameManager().SaveGame(data);
                    return this;
                case "5":
                    //GameData loaded = gm.Load();

                    //if (loaded != null)
                    //{
                    //    GameManager.data = loaded;
                    //    data = GameManager.data;
                    //    LogManager.Add("저장된 데이터를 불러왔습니다.");
                    //}
                    //else
                    //{
                    //    LogManager.Add("불러오기에 실패했습니다.");
                    //}

                    return this;


                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    UIManager.PrintCenterLine("혹시 잘못 적으시지 않으셨습니까?.");
                    Console.ReadKey();
                    break;
            }
            return this;
        }
    }
}
