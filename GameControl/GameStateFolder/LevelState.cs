using Game1.Screen;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameControl.GameStateFolder
{
    class LevelState : IGameState
    {
        GameController gameController;

        public LevelState(GameController gameController)
        {
            this.gameController = gameController;
        }

        public IScreen EndScreen(double score, List<IScreen> screens)
        {
            Console.WriteLine("level finished show results");
            gameController.gameState = gameController.endscreen;
            if(screens[screens.Count - 1] is GameMenu)
            {
                GameMenu temp = (GameMenu)screens[screens.Count - 1];
                temp.message = $"Completed in {score/1000}s";
                screens[screens.Count - 1] = temp;
            }
            return screens[screens.Count - 1];
        }

        public IScreen Level(int levelnr, List<IScreen> screens)
        {
            throw new System.InvalidOperationException("Already in a level");

        }

        public IScreen MainMenu(List<IScreen> screens)
        {
            Console.WriteLine("exiting level without completion");
            gameController.gameState = gameController.mainMenu;
            return screens[screens.Count - 2];
        }
    }
}
