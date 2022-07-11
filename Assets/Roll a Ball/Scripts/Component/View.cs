using System;
using System.Collections.Generic;
using UnityEngine;

//этот класс будет содержать ссылки и распознавать столкновения. это универсальный шаблон

namespace TestMVC
{
    public class View : MonoBehaviour
    {
        [SerializeField] private Transform _transform;//в первую очередь ссылка на Трансформ.Чтобы все время не использовать ГетКомпонент, будем вызывать трансформ отсюда
        [SerializeField] private Collider _collider;//ссылка на Коллайдер
        [SerializeField] private Rigidbody _rb;

        //также этот класс будет содержать события
        public Action<Collider, int, Transform> OnLevelObjectContact { get; set; }//событие будет передовать Коллайдер, какое-нибудь число и какой-нибудь трансформ
        public Transform Transform { get => _transform; set => _transform = value; }//не понимаю.Инкапсулировали для какой-то безопасности
        public Collider Collider { get => _collider; set => _collider = value; }//не понимаю
        public Rigidbody Rb { get => _rb; set => _rb = value; }//не понимаю

        //это событие, когда мы с чем-нибудь столкнулись на сцене

        private void OnTriggerEnter(Collider other)//вход в триггер. Это типа сенсор, который будет отвечать за столкновения
        {
            Debug.Log(other.name);//при коллизии будем выводить имя нашего объекта с которым мы столкнулись

            Collider LevelObject = other;//затем создадим временную ссылку на Коллайдер и присвоим озер

            OnLevelObjectContact?.Invoke(LevelObject, 13, _transform);//дальше вызовем это событие и передадим в него, то что мы запланировали
        }
    }
}
