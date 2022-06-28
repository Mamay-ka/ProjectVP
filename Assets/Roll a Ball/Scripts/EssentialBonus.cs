using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{



    public class EssentialBonus : Bonus, IRotation
    {
        private float _speedRotation;

        private void Awake()
        {
            _speedRotation = 10f; 
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
            Debug.Log(" I am rotating");
        }

        protected override void Interaction()
        {
            // get thing to win
        }

        
        void Update()
        {
            Rotate();
        }
    }
}
