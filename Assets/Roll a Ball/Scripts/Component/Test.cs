using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace TestNsp
{
    

    public class Test : MonoBehaviour
    {
        //delegate void UI();//�������� �������

        public UnityEvent TestUnityEvent;//�������� �������

               
        public void UserInfoHandler()//������� ���������� ��� ������ �������
        {
            Debug.Log("��������� �������");
        }

        //������ �� ����� ������� ���� ������� � ������ ����� �����


        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public delegate int TestDelegate(int val1, int val2);

        event TestDelegate MyEvent;//��� ��������� �������

        public delegate T Operation<T, K>(K val);//���������� �������
        public Operation<float, int> TempGeneric;//���������� ����������� ��������

        public TestDelegate summ;
        public TestDelegate substraction;
        public TestDelegate multiply;
        public TestDelegate divide;

        static int Method1(int a, int b)
        {
            Debug.Log("summ: " + (a + b));
            return a + b;
        }
        static int Method2(int a, int b)
        {
            Debug.Log("subsrtraction: " + (a - b));
            return a - b;
        }
        static int Method3(int a, int b)
        {
            Debug.Log("multiply: " + (a * b));
            return a * b;
        }
        static int Method4(int a, int b)
        {
            Debug.Log("divide: " + (a / b));
            return a / b;
        }

        private void Start()
        {
            summ = Method1;
            substraction = Method2;
            multiply = Method3;
            divide = Method4;

            divide += Method1;
            divide += Method2;
            divide += Method3;
            divide += Method4;

            MyEvent += TempVoid;//�������� �� ������� �� ����������

            
            //����� ��������� ����������
            if (TestUnityEvent == null)//������ ���������, ��� ��� ����� ����. ���� ����� ����, �� ������� ���
            {
                TestUnityEvent = new UnityEvent();//����� ����������� ����� ������

                TestUnityEvent.AddListener(UserInfoHandler);//�������� ��������.UserInfoHandler ��� ��������� ������ �������
                
            }

            
            TestUnityEvent.Invoke();//�������� �������. � ������ ������ ����� ����� ��������� UserInfoHandler


        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //summ(10, 20);//����� �������� ���
                //summ?.Invoke(30, 20);//��� ���. ����� ����� ����� ���������
                OperationTest(20, 30, substraction);

                MyEvent?.Invoke(40, 60);//�������� ������� � ��������� �� null � ��������� �����-�� ��������

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                divide?.Invoke(100, 50);
            }

            
        }
        public void OperationTest(int a, int b, TestDelegate myDelegate)//���� �� ���������� �������
        {
            myDelegate(a, b); //����� ������� ������� � ��������� ��� � � �
        }
        public TestDelegate temp()//� ���� ������ ����� ������� ����� ����. �������� ����������
        {
            return multiply;
        }
        int TempVoid(int x, int y)//���������� ��� �������
        {
            return 0;
        }
    }
}
