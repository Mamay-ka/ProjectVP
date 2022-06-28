using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class BadBonus : Bonus, IFly, IRotation//наследуемся от Бонуса и реализовываем некоторые интерфейсы
    {
        private float hightFly;//переменная для высоты полета, чтобы реализовать метод Fly
        private float speedRotation;//переменная скорости вращения для метода Rotate

        private void Awake()//в Aвэйке назначим переменные
        {
            hightFly = Random.Range(1f, 5f);//назначим через Рандом, чтобы было интереснее.Высота полета от 1 до 5 юнитов
            speedRotation = Random.Range(13f, 40f);
        }

        public void Fly()//пока тела методов пустое, то это заглушки, чтобы не ругалась Юнити
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, hightFly), transform.position.z);//изменяется только игрек, поэтому возьмем мат.функцию Пинг-понг
            Debug.Log("I can fly");
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * speedRotation), Space.World);//возьмем метод Ротэйт из Трансформа.Вращаемся вокруг вертикальной оси
            Debug.Log("I can rotate");
        }

        protected override void Interaction()
        {
            //decreasе health
        }
        
        void Update()
        {
            Fly();
            Rotate();
        }
    }
}
