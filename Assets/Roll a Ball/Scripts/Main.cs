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

        private InputController _inputController;//������� ������ �� InputControlle
        private CameraController _cameraController;//������� ������ ��� ������ CameraController
        private UIDisplayGameOver _displayGameOver;//������� ������ �� ����� UIDisplayGameOver



        private UIDisplayGameWin _displayGameWin;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        [SerializeField] private Unit _player;//������ �� ������.����������� ����, ����� ������� ��� � ���������
        [SerializeField] private Text _pointLabel;//������� ������
        [SerializeField] private Text _gameOverLabel;
        [SerializeField] private Button _restartButton;//�������� ������ ������� ����
        //[SerializeField] private Button _pushMe;



        [SerializeField] private Text _gameWinLabel;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        private ListExecuteObject _interactiveObject;//��� ������������� �������, ������� ����� ���������
        //private Player player;//�� IExecute
        //private InputController inputController;//�� IExecute 

        public int _bonusCount;//����������, ������� ������� ������



        private UIDisplayBonus _displayBonus;//������ �� ������������





        private void Awake()
        {


            Time.timeScale = 1f; //��������� �����
            _inputController = new InputController(_player); //�������� ��������� InputController-�
                                                             //�������� ����������� � ������� ������ ������
            _cameraController = new CameraController(_player._transform, Camera.main.transform);//�������� ������ 

            _interactiveObject = new ListExecuteObject();//������� ���������
                                                         // player = new Player();//�� IExecute
                                                         // inputController = new InputController();//�� IExecute
                                                         // _interactiveObject.AddExecuteObject(player);//�� IExecute
            _interactiveObject.AddExecuteObject(_inputController);//�� IExecute
            _interactiveObject.AddExecuteObject(_cameraController);//������� � ���������������� ����������������

            _displayBonus = new UIDisplayBonus(_pointLabel);//�������� ��������� DisplayBonus
            _displayGameOver = new UIDisplayGameOver(_gameOverLabel);

            _displayGameWin = new UIDisplayGameWin(_gameWinLabel);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


            _restartButton.onClick.AddListener(RestartGame); //����������������� �������������. ��������� ���������� AddListener

            //_restartButton.onClick.AddListener(_cameraController.CameraBump);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            _restartButton.gameObject.SetActive(false);//����� �� ��� ������ ����� ���������

            //_pushMe.gameObject.SetActive(false);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //_pushMe.onClick.AddListener(_cameraController.CameraBump);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

           
            foreach (var item in _interactiveObject)//�������e� � ���������, ���� �� � ��� ��� ������ ��� ���������
            {
                if (item is GoodBonus goodBonus)
                {
                    goodBonus.AddPoints += AddPoint;//���������� �� ���������� �������
                    //goodBonus.AddPoints += PushMe;
                   
                    

                }

                if (item is BadBonus badBonus)
                {
                    badBonus.OnGameOver += GameOver;//����������� ���������� �� �������
                    badBonus.OnGameOver += _displayGameOver.GameOver;//������������� �� ������� Game Over. ������������ ������ ��������� ��� ����� GameOver  
                }
            }


        }
        private void AddPoint(int value)//���������� ��� ���������
        {
            _bonusCount += value;//����� ��������� ����� ���������� �����
            _displayBonus.Display(_bonusCount);//���������� �� ������. �������� ����� ������� � �������� ����������


            if (_bonusCount == 10)//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            {
                GameWinPlayer();

            }
        }

        private void RestartGame()
        {

            SceneManager.LoadScene(0);//������������ �����
        }

        private void GameOver(string value, Color color)//���������� ��� ���������
        {
            //UI
            _restartButton.gameObject.SetActive(true);//�������
            Time.timeScale = 0f;//��������� �����

        }

        /*private void PushMe(int value)//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {

           // _pushMe.gameObject.SetActive(true);
            

        }*/
                
        private void GameWinPlayer()//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
                 
                _displayGameWin.GameWin();
                _restartButton.gameObject.SetActive(true);//�������
                Time.timeScale = 0f;//��������� �����
            
        }
        
        

        void Update()
        {
           //if(Input.GetKeyDown(KeyCode.W))
            {
                //_pushMe.gameObject.SetActive(false);
            }
            //_inputController.Update();//�������� ����� Update �� InputController-�

            /* if(_interactiveObject.MoveNext())//�� IExecute
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
