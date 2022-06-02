using System.Collections;
using UnityEngine;
using UnityEditor;

public class GUIHealths : MonoBehaviour
{
    public HealthController _healthController = null;//������ �� ������, ������� ����� �� ������� � � ������� � ��������� ��������.
    public GameObject Cil = null;//������ �� ������, �� ������� ����� ������.
    private string Text = "150";// ����������, ������� ����� ������� ������� ��������.
    private float _healthBar = 0.0f;



    void OnGUI()
    {
        _healthController = Cil.GetComponent<HealthController>();//��������� ������� � ������� HealsController �� ������� Cil.
        Text = _healthController.CurrentHealth.ToString();//��������� ������� � ���������� CurrentHealth � ���������� �� � ���������� ����. 
        _healthBar = _healthController.CurrentHealth;
        GUI.Box(new Rect(Screen.width/2 - 100, 0, (_healthBar * 2), 25), Text);//�������� ���� � ������ ����� ��������� ������� � ����� ���������� ������. 
       
    }
}
