class BattleStartScene
{

    static void Main(string[] args)
    {
        DisplayScene();//
    }

    private void DisplayScene()
    {
        Console.Clear();

        Monster enemy = Monster.GetRandomMonster(monsters);

        Console.WriteLine($"Battle!!\n\nLV.몬스터레벨 몬스터이름 HP 몬스터HP값");//몬스터 정보 출력
        //player Class에 접근해서 플레이어 정보 출력

        string input = Console.ReadLine();

        if (input == "1")
        {
            DisplayPlayerInfo();
        }
        else
        {
            while (input != "1")
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.Write(">>");
                input = Console.ReadLine();
                if (input == "1")
                {
                    DisplayPlayerInfo();
                }

            }
        }

    }
}


class Monster
{
    public Monster(string name, int level, int hp, int attackPower)
    {
        Name = name;
        Level = level;
        Hp = hp;
        AttackPower = attackPower;
        IsAlive = true;
    }


    List<Monster> monsters = new List<Monster>()
    {
        new Monster("마왕", 99, 99),//이름. 레벨, 체력
        new Monster("사천왕", 4, 25),
        new Monster("쫄따구", 1, 10)
    };
}

