using System;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class GoodBonus : Bonus, IFly, IFlick
    {
        public event Action<int>AddPoints = delegate (int i){ };//событие
        
        

        private Material _material;
        private int _point;
        

        

        public override void Awake()
        {
            base.Awake();
            _material = BonusRenderer.material;//из класса Bonus, чтобы повторно не запрашивать GetComponent из ссылки
            _heightFly =  0.5f;
            _point = 1;
            
            
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _heightFly), transform.position.z);
            
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1f));
           
        }

        protected override void Interaction()
        {
            //вызов события
            AddPoints?.Invoke(_point);//в Инвок передаем количество очков, которые будут даваться за бонус
                       
           
           
        }


        public override void Update()
        {
            Fly();
            Flick();
        }

        
    }
}
