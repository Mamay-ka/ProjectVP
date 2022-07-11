using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{

    public class UIDisplayGameOver 
    {
        private Text _gameOverLabel;//будет текст

        public UIDisplayGameOver(Text gameOverText)//конструктор. Передаем текст
        {
            _gameOverLabel = gameOverText;
            _gameOverLabel.text = String.Empty; //пропишем обнуление
        }

        public void GameOver(string name, Color color)//заведем метод, в который будем передавать строку и цвет
        {
            _gameOverLabel.text = $"Game Over. Bonus name: {name}, Bonus color: {color}";
        }

        
    }
        
}
