using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtRPG;
using TxtRPG.Data;


namespace Tema8Project.Data
{
    public class GameData
    {
        public Player Player { get; set; }
        public Inven Inventory  { get; set; }
        public List<Item> Items { get; set; }
<<<<<<< HEAD
       
        public Monster Monster { get; set; }
=======
        public Monster monster { get; set; }
>>>>>>> NewMind

        public GameData()
        {
            Player = new Player("");
            Inventory = new Inven();
            Items = new List<Item>();
        }
    }
}
