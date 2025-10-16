using System;
using Tema8Project.Data;
using TxtRPG.Data;

namespace TxtRPG.Game
{
    public interface Iscene
    {
        object Run(GameData data);
    }
}