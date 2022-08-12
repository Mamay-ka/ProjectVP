using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    internal class MoveTransform : IMove
    {
       
        //private readonly Transform _transform;
        //private Vector2 _move;
        public float _thrust { get; protected set; }
        private Rigidbody2D _player;


        public float Speed { get; protected set; }
        public MoveTransform(Transform transform, float speed, float thrust, Rigidbody2D player)
        {
            //_transform = transform;
            //Speed = speed;
            _thrust = thrust;
            _player = player;
        }

        
        public void MoveAddForce(float x, float y)
        {
            //var speed = deltaTime * Speed;
            //_move.Set(horizontal * speed, vertical * speed, 0.0f);
           // _transform.localPosition += _move;

            if (_player)//проверим, прикрепился ли Риджидбоди. Если есть, то можем к нему обратиться
            {
                _player.AddForce(new Vector2(x,y) *_thrust);//добавим силы и умножим вектор на скаляр(скорость)
            }

        }
    }
}
