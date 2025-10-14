//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TxtRPG
//{
//    public class Inven
//    {
//        public List<Item> items = new List<Item>();

//        public void AddItem(Item item) // 중복시 갯수추가
//        {
//            foreach (Item i in items)
//            {
//                if (i.name == item.name && i.type == item.type)
//                {
//                    i.count += item.count;
//                    return;
//                }
//            }
//            items.Add(item);
//        }
//    }
//}
