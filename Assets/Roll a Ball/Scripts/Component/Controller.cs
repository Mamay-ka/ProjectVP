using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestMVC
{

    public class Controller //не будет наследования. Будем полностью свободны
    {//будет происходить инициализация
        private View _playerView;//это Вьюшка для игрока
        private View _triggerView;//это Вьюшка для триггера
        private Transform _playerT;//ссылка на трансформ плэйера

        public Controller(View playerView, View triggerView)//дальше конструктор
        {
            _playerView = playerView;
            _triggerView = triggerView;
            _playerT = _playerView.transform;

            //подпишем наш триггер на событие, которое здеcь будет обрабатываться
            //когда объект войдет в триггерную зону, Контроллер обработает событие
            //и будет здесь обработчик события
            _triggerView.OnLevelObjectContact += ControllerRecieveAction;

        }

        
        private void ControllerRecieveAction(Collider contactView, int val, Transform ObjT)//здесь мы будем рпинимать Коллайдер, какое-то число для примера
        {
            Debug.Log("Обработчик события: имя объекта в триггере: " + contactView.name);
            GameObject.Destroy(contactView.gameObject);//уничтожим contactView
        }


    }
}
