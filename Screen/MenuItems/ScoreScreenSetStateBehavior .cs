using Game1.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Screen.MenuItems
{
    class ScoreScreenSetStateBehavior : ISetStateBehavior
    {
        public void SetState(int optionChosen, GameController gameController)
        {
            switch (optionChosen)
            {
                case 1:
                    gameController.Level(); //moet veranderd worden door level nr
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
