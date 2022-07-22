using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public interface ISaveDataBonus
    {
        void SaveBonus(GBData gB);
        GBData LoadBonus();
    }
        
}
