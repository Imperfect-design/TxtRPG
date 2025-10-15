using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtRPG.Data;

namespace TxtRPG
{
    public class InvenScene
    {
        public void Run(Player player)
        {
            Console.WriteLine("===== 인벤토리 =====");

            if (player.inventory.items.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어있습니다.");
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
            }

            Console.WriteLine("=====================");
        }
    }
}