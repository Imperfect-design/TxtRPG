using System;
using TxtRPG.Data;

namespace TxtRPG.Game
{
    public interface Iscene
    {
        object Run(GameData data);
    }
}