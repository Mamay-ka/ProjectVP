using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class BadBonus : Bonus, IFly, IRotation//����������� �� ������ � ������������� ��������� ����������
    {
        //private float hightFly;//���������� ��� ������ ������, ����� ����������� ����� Fly
        private float speedRotation;//���������� �������� �������� ��� ������ Rotate

        

        public override void Awake()//� A����� �������� ����������
        {
            base.Awake();
            _heightFly = Random.Range(1f, 2f);//�������� ����� ������, ����� ���� ����������.������ ������ �� 1 �� 5 ������
            speedRotation = Random.Range(13f, 40f);
        }

        public void Fly()//���� ���� ������� ������, �� ��� ��������, ����� �� �������� �����
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _heightFly), transform.position.z);//���������� ������ �����, ������� ������� ���.������� ����-����
            
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * speedRotation), Space.World);//������� ����� ������ �� ����������.��������� ������ ������������ ���
            
        }

        protected override void Interaction()
        {
            //decreas� health
        }
        
        public override void Update()
        {
            Fly();
            Rotate();
        }
    }
}
