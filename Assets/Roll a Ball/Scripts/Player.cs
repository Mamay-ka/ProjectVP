using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class Player : Unit //������������ �� �����
    {
        delegate void Message();//�������� �������
        Message myMessage;//��������� ���������� ��� ������������� ��������
        public override void Awake()
        {
            base.Awake();//�������� ������ � ����� � ���� �������� ������
            //myMessage = Temp;//� ��� ���������� �������� ����� ������ ������

            myMessage += Temp;//����� += ����� �������� � ���� ������� ����� ��������� �������. ��������� ���������
            myMessage += TempMessage;
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
