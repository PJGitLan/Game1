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
        public void SetState(int levelChosen, GameController gameController)
        {
            gameController.Level(levelChosen);
        }
    }
}
