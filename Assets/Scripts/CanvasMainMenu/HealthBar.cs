using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] HealthController HealthController;// ������ �� �������������� ������.01
    [SerializeField] Text Text; // ������ �� ����� UI.02
    [SerializeField] Image Image; // ������ �� �������� Image.05

    private float _maxHealth;


    void Start()
    {
        _maxHealth = HealthController.MaxHealthGetter; // �� ���������������.06
        HealthController.HealthChanged += OnHealthChanged;// ������������� �� ������� ���������� �� ������� ��������������.04
        OnHealthChanged(HealthController.CurrentHealth);// �������� �����, ����� ������ ������������������.08
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
        StartScene();
    }

    void OnHealthChanged(float health)
    {
        Image.fillAmount = health / _maxHealth;// ����������� �������� �������� � �������������.��� �����������. 07
        Text.text = health.ToString(); // ������ � ���� �����, �������� �������� � ��������������� � �������� � ������.03
    }

    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;//�����
            
        }
    }

    void StartScene()
    {
        if (Input.GetKeyDown(KeyCode.L))
            {
                Time.timeScale = 1;//������ � �����
            }
    }
}
