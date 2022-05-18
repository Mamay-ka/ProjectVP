using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] HealthController HealthController;// ссылка на ’елс онтроллер игрока.01
    [SerializeField] Text Text; // ссылка на текст UI.02
    [SerializeField] Image Image; // ссылка на компонет Image.05

    private float _maxHealth;


    void Start()
    {
        _maxHealth = HealthController.MaxHealthGetter; // из ’елс онтроллера.06
        HealthController.HealthChanged += OnHealthChanged;// подписываемс€ на событие ’элс„энжед из скрипта ’элс онтроллер.04
        OnHealthChanged(HealthController.CurrentHealth);// вызываем метод, чтобы данные инициализировались.08
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
        StartScene();
    }

    void OnHealthChanged(float health)
    {
        Image.fillAmount = health / _maxHealth;// соотношение текущего здоровь€ к максимальному.ƒл€ отображени€. 07
        Text.text = health.ToString(); // доступ к полю текст, значение которого в ’елс онтроллере и привести к строке.03
    }

    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;//пауза
            
        }
    }

    void StartScene()
    {
        if (Input.GetKeyDown(KeyCode.L))
            {
                Time.timeScale = 1;//сн€тие с паузы
            }
    }
}
