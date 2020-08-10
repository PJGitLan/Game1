using Game1.Screen;
using Game1.Screen.Levels.LevelControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameControl.GameStateFolder
{
    class ScoreScreenState : IGameState
    {
        GameController gameController;

        public ScoreScreenState(GameController gameController)
        {
            this.gameController = gameController;
        }

        public IScreen EndScreen(List<IScreen> screens)
        {
            throw new System.InvalidOperationException("Already in scoreboard screen");
        }

        public IScreen Level(List<IScreen> screens)
        {
            gameController.gameState = gameController.level;
            int levelnr = gameController.Lvl;
            if (screens[levelnr - 1] is LevelController)
            {
                LevelController temp = (LevelController)screens[levelnr - 1];
                temp.Timer.Start();
                screens[levelnr - 1] = temp;
            }
            return screens[levelnr - 1];
        }

        public IScreen MainMenu(List<IScreen> screens)
        {
            gameController.gameState = gameController.mainMenu;
            return screens[screens.Count - 2];
        }

        public IScreen ScoreScreen(List<IScreen> screens)
        {
            throw new System.InvalidOperationException("Already in score screen");
        }
    }
}
