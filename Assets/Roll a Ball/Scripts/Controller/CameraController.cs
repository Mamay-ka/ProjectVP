using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class CameraController : IExecute
    {
        //заведем ссылки для внутреннего использования
        private Transform _player;
        private Transform _camera;
        private Vector3 _offcet;
       public CameraController(Transform player, Transform mainCamera)//в конструктор камеры будем передавать необходимые ссылки
        {
            //назначим ссылки
            _player = player;
            _camera = mainCamera;
            _offcet = _camera.position - _player.position;
            _camera.LookAt(_player);//повернем камеру, чтобы она смотрела на игрока
        }
        public void Update()
        {
            _camera.position = _player.position + _offcet;//будет обновляться трансформ камеры
        }

        //добавим все в наш Мэйн
        public void CameraBump()
        {
            
            Debug.Log("You are great!");
            
        }
    }
}
