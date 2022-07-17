using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace TestNsp
{
    

    public class Test : MonoBehaviour
    {
        //delegate void UI();//создадим делегат

        public UnityEvent TestUnityEvent;//создадим событие

               
        public void UserInfoHandler()//сделаем обработчик для нашего события
        {
            Debug.Log("Произошло событие");
        }

        //теперь мы можем вызвать наше событие в Старте через Инвок


        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public delegate int TestDelegate(int val1, int val2);

        event TestDelegate MyEvent;//так создается событие

        public delegate T Operation<T, K>(K val);//обобщенный делегат
        public Operation<float, int> TempGeneric;//переменная обобщенного делегата

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

            MyEvent += TempVoid;//подписка на событие на обработчик

            
            //будем создавать ЮнитиЭвент
            if (TestUnityEvent == null)//сначла проверяем, что наш эвент пуст. Если равен нулл, то создаем его
            {
                TestUnityEvent = new UnityEvent();//здесь конструктор будет пустой

                TestUnityEvent.AddListener(UserInfoHandler);//назначим листенер.UserInfoHandler эот слушатель нашего события
                
            }

            
            TestUnityEvent.Invoke();//вызываем событие. в момент вызова через Инвок вызовется UserInfoHandler


        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //summ(10, 20);//можно записать так
                //summ?.Invoke(30, 20);//или так. Через Инвок более безопасно
                OperationTest(20, 30, substraction);

                MyEvent?.Invoke(40, 60);//вызываем событие с проверкой на null и передадим какие-то значения

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                divide?.Invoke(100, 50);
            }

            
        }
        public void OperationTest(int a, int b, TestDelegate myDelegate)//один из параметров делегат
        {
            myDelegate(a, b); //можем вызвать делегат и присвоить ему А и Б
        }
        public TestDelegate temp()//в этом случае можем вызвать метод Темп. Вернется Мультиплай
        {
            return multiply;
        }
        int TempVoid(int x, int y)//обработчик для события
        {
            return 0;
        }
    }
}
