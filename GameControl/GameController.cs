using Game1.GameControl.GameStateFolder;
using Game1.Screen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        public int Lvl { get; set; }
        public double Score { get; set; }

        public readonly string Path = @"C:\speedRunner"; // Mischien beter omdit niet hardcoded te hebben zodat gamecontroller niet altijd naar zelfde locatie moet opslagen
        public readonly string FileName = @"topScores.txt";
       
        public IGameState mainMenu { get; set; }
        public IGameState endscreen { get; set; }
        public IGameState level { get; set; }
        public IGameState scoreScreen { get; set; }

        List<IScreen> screens;
        IScreen screen;
        public IGameState gameState { get; set; }

        public GameController()
        {
            mainMenu = new MainMenuState(this);
            endscreen = new EndScreenState(this);
            level = new LevelState(this);
            scoreScreen = new ScoreScreenState(this);

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

        public void Endscreen()
         {
            screen = gameState.EndScreen(screens);
        }

        public void Level()
        {
            screen = gameState.Level(screens);
        }

        public void MainMenu()
        {
           screen = gameState.MainMenu(screens);
        }

        public void ScoreScreen()
        {
            screen = gameState.ScoreScreen(screens);
        }

        public void Exit()
        {
            if (gameState == mainMenu)
            {
                Game1.self.Exit();
            }

            if (gameState == level)
            {
                MainMenu();
            }
        }
        public void Update(GameTime gameTime)
        {
            //Console.WriteLine(gameState);      
            //Console.WriteLine(gameState);      
            screen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            screen.Draw(spriteBatch);
        }
    }
}
