using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public abstract class Bonus : MonoBehaviour, IExecute
    {
        public bool _isInteractable;//����������, �����e� ���� ����� ��� ���.������������ ��� ���/���� �������
        protected Color _color;//������� ����. ������� ���������, ����� �� ����� ��� ��������
        private Renderer _renderer;//������� ������ �� ���������� ��������� � ����������
        private Collider _collider;

        public float _heightFly;

        public bool IsInteractable//��������� _isInteractable ��� ��������, ����� ������ ������������� ������ ������� ��� ���
        { 
            get => _isInteractable;

            set
            {
                _isInteractable = value;
                //����� ��� ���/���� ����������
                BonusRenderer.enabled = value;//������ �������� � ��������� ���� ��������� ��� ��������������
                _collider.enabled = value;//
            }
        }

        public Renderer BonusRenderer { get => _renderer; set => _renderer = value; }//������� �������� ���������. ����� �� ������������� � ����������

        public virtual void Awake()//�������� ����� ��� �������������
        {
            BonusRenderer = GetComponent<Renderer>();//�������� Rendere � Collider
            _collider = GetComponent<Collider>();

            IsInteractable = true;
            _color = Random.ColorHSV();//�������� ���� ����� Random � ������ ����� ColorHVS(),�������� ���� ��� ��������� ����
            BonusRenderer.sharedMaterial.color = _color;//������� ��������� �������� � ��������� ��� ��������
        }

        private void OnTriggerEnter(Collider other)//��� �������������� ������� ���� �����
        {
            if (IsInteractable || other.CompareTag("Player")) ;//�������� ���� ������ ������� ��� ��� Player
            {
                Interaction();//���� ��� ���, �� �������� ����� Interaction()
                IsInteractable = false;//��� �������������� ������ � �������, ������ �����������
            }
        }

        public abstract void Update();//��� ����, ����� ������� ������������ ������

                                                                                                
        protected abstract void Interaction();//�������������� ������ � ��������
    }
}
