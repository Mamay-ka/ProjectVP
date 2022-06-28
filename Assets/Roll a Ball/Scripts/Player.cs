using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class Player : Unit //унаследуемся от Юнита
    {
        public override void Awake()
        {
            base.Awake();//получили ссылки и можем с ними работать дальше
        }

        public override void Move(float x, float y, float z)//переопределяем метод для перемещения
        {
            //внутри будем заниматься измененимем координат x,y,z
            if(_rb)//проверим, прикрепился ли Риджидбоди. Если есть, то можем к нему обратиться
            {
                _rb.AddForce(new Vector3(x, y, z) * _speed);//добавим силы и умножим вектор на скаляр(скорость)
            }
                

        }
    }
}
