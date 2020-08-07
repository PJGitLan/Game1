using Game1.Screen;
using Game1.Screen.Levels;
using Game1.Screen.Levels.LevelControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameControl.GameStateFolder
{
    class MainMenuState : IGameState
    {
        GameController gameController;

        public MainMenuState(GameController gameController)
        {
            this.gameController = gameController;
        }

        public IScreen EndScreen(double score, List<IScreen> screens)
        {
            throw new System.InvalidOperationException("can't go from main menu to endscreen");

        }

        public IScreen Level(int levelnr, List<IScreen> screens)
        {
            //Console.WriteLine("load level builder");
            gameController.gameState = gameController.level;
            //Collider.ClearColliders();
            if (screens[levelnr - 1] is LevelController)
            {
                LevelController temp = (LevelController)screens[levelnr - 1];
                temp.Timer.Start();
                Console.WriteLine("Timer started");

                screens[levelnr - 1] = temp;
            }
            return screens[levelnr - 1];
        }

        public IScreen MainMenu(List<IScreen> screens)
        {
            throw new System.InvalidOperationException("Already in Main menu");
        }
    }
}