using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TxtRPG;
using TxtRPG.Data;


namespace Tema8Project.Data
{
    public class Monster
    {
        
        public string monsterName { get; set; }
        public int monsterLevel { get; set; }
        public int monsterHp { get; set; }
        public int monsterMaxhp { get; set; }
        public int monsterAttackPower { get; set; }
        public int monsterIndex { get; set; }
        public bool monsterIsAlive { get; set; }

        public string[] names = new string[] { "마왕", "사천왕", "쫄따구" };
        public Monster(GameData data)
        {
            Random random = new Random(); 

            monsterName = names[random.Next(names.Length)];
            monsterLevel = random.Next(Math.Max(1, data.Player.level - 5), data.Player.level + 6);
            monsterMaxhp = monsterLevel * 100;//밸런스 조절
            monsterHp = monsterMaxhp;
            monsterAttackPower = monsterLevel * 20;
            monsterIsAlive = true;
            monsterIndex = 0;
        }


                
        public void TakeDamage(GameData data)
        {
            if (!monsterIsAlive) return;
            monsterHp -= data.Player.damage;
            if(monsterHp <=0 )
            {
                monsterIsAlive = false;
                data.Player.ExpUp(monsterLevel);
                LogManager.Add($"{monsterName}이(가) 사망하였다!");
            }
        }

    }
}
