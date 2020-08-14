using Game1.Screen;
using Game1.Screen.MenuItems;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameControl.GameStateFolder
{
    class EndScreenState : IGameState
    {
        GameController gameController;

        public EndScreenState(GameController gameController)
        {
            this.gameController = gameController;
        }

        public IScreen EndScreen(List<IScreen> screens)
        {
            throw new System.InvalidOperationException("Already in end screen");
        }

        public IScreen Level(List<IScreen> screens)
        {
            throw new System.InvalidOperationException("Not allowed to go new level");
        }

        public IScreen MainMenu(List<IScreen> screens)
        {
            gameController.gameState = gameController.mainMenu;
            return screens[screens.Count - 2];
        }

        public IScreen ScoreScreen(List<IScreen> screens)
        {
            gameController.gameState = gameController.scoreScreen;            

            ScoreReader scoreReader = new ScoreReader(gameController.Path, gameController.FileName);
            List<double> topScores = scoreReader.GetScore(gameController.Lvl-1);

            if (screens[screens.Count - 3] is GameMenu)
            {
                GameMenu temp = (GameMenu)screens[screens.Count - 3];                        
                List<string> fillers = new List<string>();
                
                foreach (var item in topScores)
                {
                    fillers.Add($"{item/1000}");
                }

                while(fillers.Count < 3)
                {
                    fillers.Add("--");
                }

                temp.message = $"#1: {fillers[0]}   #2: {fillers[1]}   #3: {fillers[2]}";
                screens[screens.Count - 3] = temp;
            }
            return screens[screens.Count - 3];
        }        
    }
}
