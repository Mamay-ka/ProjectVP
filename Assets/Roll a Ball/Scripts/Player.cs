using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public struct PlayerData //������� ��������� ��� ������
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

    public class Player : Unit //������������ �� �����
    {
        public PlayerData _playerData;
        private ISaveData _data;//������ �� ��������� � �����������

        delegate void Message();//�������� �������
        Message myMessage;//��������� ���������� ��� ������������� ��������
        public override void Awake()
        {
            base.Awake();//�������� ������ � ����� � ���� �������� ������
            //myMessage = Temp;//� ��� ���������� �������� ����� ������ ������
            _health = 100;

            myMessage += Temp;//����� += ����� �������� � ���� ������� ����� ��������� �������. ��������� ���������
            myMessage += TempMessage;

            _playerData = new PlayerData(this);//�����������������. ������� ��� ������ ����� � ������
            //_data = new JSONData();//�������������� ���������� ������ ������� ������ ����������
            //_data = new StreamData();
            _data = new XMLData();

            _data.SaveData(_playerData);

            //������ ����� ��������� ���� ��������� ����� ����, ��� �� �� ���������
            PlayerData temp = new PlayerData();
            temp = _data.Load();//�������� �� ���, ��� ������ ����� Load

            Debug.Log(temp.Health);
            Debug.Log(temp.Position);
            Debug.Log(temp.Rotation);
            Debug.Log(temp.PlayerDead);
        }


        public void Temp()//������� ����� ��� �������� � ����� �� ����������
        {
            Debug.Log("Delegate 1");
            
        }
        public void TempMessage()//������� ����� ��� �������� � ����� �� ����������
        {
            Debug.Log("Delegate 2");
        }
        public override void Move(float x, float y, float z)//�������������� ����� ��� �����������
        {
            myMessage();//����� ����� ������������, ��������� ���� �������

           //myMessage = TempMessage;//������ ����� �������� ������� ������ �����

            //������ ����� ���������� ����������� ��������� x,y,z
            if(_rb)//��������, ����������� �� ����������. ���� ����, �� ����� � ���� ����������
            {
                _rb.AddForce(new Vector3(x, y, z) * _speed);//������� ���� � ������� ������ �� ������(��������)
            }
                

        }
    }
}
