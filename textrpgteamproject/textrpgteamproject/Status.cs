using System.Xml;
using System;

class Status
{

        int level;
        string name;
        int str;
        int hp;
        int mp;
        int gold;
   public Status()
    {
        Level = 1;
        Name = "chad";
        Str = 1000;
        Hp = 100;
        Mp = 10;
        Gold = 1000;
    }

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

   
    public void view()
    {
        Console.Clear();
        Console.WriteLine($"레벨: {Level}");
        Console.WriteLine($"이름:{Name}");
        Console.WriteLine($"공격력:{Str}");
        Console.WriteLine($"체력:{Hp}");
        Console.WriteLine($"마력{Mp}");
        Console.WriteLine($"골드{Gold}");
    }
}
