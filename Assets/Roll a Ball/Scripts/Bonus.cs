using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public abstract class Bonus : MonoBehaviour
    {
        private bool _isInteractable;//переменная, включeн этот бонус или нет.Понадобиться для вкл/выкл бонусов

        protected abstract void Interaction();
    }
}
