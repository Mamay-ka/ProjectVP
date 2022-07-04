using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class GoodBonus : Bonus, IFly, IFlick
    {
        private Material _material;
        

        public override void Awake()
        {
            base.Awake();
            _material = BonusRenderer.material;//из класса Bonus, чтобы повторно не запрашивать GetComponent из ссылки
            _heightFly =  2f;
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
            //add health
        }


        public override void Update()
        {
            Fly();
            Flick();
        }

        
    }
}
