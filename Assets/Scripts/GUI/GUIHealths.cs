using System.Collections;
using UnityEngine;
using UnityEditor;

public class GUIHealths : MonoBehaviour
{
    public HealthController _healthController = null;//ссылка на скрипт, который висит на объекте и с которым я собираюсь работать.
    public GameObject Cil = null;//ссылка на объект, на котором висит скрипт.
    private string Text = "150";// переменная, которая будет выводит уровень здоровья.
    private float _healthBar = 0.0f;



    void OnGUI()
    {
        _healthController = Cil.GetComponent<HealthController>();//получение доступа к скрипту HealsController на объекте Cil.
        Text = _healthController.CurrentHealth.ToString();//получение доступа к переменной CurrentHealth и приведение ее к строковому типу. 
        _healthBar = _healthController.CurrentHealth;
        GUI.Box(new Rect(Screen.width/2 - 100, 0, (_healthBar * 2), 25), Text);//создание окна в нужном месте заданного размера и вывод информации внутри. 
       
    }
}
