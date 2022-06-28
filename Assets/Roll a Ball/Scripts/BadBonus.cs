using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class BadBonus : Bonus, IFly, IRotation//����������� �� ������ � ������������� ��������� ����������
    {
        private float hightFly;//���������� ��� ������ ������, ����� ����������� ����� Fly
        private float speedRotation;//���������� �������� �������� ��� ������ Rotate

        private void Awake()//� A����� �������� ����������
        {
            hightFly = Random.Range(1f, 5f);//�������� ����� ������, ����� ���� ����������.������ ������ �� 1 �� 5 ������
            speedRotation = Random.Range(13f, 40f);
        }

        public void Fly()//���� ���� ������� ������, �� ��� ��������, ����� �� �������� �����
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, hightFly), transform.position.z);//���������� ������ �����, ������� ������� ���.������� ����-����
            Debug.Log("I can fly");
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * speedRotation), Space.World);//������� ����� ������ �� ����������.��������� ������ ������������ ���
            Debug.Log("I can rotate");
        }

        protected override void Interaction()
        {
            //decreas� health
        }
        
        void Update()
        {
            Fly();
            Rotate();
        }
    }
}
