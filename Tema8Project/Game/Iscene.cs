using System;
using TxtRPG.Data;

namespace TxtRPG.Game
{
    //Iscene에 상속시키기
    public interface Iscene
    {
        //object로 반환, 가장 단순 
        object Run(GameData data);//데이터는 이걸로 함수 이름은 이걸로 한 애들만 불러와
    }
}