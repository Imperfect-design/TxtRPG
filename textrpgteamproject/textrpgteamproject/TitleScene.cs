class TitleScene
{
    public void Mainmenu()
    {
        Console.Clear();
        Console.WriteLine(" 1. 상태보기");
        Console.WriteLine(" 2. 전투시작");
        while (true)
        {
            int input = int.Parse(Console.ReadLine());
            
            if (input == 1)
            {

            }
            
            else if (input == 2)
            {

            }
            else
            {
                Console.Write("잘못입력했습니다");
            }
        }
        
       
    }
}
