using Game1.GameControl.GameStateFolder;
using Game1.Screen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameControl
{
    class GameController
    {
        //state pattern


        //levelBuilder factory pattern in level state denk ik
        public IGameState mainMenu { get; set; }
        public IGameState endscreen { get; set; }
        public IGameState level { get; set; }
        List<IScreen> screens;
        IScreen screen;
        public IGameState gameState { get; set; }

        public GameController()
        {
            mainMenu = new MainMenuState(this);
            endscreen = new EndScreenState(this);
            level = new LevelState(this);
            gameState = mainMenu;
        }

        public void addScreens(List<IScreen> screens)
        {
            this.screens = screens;
            screen = screens[screens.Count - 2];
            //zorgen dat de nieuwe schermen bij de vorige schermen worden toegevoegd
        }
        //remove method

        //Doet meer dan 1 ding moet opgesplitst worden

        public void Endscreen(double score)
         {
            screen = gameState.EndScreen(score, screens);
        }

        public void Level(int levelnr)
        {
            screen = gameState.Level(levelnr, screens);
        }

        public void MainMenu()
        {
           screen = gameState.MainMenu(screens);
        }

        public void Update(GameTime gameTime)
        {
            //Console.WriteLine(gameState);
            screen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            screen.Draw(spriteBatch);
        }
    }
}
