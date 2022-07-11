using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{

    public class UIDisplayGameWin 
    {
        

        private Text _gameWinLabel;

        public UIDisplayGameWin(Text gameWinText)
        {
            _gameWinLabel = gameWinText;
            _gameWinLabel.text = String.Empty;
        }

        public void GameWin()
        {
            _gameWinLabel.text = $"You win!";
        }

        


    }
}
