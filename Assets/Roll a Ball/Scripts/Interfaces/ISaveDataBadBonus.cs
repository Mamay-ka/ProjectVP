using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public interface ISaveDataBadBonus
    {
        void SaveBBData(BBData _bb);
         BBData LoadBB();

    }
}
