using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    internal sealed class AccelerationMove : MoveTransform
    {
        
        private readonly float _acceleration;
        

        public AccelerationMove(Transform transform, float speed, float thrust, Rigidbody2D player,  float acceleration) : base(transform, speed, thrust, player)
        {
            
            _acceleration = acceleration;
            
        }

        public void AddAcceleration()
        {
            _thrust += _acceleration;
        }
        public void RemoveAcceleration()
        {
            _thrust -= _acceleration;
        }
    }
}
