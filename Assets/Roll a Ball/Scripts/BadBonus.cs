using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;//
using System.Collections;

namespace Maze
{
   public struct BBData
    {
        public string Name;
        public Vector3 Position;
        public Quaternion Rotation;
        public bool BBisInteractable;

        public BBData(BadBonus bb)
        {
            Name = "BadBonus";
            Position = bb.transform.position;
            Rotation = bb.transform.rotation;
            BBisInteractable = bb._isInteractable;

        }
    }

    public class BadBonus : Bonus, IFly, IRotation//����������� �� ������ � ������������� ��������� ����������
    {
        public BBData _bbData;
        private ISaveDataBadBonus _saveBBData;

        //private float hightFly;//���������� ��� ������ ������, ����� ����������� ����� Fly
        private float speedRotation;//���������� �������� �������� ��� ������ Rotate

                                                         // ��������� �����.                  
        public event Action<string, Color> OnGameOver = delegate (string str, Color color) { };//�������� ������� � ��������� �������� ������� � ������� �� ��������� � ����

        

        public override void Awake()//� A����� �������� ����������
        {
            
            base.Awake();
            _heightFly = Random.Range(1f, 2f);//�������� ����� ������, ����� ���� ����������.������ ������ �� 1 �� 5 ������
            speedRotation = Random.Range(13f, 40f);

            _bbData = new BBData(this);
            _saveBBData = new JSonDataBadBonus();

            _saveBBData.SaveBBData(_bbData);

            BBData tempBB = new BBData();
            tempBB = _saveBBData.LoadBB();

            Debug.Log(tempBB.Name);
            Debug.Log(tempBB.Position);
            Debug.Log(tempBB.Rotation);
            Debug.Log(tempBB.BBisInteractable);

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
            OnGameOver?.Invoke(gameObject.name, _color);//�������� ������� � ��������� �� ���� ����� �����(� ������� ��� ������ ������ � ��� ����)
                                                        //� ���������� ����������� ������, ������� �������� ��� ���������
        }
        
        public override void Update()
        {
            Fly();
            Rotate();
        }
    }
}
