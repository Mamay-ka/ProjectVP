using System.Collections;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Maze
{

    public class ListExecuteObject : IEnumerable, IEnumerator//в этот клас поместим все интерактивные объекты, которые нужно обновл€ть
    {
        private IExecute[] _interactiveObject;//заведем массив, чтобы показать реализацию метода MoveNext() из IEnumenator-а
        private int _index = -1;//далее нам понадобитс€ индексна€ переменна€

        public object Current => _interactiveObject[_index]; //сделаем свойства дл€ current-а и будем передавать _индекс
        public int Length => _interactiveObject.Length;//заведем доступ к длине массива через свойства, чтоб не обращатьс€ к ней посто€нно

        public IExecute this[int curr]
        {
            get => _interactiveObject[curr];
            private set => _interactiveObject[curr] = value;
        }
        public ListExecuteObject()//напишем конструктор нашего класса
        {
            Bonus[] BonusObj = Bonus.FindObjectsOfType<Bonus>();//напишем временный массив и обратимс€ к не очень эфффективному методу ‘индќбж...
            for(int i = 0; i < BonusObj.Length; i++)
            {
                if(BonusObj[i] is IExecute IntObject)//добавл€ем в ListExecuteObjec. ≈сли этот элемент массива реализует этот интерфейс
                {
                    AddExecuteObject(IntObject);//то мы его добавл€ем в наш общий лист
                }

            }
            //произведем инициализацию нашего массива
            //соберем Ѕонусы и добавим в наш массив
        }

        //напишем свойства, которые позвол€т нам добавл€ть интерактивные объекты
        public void AddExecuteObject(IExecute execute)//сюда передаем интерфейсную ссылку
        {
            //здесь будет объект, который мы добавл€ем в массив
            if(_interactiveObject == null)//провер€ем, если _интерактивќбжект это нул,
            {
                _interactiveObject = new[] { execute };//то создаем новый _интерактивќбжект и сюда добавл€ем execute
                                                       //можно заполнить массив таким образом
                return;
            }

            //увеличим массив на единицу
            Array.Resize(ref _interactiveObject, Length + 1);
            _interactiveObject[Length - 1] = execute;//и присвоим текущий execute. –асширили массив и присвоили новый элемент
        }

        //напишем методы, которые нас заставл€ет реализовать интерфэйс
        public bool MoveNext()//этот метод перемещает текущий элемент на следующую позицию
        {
            if(_index == Length - 1)
            {
                return false;//значит, что последовательность кончилась и возвращаем фолс
            }
            _index++;//если нет, то +1 к _индексу
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }
        public IEnumerator GetEnumerator()//создадем метод, который возвращает сам Ёнумератор
        {
            return this;
        }

        //варианты того, как мы можем запросит сам Ёнуменатор

        IEnumerator IEnumerable.GetEnumerator()//или обращение к Ёнумерэйбл, откуда запросить √етЁнумератор
        {
            return GetEnumerator();
        }

        //создадим некоторое количество интерактивных объектов
       /* public class Player : IExecute
        {
            public void Update()
            {
                Debug.Log("Update Player");
            }
        }

        public class InputController : IExecute
        {
            public void Update()
            {
                Debug.Log("Update InputController");
            }
        }*/


    }
}


