using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;//

namespace Maze
{

    public class BadBonus : Bonus, IFly, IRotation//наследуемся от Бонуса и реализовываем некоторые интерфейсы
    {
        //private float hightFly;//переменная для высоты полета, чтобы реализовать метод Fly
        private float speedRotation;//переменная скорости вращения для метода Rotate

                                                         // анонимный метод.                  
        public event Action<string, Color> OnGameOver = delegate (string str, Color color) { };//создадим событие и передадим название объекта в который мы врезались и цвет

        

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
            OnGameOver?.Invoke(gameObject.name, _color);//вызываем событие с проверкой на нулл через Инвок(в скобках имя нашего бонуса и его цвет)
                                                        //в результате формируется объект, который содержит эти параметры
        }
        
        public override void Update()
        {
            Fly();
            Rotate();
        }
    }
}
