using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{

    public class UIDisplayGameOver 
    {
        private Text _gameOverLabel;//����� �����

        public UIDisplayGameOver(Text gameOverText)//�����������. �������� �����
        {
            _gameOverLabel = gameOverText;
            _gameOverLabel.text = String.Empty; //�������� ���������
        }

        public void GameOver(string name, Color color)//������� �����, � ������� ����� ���������� ������ � ����
        {
            _gameOverLabel.text = $"Game Over. Bonus name: {name}, Bonus color: {color}";
        }

        
    }
        
}
