using Game1.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Screen.MenuItems
{
    class MainMenuSetStateBehavior : ISetStateBehavior
    {
        public void SetState(int optionChosen, GameController gameController)
        {
            gameController.Lvl = optionChosen;
            gameController.Level();
        }
    }
}
