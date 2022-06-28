using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;//создаем ссылку на InputController
        [SerializeField] private Unit _player;//ссылка на игрока.Сериализуем поле, чтобы открыть его в редакторе

        private void Awake()
        {
            _inputController = new InputController(_player); //создадим экземпляр InputController-а
                                                            //вызываем конструктор и создаем нашего игрока
        }

        void Update()
        {
            _inputController.Update();//вызываем метод Update из InputController-ф
        }
    }
}
