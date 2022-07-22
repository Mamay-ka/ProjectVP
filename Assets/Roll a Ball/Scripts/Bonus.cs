using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public abstract class Bonus : MonoBehaviour, IExecute
    {
        public bool _isInteractable;//переменная, включeн этот бонус или нет.Понадобиться для вкл/выкл бонусов
        protected Color _color;//заведем цвет. Сделаем протэктед, чтобы мы могли его передать
        private Renderer _renderer;//сделаем ссылки на компоненты рендерера и коллайдера
        private Collider _collider;

        public float _heightFly;

        public bool IsInteractable//развернем _isInteractable как свойство, чтобы удобно устанавливать объект активен или нет
        { 
            get => _isInteractable;

            set
            {
                _isInteractable = value;
                //будем еще вкл/выкл компоненты
                BonusRenderer.enabled = value;//объект исчезает и перестает быть доступным для взаимодействия
                _collider.enabled = value;//
            }
        }

        public Renderer BonusRenderer { get => _renderer; set => _renderer = value; }//сделаем Рендерер свойством. Чтобы не конфликтовать с Рендерером

        public virtual void Awake()//пропишем Авэйк для инициализации
        {
            BonusRenderer = GetComponent<Renderer>();//назначим Rendere и Collider
            _collider = GetComponent<Collider>();

            IsInteractable = true;
            _color = Random.ColorHSV();//назначем цвет через Random и укажем метод ColorHVS(),котороый даст нам рандомный цвет
            BonusRenderer.sharedMaterial.color = _color;//возьмем компонент Рендерер и установим ему материал
        }

        private void OnTriggerEnter(Collider other)//для взаимодействия добавим этот метод
        {
            if (IsInteractable || other.CompareTag("Player")) ;//проверим если объект активен или тег Player
            {
                Interaction();//если все так, то вызываем метод Interaction()
                IsInteractable = false;//при взаимодействия игрока и бонусов, бонусы выключаются
            }
        }

        public abstract void Update();//для того, чтобы закрыть интерфейсную ссылку

                                                                                                
        protected abstract void Interaction();//взаимодействие игрока с бонусами
    }
}
