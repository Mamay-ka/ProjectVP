using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;




namespace Temp
{


    public class TempTest : MonoBehaviour
    {
        List<string> testList = new List<string>();//������� ����� ����

        LinkedList<int> linkedList = new LinkedList<int>();

        List<int> DZ7List = new List<int>();

                   
                
        public void Start()
        {
            /*testList.Add("Test");//��������� � ������ ��������
            testList.Add("Temp");
            testList.Add("Example");
            testList.Add("Null");
            testList.Add("Value");
          
            testList.Sort();//���������

            for(int i = 0; i < testList.Count; i++)//�������, ��� ����������
            {
                Debug.Log(testList[i]);
            }

            linkedList.AddFirst(500);
            linkedList.AddLast(10000);
            linkedList.AddAfter(linkedList.First, 455);
          
            linkedList.AddBefore(linkedList.Last, 300);
            foreach(int i in linkedList)
            {
                Debug.Log(i);
                
            }*/

            for(int i = 0; i < 10; i++)
            {
                DZ7List.Add(Random.Range(0, 10));
                Debug.Log("���������, ����������������� ������");
                Debug.Log(DZ7List[i]);
            }

            DZ7List.Sort();

            for (int i = 0; i < 10; i++)
            {
                Debug.Log("��������������� ������ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(DZ7List[i]);
            }
            Debug.Log("##################################################");

            int a = 0;

            for (int i = 0; i < DZ7List.Count -1;  i++)
            {
                
                if (DZ7List[i] == DZ7List[i + 1])
                {
                   
                    a ++;
                }
                else
                {
                    
                    Debug.Log("������� " + DZ7List[i] + " ����������� " + (a + 1) + " ���");

                    a=0;
                    
                }continue;
                                
            }
            for (int i = DZ7List.Count-1; i > 0; i--)
            {
                if (DZ7List[i] == DZ7List[i-1] && i <=8)
                {
                    a++;
                }
                else
                {
                    a = a + 1;
                    Debug.Log("������� " + DZ7List[i] + " ����������� " + (a ) + " ����");
                    break;
                }
               
               
            }
            
        }
    }
}
