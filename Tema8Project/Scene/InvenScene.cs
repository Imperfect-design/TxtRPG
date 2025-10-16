using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema8Project.Data;
using TxtRPG.Data;
using TxtRPG.Game;

namespace TxtRPG.Scene
{
    public class InvenScene : Iscene
    {
        public object Run(GameData data)
        {
            Player player = data.Player;
            Console.Clear();
            Console.WriteLine("===== 인벤토리 =====");

            if (player.inventory.items.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어있습니다.");
                LogManager.Add($"비어있는 인벤토리는 내 마음의 공허함과 같다");
            }
            else
            {
                foreach (var item in player.inventory.items)
                {
                    string equipped = "";
                    if (player.equipWeapon != null && player.equipWeapon.name == item.name)
                        equipped = " [E]";
                    if (player.equipArmor != null && player.equipArmor.name == item.name)
                        equipped = " [E]";

                    string info = item.type switch
                    {
                        ItemType.Weapon => $"[공격력 +{item.dmg}]",
                        ItemType.Armor => $"[체력 +{item.hp}]",
                        ItemType.Consumable => $"[회복: HP+{player.maxHp / item.healHp}, MP+{player.maxMp / item.healMp}]",
                        ItemType.Loot => "[재료 아이템]",
                        _ => ""
                    };
                    Console.WriteLine($"{item.name}{equipped} - {info} x{item.count} [판매가 개당 {item.sell}G / 전체{item.sell*item.count}G]");
                }
                LogManager.Add($"인벤토리를 열었습니다");
            }

            Console.WriteLine("=====================");
            LogManager.Show();
            Console.WriteLine("0. 나가기");
            Console.WriteLine(">>");
            string input = Console.ReadLine();

            if (input == "0")
            {
                return new StatusScene();
            }
            return this;
        }
    }
}