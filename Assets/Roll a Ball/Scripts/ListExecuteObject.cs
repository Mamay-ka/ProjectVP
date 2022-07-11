using System.Collections;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Maze
{

    public class ListExecuteObject : IEnumerable, IEnumerator//� ���� ���� �������� ��� ������������� �������, ������� ����� ���������
    {
        private IExecute[] _interactiveObject;//������� ������, ����� �������� ���������� ������ MoveNext() �� IEnumenator-�
        private int _index = -1;//����� ��� ����������� ��������� ����������

        public object Current => _interactiveObject[_index]; //������� �������� ��� current-� � ����� ���������� _������
        public int Length => _interactiveObject.Length;//������� ������ � ����� ������� ����� ��������, ���� �� ���������� � ��� ���������

        public IExecute this[int curr]
        {
            get => _interactiveObject[curr];
            private set => _interactiveObject[curr] = value;
        }
        public ListExecuteObject()//������� ����������� ������ ������
        {
            Bonus[] BonusObj = Bonus.FindObjectsOfType<Bonus>();//������� ��������� ������ � ��������� � �� ����� ������������� ������ �������...
            for(int i = 0; i < BonusObj.Length; i++)
            {
                if(BonusObj[i] is IExecute IntObject)//��������� � ListExecuteObjec. ���� ���� ������� ������� ��������� ���� ���������
                {
                    AddExecuteObject(IntObject);//�� �� ��� ��������� � ��� ����� ����
                }

            }
            //���������� ������������� ������ �������
            //������� ������ � ������� � ��� ������
        }

        //������� ��������, ������� �������� ��� ��������� ������������� �������
        public void AddExecuteObject(IExecute execute)//���� �������� ������������ ������
        {
            //����� ����� ������, ������� �� ��������� � ������
            if(_interactiveObject == null)//���������, ���� _���������������� ��� ���,
            {
                _interactiveObject = new[] { execute };//�� ������� ����� _���������������� � ���� ��������� execute
                                                       //����� ��������� ������ ����� �������
                return;
            }

            //�������� ������ �� �������
            Array.Resize(ref _interactiveObject, Length + 1);
            _interactiveObject[Length - 1] = execute;//� �������� ������� execute. ��������� ������ � ��������� ����� �������
        }

        //������� ������, ������� ��� ���������� ����������� ���������
        public bool MoveNext()//���� ����� ���������� ������� ������� �� ��������� �������
        {
            if(_index == Length - 1)
            {
                return false;//������, ��� ������������������ ��������� � ���������� ����
            }
            _index++;//���� ���, �� +1 � _�������
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }
        public IEnumerator GetEnumerator()//�������� �����, ������� ���������� ��� ����������
        {
            return this;
        }

        //�������� ����, ��� �� ����� �������� ��� ����������

        IEnumerator IEnumerable.GetEnumerator()//��� ��������� � ����������, ������ ��������� �������������
        {
            return GetEnumerator();
        }

        //�������� ��������� ���������� ������������� ��������
       /* public class Player : IExecute
        {
            public void Update()
            {
                Debug.Log("Update Player");
            }
        }

        public class InputController : IExecute
        {
            public void Update()
            {
                Debug.Log("Update InputController");
            }
        }*/


    }
}


