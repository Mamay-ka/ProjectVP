using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamera : MonoBehaviour
{
    public static Shader _replShader;
    public static Camera MapCam;
       


    public void Awake()
    {
        _replShader = Shader.Find("Unlit/Texture");//����� ����� ��������� ������������ �� ����� �������� ������
                                                   //����� �������� � ����������� �������� Unlit/Texture
        MapCam = GetComponent<Camera>();//�������� ��������� ������

        

        if(_replShader)//���� ���� _replShader, �� ����� ��� �������� 
        {
            MapCam.SetReplacementShader(_replShader, "RenderType");//������� �������
        }

                
    }

    private void OnDisable()//������� �����, ����� ��� ���������� ������ ������ ������� �������
    {
        MapCam.ResetReplacementShader();//����� ������� �� ������������ � ���������
    }

      
}
