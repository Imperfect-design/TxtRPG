using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
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
                //인벤토리 로직
                string input = UIManager.ConsoleArray(() =>
                {
                    UIManager.PrintCenterLine("===== 인벤토리 =====");
                    //인벤토리에 아이템이 없을 때
                    if (player.inventory.items.Count == 0)
                    {
                        UIManager.PrintCenterLine("인벤토리가 비어있습니다.");
                        LogManager.Add($"비어있는 인벤토리는 내 마음의 공허함과 같다");
                    }
                    //있을 때 index지정 및 장착 토글, 아이템 타입 별 디스크립션
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
                            string info="";
                            if (item.type == ItemType.Weapon)
                                info = $"[공격력 +{item.dmg}]";
                            if (item.type == ItemType.Armor)
                                info = $"[체력 +{item.hp}]";
                            if (item.type == ItemType.Consumable)
                                info = $"[회복: HP+{player.maxHp / item.healHp}, MP+{player.maxMp / item.healMp}]";
                            UIManager.PrintCenterLine($"{index}. {item.name}{equipped} - {info} x{item.count} [판매가 개당 {item.sell}G / 전체{item.sell * item.count}G]");
                            index++;
                        }
                        LogManager.Add($"인벤토리를 열었습니다");
                    }
                    UIManager.PrintCenterLine("");
                    UIManager.PrintDivider("line");
                    LogManager.Show();
                    UIManager.PrintCenterLine("번호를 입력해서 장착 Or 해제합니다.");
                    UIManager.PrintCenterLine("0. 나가기");
                    UIManager.PrintCenter(">>   ");
                });
                //선택지 선택시 로직
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
                                //같은 무기, 방어구 선택시 해제 및 장착
                                player.equipWeapon = (player.equipWeapon == selectedItem) ? null : selectedItem;

                                if (player.equipWeapon != null)
                                    player.damage += selectedItem.dmg;
                                else
                                    player.damage -= selectedItem.dmg;

                                LogManager.Add($"{selectedItem.name} {(player.equipWeapon == selectedItem ? "장착" : "해제")}");
                                break;

                            case ItemType.Armor:
                                player.equipArmor = (player.equipArmor == selectedItem) ? null : selectedItem;
                                if (player.equipArmor != null)
                                {
                                    player.maxHp += selectedItem.hp;
                                    player.hp += selectedItem.hp;
                                }
                                else
                                {
                                    player.maxHp -= selectedItem.hp;
                                    player.hp -= selectedItem.hp;
                                }
                                LogManager.Add($"{selectedItem.name} {(player.equipArmor == selectedItem ? "장착" : "해제")}");
                                break;
                        }
                    }
                }
            }
        }
    }
}