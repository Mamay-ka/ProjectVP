using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;//������� ������ �� InputController
        [SerializeField] private Unit _player;//������ �� ������.����������� ����, ����� ������� ��� � ���������

        private void Awake()
        {
            _inputController = new InputController(_player); //�������� ��������� InputController-�
                                                            //�������� ����������� � ������� ������ ������
        }

        void Update()
        {
            _inputController.Update();//�������� ����� Update �� InputController-�
        }
    }
}
