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
        Random random = new Random();
        public string monsterName { get; set; }
        public int monsterLevel { get; set; }
        public int monsterHp { get; set; }
        public int monsterAttackPower { get; set; }
        public int monsterIndex { get; set; }
        public bool monsterIsAlive { get; set; }

        public string[] names = new string[] { "마왕", "사천왕", "쫄따구" };

        public Monster(GameData data)
        {
            monsterName = names[random.Next(names.Length)];
            monsterLevel = 0; //버그 생겨서 여기는 초기화만 하고 BattleScene에서 수정예정
            monsterHp = monsterLevel * 100;//밸런스 조절은 if문 써서
            monsterAttackPower = monsterLevel * 20;
            monsterIsAlive = true;
            monsterIndex = 0;
        }



        public void EnemyPhase()
        {

        }


        public void TakeDamage(GameData data)//플레이어가 입힌 피해에 따라 몬스터의 체력이 감소하며 사망하는 메서드
        {
            double plusMinusDouble = data.Player.damage * 0.1f;


            int playerDamage = (int)data.Player.damage;//Player 클래스 데미지 자체를 int로 수정하는게 더 낫지 않을까?.?
            int plusMinusInt = (int)Math.Round(plusMinusDouble);


            Random randomPlayerDamge = new Random();
            int playerFinalDamage = randomPlayerDamge.Next(playerDamage - plusMinusInt, playerDamage + plusMinusInt);//Player가 가지는 계산식은 플레이어 클래스에 넣는게? 매서드 밖에 선언하고 클래스 받아서 가져오기


            ////int beforeMonsterHP = monsters[i].monsterHp;
            //int currentMonsterHP;


            //monsters[i].monsterHp -= playerFinalDamage;
            //if (monster.monsterHp <= 0)
            //{
            //    monster.monsterIsAlive = false;
            //    //드랍템 추가?
            //}

            //currentMonsterHP = monster.monsterHp;



        }

    }
}
