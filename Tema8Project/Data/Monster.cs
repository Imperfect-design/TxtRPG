using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TxtRPG.Data;


namespace Tema8Project.Data
{
    public class Monster
    {

        public string monsterName { get; set; }
        public int monsterLevel { get; set; }
        public int monsterHp { get; set; }
        public int monsterAttackPower { get; set; }
        public int monsterIndex { get; set; }
        public bool monsterIsAlive { get; set; }

        public string[] names = new string[] { "마왕", "사천왕", "쫄따구" };



        public Monster(GameData data)
        {
            Random random = new Random();

            monsterName = names[random.Next(names.Length)];
            monsterLevel = random.Next(Math.Max(1, data.Player.level - 5), data.Player.level + 6);
            monsterHp = monsterLevel * 1;//밸런스 조절은 if문 써서++100으로 돌려놓기
            monsterAttackPower = monsterLevel * 20;
            monsterIsAlive = true;
            monsterIndex = 0;
            List<Monster> monsters = new List<Monster>();

        }




    }

    public class PlayerInputNumber
    {
        public int playerInputNumber { get; set; }

        public PlayerInputNumber(GameData data)
        {
            playerInputNumber = 0;
        }

    }
}
