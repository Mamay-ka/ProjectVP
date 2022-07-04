using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class BadBonus : Bonus, IFly, IRotation//наследуемся от Бонуса и реализовываем некоторые интерфейсы
    {
        //private float hightFly;//переменная для высоты полета, чтобы реализовать метод Fly
        private float speedRotation;//переменная скорости вращения для метода Rotate

        

        public override void Awake()//в Aвэйке назначим переменные
        {
            base.Awake();
            _heightFly = Random.Range(1f, 2f);//назначим через Рандом, чтобы было интереснее.Высота полета от 1 до 5 юнитов
            speedRotation = Random.Range(13f, 40f);
        }

        public void Fly()//пока тела методов пустое, то это заглушки, чтобы не ругалась Юнити
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _heightFly), transform.position.z);//изменяется только игрек, поэтому возьмем мат.функцию Пинг-понг
            
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * speedRotation), Space.World);//возьмем метод Ротэйт из Трансформа.Вращаемся вокруг вертикальной оси
            
        }

        protected override void Interaction()
        {
            //decreasе health
        }
        
        public override void Update()
        {
            Fly();
            Rotate();
        }
    }
}
