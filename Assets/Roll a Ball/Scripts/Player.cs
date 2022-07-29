using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public struct PlayerData //сделаем структуру для игрока
    {
        public string Name;
        public Vector3 Position;
        public Quaternion Rotation;
        public int Health;
        public bool PlayerDead;
       

        public PlayerData(Player player)
        {
            Name = player.name;
            Position = player.transform.position;
            Rotation = player.transform.rotation;
            Health = player._health;
            PlayerDead = player._isDead;
        }


    }

    public class Player : Unit //унаследуемся от Юнита
    {
        public PlayerData _playerData;
        private ISaveData _data;//ссылка на интрефейс с сохранением

        delegate void Message();//объявили делегат
        Message myMessage;//объявляем переменную для использования делегата
        public override void Awake()
        {
            base.Awake();//получили ссылки и можем с ними работать дальше
            //myMessage = Temp;//в эту переменную присвоим адрес нашего метода
            _health = 100;

            myMessage += Temp;//через += можем добавить в один делегат сразу несколько методов. Групповая адресация
            myMessage += TempMessage;

            _playerData = new PlayerData(this);//проинициализируем. Получим все данные прямо в Авэйке
            //_data = new JSONData();//инициализируем сохранение данных разными типами сохранений
            //_data = new StreamData();
            _data = new XMLData();

            _data.SaveData(_playerData);

            //теперь нужно загрузить нашу структуру после того, как мы ее сохранили
            PlayerData temp = new PlayerData();
            temp = _data.Load();//заполним ее тем, что вернет метод Load

            Debug.Log(temp.Health);
            Debug.Log(temp.Position);
            Debug.Log(temp.Rotation);
            Debug.Log(temp.PlayerDead);
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
