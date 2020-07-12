using Game1.Screen;
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

        public IScreen EndScreen(double score, List<IScreen> screens)
        {
            throw new System.InvalidOperationException("Already in end screen");
        }

        public IScreen Level(int levelnr, List<IScreen> screens)
        {
            throw new System.InvalidOperationException("Not allowed to go new level");
        }

        public IScreen MainMenu(List<IScreen> screens)
        {
            Console.WriteLine("set mainmenu as screen");
            gameController.gameState = gameController.mainMenu;
            return screens[screens.Count - 2];
        }
    }
}
