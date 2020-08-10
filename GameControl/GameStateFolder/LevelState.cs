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

        public IScreen EndScreen(List<IScreen> screens)
        {
            gameController.gameState = gameController.endscreen;
            double score = gameController.Score;

            ScoreSaver scoreSaver = new ScoreSaver(gameController.Path, gameController.FileName);
            scoreSaver.SaveTopScore(gameController.Lvl - 1, gameController.Score);
            
            if (screens[screens.Count - 1] is GameMenu)
            {
                GameMenu temp = (GameMenu)screens[screens.Count - 1];
                temp.message = $"Completed in {score/1000}s";
                screens[screens.Count - 1] = temp;
                gameController.Score = score;
            }
            return screens[screens.Count - 1];
        }

        public IScreen Level(List<IScreen> screens)
        {
            throw new System.InvalidOperationException("Already in a level");

        }

        public IScreen MainMenu(List<IScreen> screens)
        {
            Console.WriteLine("exiting level without completion");
            gameController.gameState = gameController.mainMenu;
            return screens[screens.Count - 2];
        }

        public IScreen ScoreScreen(List<IScreen> screens)
        {
            throw new NotImplementedException();
        }
    }
}
