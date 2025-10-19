
//using System.Runtime.CompilerServices;
//using TxtRPG.Data;
//using TxtRPG.Scene;

//List<Monster> monsters = new List<Monster>()
//    {
//            new Monster("마왕", 99, 99, 99, 100),//몬스터의 이름. 레벨, 체력, 공격력,(추가: 치명타확률)
//            new Monster("사천왕", 4, 25, 40, 50),
//            new Monster("쫄따구", 1, 10, 10, 10)
//public class Monster
//{
//    public string monsterName { get; private set; }
//    public int monsterLevel { get; private set; }
//    public int monsterHp { get; private set; }
//    public int monsterAttackPower { get; private set; }
//    public int monsterCriticalAttackValue { get; private set; } //추가
//    public bool monsterIsAlive { get; private set; }

//    public Monster(string name, int level, int hp, int attackPower, int criticalvalue) //int criticalvalue
//    {
//        monsterName = name;
//        monsterLevel = level;
//        monsterHp = hp;
//        monsterAttackPower = attackPower;
//        monsterCriticalAttackValue = criticalvalue;  //추가
//        monsterIsAlive = true;
//    }

//    public void dogevalue(string Name)
//    {
//        Player player = new Player(Name);
//        Random random = new Random();
//        player.doge = random.Next(1, 101);
//        if (player.doge < 30)
//        {
//            Console.WriteLine("회피성공");
//        }
//        else
//        {
//            player.hp = player.hp - monsterAttackPower;
//        }
//    }
//    public void monsterCriticalAttack()
//    {
//        Random random = new Random();

//        int value = random.Next(1, 101);
//        if (value < monsterCriticalAttackValue)
//        {

//        }
//    }

//class Sample
//{
//    public int playerTurn;
//    public int monsterTurn;
//    public int TotalTurn;
//    public bool isTurn = false;
//    public bool isStun = false;
//    public int totalTurnSniffling;
//public bool isBattle = true;
//    public Sample()
//    {
//        playerTurn = 0;
//        monsterTurn = 0;
//        TotalTurn = 0;
//        totalTurnSniffling = TotalTurn % 2;
//    }
//    public int GetTurn()
//    {
//        if (BattleStart.)
//        {
//            while (true)
//            {
//                if (playerTurn == 0)
//                {
//                    playerTurn++;
//                    TotalTurn++;
//                    isTurn = true;
//                    continue;
//                }
//                else if (적이 다 없어진다면)
//              {
//                    playerTurn = 0;
//                    monsterTurn = 0;
//                    TotalTurn = 0;
//                    isTurn = true;
//                    break;
//                }
//            else if (공격하기를 눌렀을 경우에 && isturn = true)
//            {

//                    playerTurn++;
//                    TotalTurn++;
//                    isTurn = false;
//                    continue;
//                }


//               else if (상대가 공격하면 && isTurn = false)
//                {

//                    monsterTurn++;
//                    TotalTurn++;
//                    isTurn = true;
//                    continue;
//                }



//            }
//        }

//    }
//    class StatusAbnormality
//    {
//        int turn = 0;
//        Random random = new Random();



//        void Stun()
//        {
//            int statusEffect = random.Next(0, 101);
//            Sample sample = new Sample();
//            sample.isStun = true;
//            int count = 0;
//            while (true)
//            {
//                if (공격 또는 스킬을 사용했을 경우 && sample.totalTurnSniffling == 1)
//            {
//                    if (statusEffect < 30)
//                    {
//                        sample.isStun = true;


//                        if (sample.isStun == true)
//                        {
//                            sample.isTurn = false;
//                            몬스터가 공격하는 메서드 추가


//                            }

//                        else if (statusEffect < 30)
//                        {
//                            sample.isStun = false;
//                            break;
//                        }

//                        else if (count == 3)
//                        {
//                            break;
//                        }

//                    }
//                }
//            }



//        else if (공격 또는 스킬을 사용했을 경우 && sample.totalTurnSniffling == 0)
//        {
//                if (statusEffect < 30)
//                {
//                    sample.isStun = true;
//                    if (sample.isStun == true)
//                    {
//                        for (int i = 0; i <= 3; i++)
//                        {
//                            if (sample.isStun == true)
//                            {
//                                sample.isTurn = true;
//                                int input = int.Parse(Console.ReadLine());
//                                Console.WriteLine(1. "기본공격");
//                                Console.WriteLine(2. "스킬사용");
//                                Console.WriteLine(3. "아이템사용);

//                        }

//                            else if (statusEffect < 10)
//                            {
//                                sample.isStun = false;
//                                break;
//                            }

//                            else if (i == 3)
//                            {
//                                sample.isStun = false;
//                                break;
//                            }

//                        }
//                    }
//                }
//            }

//        }
//    }

//}



//자신이 공격 또는 스킬을 맞았을 경우
//상태이상 확률 적용 맞았다면 상태이상 아니면 밖으로 나간다
//움직임을 봉쇄한다
//공격 또는 아이템 사용이 안된다.
//상대방이 공격한다.
//턴의 수가 줄어든다.
//확률을 적용한다.
//그 후에 상태이상이 없어진다.


//private void Stun()
//{
//    Random random = new Random();
//    int statusEffect = random.Next(0, 101);
//    isStun = true;
//    int count = 0;
//    while (true)
//    {
//        if (HitPlayer == true)
//            }
//}

