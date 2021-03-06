﻿using Game1.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Screen.MenuItems
{
    class EndScreenSetStateBehavior : ISetStateBehavior
    {
        private int Level { get; set; }
        private double Score { get; set; }
        public void SetState(int optionChosen, GameController gameController)
        {
            switch (optionChosen)
            {
                case 1:
                    gameController.ScoreScreen();
                    break;
                case 2:
                    gameController.MainMenu();
                    break;
                default:
                    gameController.MainMenu();
                    break;
            }
        }
    }
}
