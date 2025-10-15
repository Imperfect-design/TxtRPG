using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 public class Status : TitleScene
{
    Random random = new Random();
    int level;
    string name;
    int str;
    int hp;
    int mp;
    int criticalAttack;
    int evasion = 50;
    int gold;
    
    
    protected Status()
    {
        Level = 1;
        Name = "chad";
        Str = 1000;
        Hp = 100;
        Mp = 10;

        criticalAttack = random.Next(0, 101);
        if (criticalAttack < 70)
        {
            
        }
        
        Evasion = random.Next(0,101);
        if(Evasion < 50)
        {
            //적에게 데미지 맞았을시 데미지 적용
        }
        else
        {
            //회피함 작성 x해도 되는걸로 암
        }
        Gold = 1000;
    }

    private int Level
    {
        get { return level; }
        set { level = value; }
    }
    private string Name
    {
        get { return name; }
        set { name = value; }
    }
    private int Str
    {
        get { return str; }
        set { str = value; }
    }
    private int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    private int Mp
    {
        get { return mp; }
        set { mp = value; }
    }
    private int CriticalAttack { get; set; } = 70;
    

    private int Evasion
    {
        get { return evasion; }
        set { evasion = value; }
    }

    private int Gold
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
        Console.WriteLine($"치명타확률{CriticalAttack}");
        Console.WriteLine($"회피율{Evasion}");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        while (true)
        {
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                Mainmenu();
            }
        }
    }
}

