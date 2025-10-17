using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tema8Project.Data;
using TxtRPG.Data;
using TxtRPG.Game;
using TxtRPG.UI;

namespace TxtRPG.Scene
{
    public class InvenScene : Iscene
    {
        public object Run(GameData data)
        {
            Player player = data.Player;

            while (true)
            {
                string input = UIManager.ConsoleArray(() =>
                {
                    UIManager.PrintTitle("===== 인벤토리 =====");

                    if (player.inventory.items.Count == 0)
                    {
                        UIManager.PrintCenter("인벤토리가 비어있습니다.");
                        LogManager.Add($"비어있는 인벤토리는 내 마음의 공허함과 같다");
                    }
                    else
                    {
                        int index = 1;
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
                            UIManager.PrintCenter($"{index}. {item.name}{equipped} - {info} x{item.count} [판매가 개당 {item.sell}G / 전체{item.sell * item.count}G]");
                            index++;
                        }
                        LogManager.Add($"인벤토리를 열었습니다");
                    }
                    UIManager.PrintCenter("");
                    UIManager.PrintDivider("line");
                    LogManager.Show();
                    UIManager.PrintCenter("번호를 입력해서 장착 Or 해제합니다.");
                    UIManager.PrintCenter("0. 나가기");
                    UIManager.PrintCenterLine(">>   ");

                });

                if (input == "0")
                {
                    LogManager.Add($"인벤토리를 닫았습니다.");
                    return new StatusScene();
                }
                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= player.inventory.items.Count)
                    {
                        Item selectedItem = player.inventory.items[choice - 1];

                        switch (selectedItem.type)
                        {
                            case ItemType.Weapon:
                                player.equipWeapon = (player.equipWeapon == selectedItem) ? null : selectedItem;
                                player.damage += selectedItem.dmg;
                                LogManager.Add($"{selectedItem.name} {(player.equipWeapon == selectedItem ? "장착" : "해제")}");
                                break;
                            case ItemType.Armor:
                                player.equipArmor = (player.equipArmor == selectedItem) ? null : selectedItem;
                                player.maxHp += selectedItem.hp;
                                player.hp += player.maxHp;
                                LogManager.Add($"{selectedItem.name} {(player.equipArmor == selectedItem ? "장착" : "해제")}");

                                break;
                        }
                    }
                }
            }
        }
    }
}