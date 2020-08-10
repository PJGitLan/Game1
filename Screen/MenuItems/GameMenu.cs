using Game1.GameControl;
using Game1.Screen;
using Game1.Screen.MenuItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class GameMenu : IScreen
    { 
        String titel;
        public String message { private get; set; } 
        List<String> levelOptions = new List<String>();
        int levelSelected;
        public int LevelChosen { get; private set; } = 0;
        
        private SpriteFont titelFont;
        private SpriteFont regularFont;
        private SpriteFont selectedFont;

        Controller controller;
        Viewport viewport;

        private ISetStateBehavior StateBehavior { get; set; }
        private GameController gameController { get; set; }
     

        //Split up in level selector and screen builder???
        public GameMenu(List<SpriteFont> _fonts, Controller _controller, String titel, String message, List<String> levelOptions, Viewport viewport, GameController gameController, ISetStateBehavior stateBehavior)//lijst van fonts maken
        {
            titelFont = _fonts[0];
            selectedFont = _fonts[1];
            regularFont = _fonts[2];
            controller = _controller;
            this.StateBehavior = stateBehavior;
            this.gameController = gameController;

            this.titel = titel;
            this.message = message;
            this.levelOptions = levelOptions;
            this.viewport = viewport;
        }

        public void Update(GameTime gameTime)
        {
            controller.Update(gameTime);
                if (controller.Right)
                {
                    if (levelSelected < levelOptions.Count-1)
                    {
                        levelSelected++;
                    }
                    
                    else
                    {
                        levelSelected = levelOptions.Count-1;
                    }
                }

                if (controller.Left)
                {
                    if (levelSelected > 0)
                    {
                        levelSelected--;
                    }
                    
                    else
                    {
                        levelSelected = 0;
                    }
                }

            if (controller.Select)
            {
                LevelChosen = levelSelected+1;
                StateBehavior.SetState(LevelChosen, gameController);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 size = titelFont.MeasureString(titel);
            
            spriteBatch.DrawString(titelFont , titel, new Vector2(viewport.Width / 2 - size.X/2, viewport.Height / 4 - size.Y / 2), Color.White);
            spriteBatch.DrawString(regularFont, message, new Vector2(viewport.Width / 2 - size.X / 2, viewport.Height * 0.5f - size.Y / 2), Color.White);

            int i = 0;
            foreach (var option in levelOptions)
            {
                float dividend = 1 + 2 * i;
                float divisor = levelOptions.Count * 2;
                float quotient = dividend / divisor;
                
                size = regularFont.MeasureString(option);

                if (i == levelSelected) 
                {
                    spriteBatch.DrawString(selectedFont, option,
                    new Vector2(viewport.Width * quotient - size.X / 2, viewport.Height * 0.75f - size.Y / 2),
                    Color.White);
                }
                else
                {
                    spriteBatch.DrawString(regularFont, option,
                    new Vector2(viewport.Width * quotient - size.X / 2, viewport.Height * 0.75f - size.Y / 2),
                    Color.White);
                }
                
                i++;
            }
        }
    }
}
