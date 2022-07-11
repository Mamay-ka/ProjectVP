using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{

    public class UIDisplayBonus
    {
        private Text _pointsLabel;//нужен компонент Текст

        public UIDisplayBonus(Text pointslabel)//пропишем конструктор и передадим ссылку на Текст
        {
            _pointsLabel = pointslabel;
            _pointsLabel.text = String.Empty;//обращаемся к компоненту текст и добавляем пустую строку
        }

        public void Display(int value)//добавим метод который будет принимать значение и выводить его в тексте
        {
            _pointsLabel.text = $"Bonus: {value}";
        }
    }
}
