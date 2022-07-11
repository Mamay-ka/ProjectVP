using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class CameraController : IExecute
    {
        //������� ������ ��� ����������� �������������
        private Transform _player;
        private Transform _camera;
        private Vector3 _offcet;
       public CameraController(Transform player, Transform mainCamera)//� ����������� ������ ����� ���������� ����������� ������
        {
            //�������� ������
            _player = player;
            _camera = mainCamera;
            _offcet = _camera.position - _player.position;
            _camera.LookAt(_player);//�������� ������, ����� ��� �������� �� ������
        }
        public void Update()
        {
            _camera.position = _player.position + _offcet;//����� ����������� ��������� ������
        }

        //������� ��� � ��� ����
        public void CameraBump()
        {
            
            Debug.Log("You are great!");
            
        }
    }
}
