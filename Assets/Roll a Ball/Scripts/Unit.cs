using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public abstract class Unit : MonoBehaviour //помечаем модификатором abstract
    {
        public Transform _transform;//ссылка для трансформа. будем часто пользоваться
        public Rigidbody _rb; //ссылка для риджитбоди

        public float _speed = 5f;//будет скорость в любом случае
        public int _health = 100;
        public bool _isDead;
       

        public virtual void Awake()//пропишем Авэйк для инициализации
        {
            _transform = GetComponent<Transform>();//назначим трансформ и риджитбоди
            _rb = GetComponent<Rigidbody>();
        }

        public abstract void Move(float x, float y, float z);//вынесем метод Move  из Plaer и сделаем его абстрактным. Чтобы другие сущности могли использовать его. 
                                                            // просто предоставляем реализацию этого метода для перемещения сущностей

        
    }                                
}
