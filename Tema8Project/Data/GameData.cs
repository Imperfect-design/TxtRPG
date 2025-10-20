using System;
using System.Collections.Generic;
using TxtRPG;

namespace TxtRPG.Data
{
    //각 속성 인스턴스 보관
    public class GameData
    {
        public Player Player { get; set; }
        public Inven Inventory  { get; set; }
        public List<Item> Items { get; set; }
        //최근 입력값 보관용
        public int PlayerInput { get; set; }
        public Monster monster { get; set; }
        public string[] monsterNames = {"쫄따구", "사천왕", "마왕" };
        //필드 초기화용
        public List<Monster> monsters = new List<Monster>();


        //생성자 초기값
        public GameData()
        {
            Player = new Player("");
            Inventory = new Inven();
            Items = new List<Item>();
            //중복이라 필요 없음
            monsters = new List<Monster>();//중복 초기화?
            PlayerInput = 0;
        }
    }
}
