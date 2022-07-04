using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class Player : Unit //унаследуемся от Юнита
    {
        delegate void Message();//объявили делегат
        Message myMessage;//объявляем переменную для использования делегата
        public override void Awake()
        {
            base.Awake();//получили ссылки и можем с ними работать дальше
            //myMessage = Temp;//в эту переменную присвоим адрес нашего метода

            myMessage += Temp;//через += можем добавить в один делегат сразу несколько методов. Групповая адресация
            myMessage += TempMessage;
        }


        public void Temp()//напишем метод для делегата с такой же сигнатурой
        {
            Debug.Log("Delegate 1");
            
        }
        public void TempMessage()//напишем метод для делегата с такой же сигнатурой
        {
            Debug.Log("Delegate 2");
        }
        public override void Move(float x, float y, float z)//переопределяем метод для перемещения
        {
            myMessage();//когда будет перемещаться, вызовется этот делегат

           //myMessage = TempMessage;//теперь через делегать вызовем другой метод

            //внутри будем заниматься измененимем координат x,y,z
            if(_rb)//проверим, прикрепился ли Риджидбоди. Если есть, то можем к нему обратиться
            {
                _rb.AddForce(new Vector3(x, y, z) * _speed);//добавим силы и умножим вектор на скаляр(скорость)
            }
                

        }
    }
}
