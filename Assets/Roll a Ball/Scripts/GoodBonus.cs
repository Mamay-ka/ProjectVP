using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class GoodBonus : Bonus, IFly, IFlick
    {
        private Material _material;
        private float _lengthFly;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1f, 5f);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFly), transform.localPosition.z);
            Debug.Log("I can fly");
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1f));
            Debug.Log("I can flick");
        }

        protected override void Interaction()
        {
            //add health
        }


        void Update()
        {
            Fly();
            Flick();
        }

        
    }
}
