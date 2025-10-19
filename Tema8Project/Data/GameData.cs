using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtRPG;
using TxtRPG.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TxtRPG.Data
{
    public class GameData
    {
        public Player Player { get; set; }
        public Inven Inventory  { get; set; }
        public List<Item> Items { get; set; }
       
        public int PlayerInput { get; set; }

        public Monster monster { get; set; }
        public string[] monsterNames = {"쫄따구", "사천왕", "마왕" };

        public List<Monster> monsters = new List<Monster>();


        public GameData()
        {
            Player = new Player("");
            Inventory = new Inven();
            Items = new List<Item>();
            monsters = new List<Monster>();//중복 초기화?
            PlayerInput = 0;
        }
    }
}
