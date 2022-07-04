using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;//������� ������ �� InputControlle
        private CameraController _cameraController;//������� ������ ��� ������ CameraController
        [SerializeField] private Unit _player;//������ �� ������.����������� ����, ����� ������� ��� � ���������

        private ListExecuteObject _interactiveObject;//��� ������������� �������, ������� ����� ���������
        //private Player player;//�� IExecute
        //private InputController inputController;//�� IExecute 
        


        private void Awake()
        {
            _inputController = new InputController(_player); //�������� ��������� InputController-�
                                                             //�������� ����������� � ������� ������ ������
            _cameraController = new CameraController(_player._transform, Camera.main.transform);//�������� ������ 

            _interactiveObject = new ListExecuteObject();//������� ���������
           // player = new Player();//�� IExecute
           // inputController = new InputController();//�� IExecute
           // _interactiveObject.AddExecuteObject(player);//�� IExecute
            _interactiveObject.AddExecuteObject(_inputController);//�� IExecute
            _interactiveObject.AddExecuteObject(_cameraController);//������� � ���������������� ����������������
           

        }

        
        void Update()
        {
            //_inputController.Update();//�������� ����� Update �� InputController-�

           /* if(_interactiveObject.MoveNext())//�� IExecute
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
