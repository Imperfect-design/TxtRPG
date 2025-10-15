using System;
using TxtRPG.Data;
using TxtRPG.Scene;

namespace TxtRPG.Game
{
    public interface Iscene
    {
        object Run(Player player);
    }
}