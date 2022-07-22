using System;
using UnityEngine;

//����� ����� ������������� ������ ���������
//��������� �������������� �������3, ����������� � �����������

//������, ��� ��������� ����� �������������
[Serializable]

public struct SVect3
{
    public float X;
    public float Y;
    public float Z;

    //������� ����������� ��� ����� ���������
    public SVect3(float x, float y, float z)
    {
        //� ����������� ����� ���������� ��� ��� ���������, ������� ����� ����� ���������������
        X = x;//��������� ������ ����
        Y = y;
        Z = z;

    }

    //������� ����� ��������������. ��� ��� ������ � ��� ������������.
    public static implicit operator SVect3(Vector3 val)//�� ��� ����������� ��� �����������
    {
        return new SVect3(val.x, val.y, val.z);//���������� �����  SVect3. �����������, ��� ����� ����������� ��������������, ������ ���������� ����� �����������
    }

    //�������� �������������� �� ������3 � SVect3
    public static implicit operator Vector3(SVect3 val)//�� ��� ����������� ��� �����������
    {
        return new Vector3(val.X, val.Y, val.Z);//��������� ������� �����, ��� ��� �������� ������ �������� ������� � ������3
    }
        
}

//���� ����� ������� ��� �����������
[Serializable]

public struct SQuater
{
    public float X;
    public float Y;
    public float Z;
    public float W;//��� ����������� ��������� 4-� ��������  

    //������� ����������� ��� ����� ���������
    public SQuater(float x, float y, float z, float w)
    {
        //� ����������� ����� ���������� ��� ��� ���������, ������� ����� ����� ���������������
        X = x;//��������� ������ ����
        Y = y;
        Z = z;
        W = w;//��� ����������� ������� 4-� ��������

    }

    //������� ����� ��������������. ��� ��� ������ � ��� ������������.
    public static implicit operator SQuater(Quaternion val)//�� ��� ����������� ��� �����������
    {
        return new SQuater(val.x, val.y, val.z, val.w);//���������� �����  SQuater. �����������, ��� ����� ����������� ��������������, ������ ���������� ����� �����������
    }

    //�������� �������������� �� Quaternion � SQuater
    public static implicit operator Quaternion(SQuater val)//�� ��� ����������� ��� �����������
    {
        return new Quaternion(val.X, val.Y, val.Z, val.W);//��������� ������� �����, ��� ��� �������� ������ �������� ������� � Quaternion
    }
}
//��� GameObject ������� ���������
[Serializable]
  public struct SObject
  {//������� ��������� ���������� ����������
    public string Name;
    public SVect3 Position;
    public SVect3 Scale;
    public SQuater Rotation;

    public SObject(GameObject go)
    {
        Name = go.name;
        Position = go.transform.position;
        Scale = go.transform.localScale;
        Rotation = go.transform.rotation;
    }
  }