using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthController : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100;
    private float _currentHealth;
    public float CurrentHealth => _currentHealth; 

    public Action<float> HealthChanged; //создаем новое событие.01

    public float MaxHealthGetter => MaxHealth;// свойство геттер для получения максимального здоровья(делаем графическое отображение полоски здоровья).03

    private void Awake()
    {
        _currentHealth = MaxHealth;
    }
           
    public void GetDamage (float damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth); // это событие происходит каждый раз, когда мы получаем урон. Т.е. в этом блоке. Здесь мы вызываем все функции, которые 
        if (_currentHealth < 0) //были переданы в это событие.02
        {
            Debug.Log("Game Over");
        }
    }

    public void getHeals(float Heals)
    {
        _currentHealth += Heals;
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth > 100)
        {
            _currentHealth = 100;
        }

    }
      

}
