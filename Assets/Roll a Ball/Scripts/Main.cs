using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;//создаем ссылку на InputControlle
        private CameraController _cameraController;//заведем ссылку для класса CameraController
        [SerializeField] private Unit _player;//ссылка на игрока.Сериализуем поле, чтобы открыть его в редакторе

        private ListExecuteObject _interactiveObject;//все интерактивные объекты, которые нужно обновлять
        //private Player player;//из IExecute
        //private InputController inputController;//из IExecute 
        


        private void Awake()
        {
            _inputController = new InputController(_player); //создадим экземпляр InputController-а
                                                             //вызываем конструктор и создаем нашего игрока
            _cameraController = new CameraController(_player._transform, Camera.main.transform);//создадим объект 

            _interactiveObject = new ListExecuteObject();//создаем экземпляр
           // player = new Player();//из IExecute
           // inputController = new InputController();//из IExecute
           // _interactiveObject.AddExecuteObject(player);//из IExecute
            _interactiveObject.AddExecuteObject(_inputController);//из IExecute
            _interactiveObject.AddExecuteObject(_cameraController);//добавим в Интерактивобжект Камераконтроллер
           

        }

        
        void Update()
        {
            //_inputController.Update();//вызываем метод Update из InputController-ф

           /* if(_interactiveObject.MoveNext())//из IExecute
            {
               

            }*/
          /* while(etr.MoveNext())
           {
                Debug.Log(etr.Current);
           }
           etr.Reset();*/
          for(int i = 0; i <_interactiveObject.Length; i++)
            {
                if(_interactiveObject[i] == null)
                {
                    continue;
                }
                _interactiveObject[i].Update();
            }
        }
    }

    

}
