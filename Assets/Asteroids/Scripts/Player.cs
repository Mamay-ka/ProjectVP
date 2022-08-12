using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Rigidbody2D _player;//!!!!!!!!!!!!!!!!!!!!!!
        [SerializeField] private float _thrust;//!!!!!!!!!!!!!!!!!!!!!!
      
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;

        private float horizontal;
        private float vertical;


        private Camera _camera;
        private IMove _moveTransform;
        private IRotation _rotation;
        private IShoot _shoot;
        

        private void Start()
        {
            _camera = Camera.main;
           _moveTransform = new AccelerationMove(transform, _speed, _thrust, _player, _acceleration);
            _rotation = new RotationShip(transform);
            _shoot = new Shooting(_bullet, _barrel, _force);
            
            
        }

        void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _rotation.Rotation(direction);
            
                        
            _shoot.Shoot();

            //_moveTransform.MoveAddForce(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);
            horizontal = Input.GetAxis("Horizontal");//подменяем управление осями, если игрок хочет
            vertical = Input.GetAxis("Vertical");
            _moveTransform.MoveAddForce(horizontal, vertical);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.AddAcceleration();
                }

            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.RemoveAcceleration();
                }

            }

            
        }

        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}
