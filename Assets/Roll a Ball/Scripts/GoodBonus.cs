using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Maze
{
    public struct GBData
    {
        public string Name;
        public Vector3 Position;
        public Quaternion Rotation;
        public bool GDisInteractable;

        public GBData(GoodBonus gb)
        {
            Name = "GoodBonus";
            Position = gb.transform.position;
            Rotation = gb.transform.rotation;
            GDisInteractable = gb._isInteractable;
        }
    }

    public class GoodBonus : Bonus, IFly, IFlick
    {
        public GBData _gbData;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private ISaveDataBonus _saveDataBonus;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        public event Action<int>AddPoints = delegate (int i){ };//событие
        
        

        private Material _material;
        private int _point;
        

        

        public override void Awake()
        {
            base.Awake();
            _material = BonusRenderer.material;//из класса Bonus, чтобы повторно не запрашивать GetComponent из ссылки
            _heightFly =  0.5f;
            _point = 1;

            _gbData = new GBData(this);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _saveDataBonus = new JSONDataBonus();//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            _saveDataBonus.SaveBonus(_gbData);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            GBData tempBonus = new GBData();//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            tempBonus = _saveDataBonus.LoadBonus();

            Debug.Log(tempBonus.Name);
            Debug.Log(tempBonus.Position);
            Debug.Log(tempBonus.Rotation);
            Debug.Log(tempBonus.GDisInteractable);
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
