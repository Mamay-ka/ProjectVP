using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace Maze
{
    public class Main : MonoBehaviour
    {

        private InputController _inputController;//создаем ссылку на InputControlle
        private CameraController _cameraController;//заведем ссылку для класса CameraController
        private UIDisplayGameOver _displayGameOver;//добавим ссылка на класс UIDisplayGameOver



        private UIDisplayGameWin _displayGameWin;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        [SerializeField] private Unit _player;//ссылка на игрока.Сериализуем поле, чтобы открыть его в редакторе
        [SerializeField] private Text _pointLabel;//заведем ссылку
        [SerializeField] private Text _gameOverLabel;
        [SerializeField] private Button _restartButton;//включаем кнопку Рестарт Гэйм
        //[SerializeField] private Button _pushMe;



        [SerializeField] private Text _gameWinLabel;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        private ListExecuteObject _interactiveObject;//все интерактивные объекты, которые нужно обновлять
        //private Player player;//из IExecute
        //private InputController inputController;//из IExecute 

        public int _bonusCount;//переменная, которая считает бонусы



        private UIDisplayBonus _displayBonus;//ссылка на ДисплэйБонус





        private void Awake()
        {


            Time.timeScale = 1f; //запускаем время
            _inputController = new InputController(_player); //создадим экземпляр InputController-а
                                                             //вызываем конструктор и создаем нашего игрока
            _cameraController = new CameraController(_player._transform, Camera.main.transform);//создадим объект 

            _interactiveObject = new ListExecuteObject();//создаем экземпляр
                                                         // player = new Player();//из IExecute
                                                         // inputController = new InputController();//из IExecute
                                                         // _interactiveObject.AddExecuteObject(player);//из IExecute
            _interactiveObject.AddExecuteObject(_inputController);//из IExecute
            _interactiveObject.AddExecuteObject(_cameraController);//добавим в Интерактивобжект Камераконтроллер

            _displayBonus = new UIDisplayBonus(_pointLabel);//создадим экземпляр DisplayBonus
            _displayGameOver = new UIDisplayGameOver(_gameOverLabel);

            _displayGameWin = new UIDisplayGameWin(_gameWinLabel);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


            _restartButton.onClick.AddListener(RestartGame); //проинициализируем РестартБаттон. Добавляем обработчик AddListener

            //_restartButton.onClick.AddListener(_cameraController.CameraBump);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            _restartButton.gameObject.SetActive(false);//здесь мы наш объект будем выключать

            //_pushMe.gameObject.SetActive(false);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //_pushMe.onClick.AddListener(_cameraController.CameraBump);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

           
            foreach (var item in _interactiveObject)//переберeм и посмотрим, есть ли у нас Гуд Бонусы или БэдБонусы
            {
                if (item is GoodBonus goodBonus)
                {
                    goodBonus.AddPoints += AddPoint;//подпишемся на обработчик событий
                    //goodBonus.AddPoints += PushMe;
                   
                    

                }

                if (item is BadBonus badBonus)
                {
                    badBonus.OnGameOver += GameOver;//подписываем обработчик на событие
                    badBonus.OnGameOver += _displayGameOver.GameOver;//подписываемся на событие Game Over. Обработчиком теперь выступает сам метод GameOver  
                }
            }


        }
        private void AddPoint(int value)//обработчик для ГудБонуса
        {
            _bonusCount += value;//можно добавлять любое количество очков
            _displayBonus.Display(_bonusCount);//отображать на экране. Вызываем метод Дисплэй и передаем бонусКаунт


            if (_bonusCount == 10)//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            {
                GameWinPlayer();

            }
        }

        private void RestartGame()
        {

            SceneManager.LoadScene(0);//перезагрузка сцены
        }

        private void GameOver(string value, Color color)//обработчик для БэдБонуса
        {
            //UI
            _restartButton.gameObject.SetActive(true);//рестарт
            Time.timeScale = 0f;//остановим время

        }

        /*private void PushMe(int value)//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {

           // _pushMe.gameObject.SetActive(true);
            

        }*/
                
        private void GameWinPlayer()//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
                 
                _displayGameWin.GameWin();
                _restartButton.gameObject.SetActive(true);//рестарт
                Time.timeScale = 0f;//остановим время
            
        }
        
        

        void Update()
        {
           //if(Input.GetKeyDown(KeyCode.W))
            {
                //_pushMe.gameObject.SetActive(false);
            }
            //_inputController.Update();//вызываем метод Update из InputController-ф

            /* if(_interactiveObject.MoveNext())//из IExecute
             {


             }*/
            /* while(etr.MoveNext())
             {
                  Debug.Log(etr.Current);
             }
             etr.Reset();*/
            for (int i = 0; i <_interactiveObject.Length; i++)
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
