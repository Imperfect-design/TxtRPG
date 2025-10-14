using System.Xml;

class Status
{

        int level;
        string name;
        int str;
        int hp;
        int mp;
        int gold;

    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Str
    {
        get { return str; }
        set { str = value; }
    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public int Mp
    {
        get { return mp; }
        set { mp = value; }
    }
    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    public void warrior(int level, string name, int str, int hp, int mp, int gold)
    {
        level = 1;
        name = "chad";
        str = 1000;
        hp = 100;
        mp = 10;
        gold = 1000;
    }
    public void view(int level, string name, int str, int hp, int mp, int gold)
    {
        Console.WriteLine(Level);
        Console.WriteLine(Name);
        Console.WriteLine(Str);
        Console.WriteLine(Hp);
        Console.WriteLine(Mp);
        Console.WriteLine(Gold);
    }
}
