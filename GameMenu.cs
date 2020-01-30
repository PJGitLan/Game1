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
    class GameMenu
    { 
        String titel;
        String message; 
        List<String> levelOptions = new List<String>();
        int levelSelected;
        public int LevelChosen { get; private set; } = 0;
        
        private SpriteFont titelFont;
        private SpriteFont regularFont;
        private SpriteFont selectedFont;

        Controller controller;
        float elapsed;

        public GameMenu(List<SpriteFont> _fonts, Controller _controller, String titel, String message, List<String> levelOptions)//lijst van fonts maken
        {
            titelFont = _fonts[0];
            selectedFont = _fonts[1];
            regularFont = _fonts[2];
            controller = _controller;

            this.titel = titel;
            this.message = message;
            this.levelOptions = levelOptions;
        }

        public void Update(GameTime gameTime)
        {
            
            elapsed += gameTime.ElapsedGameTime.Milliseconds;
            controller.Update();
            if (elapsed > 100 )
            {
                if (controller.Right)
                {
                    levelSelected++;
                    if (levelSelected >= levelOptions.Count)
                    {
                        levelSelected = 0;
                    }
                }

                if (controller.Left)
                {
                    levelSelected--;
                    if (levelSelected < 0)
                    {
                        levelSelected = levelOptions.Count - 1;
                    }
                }
                elapsed = 0;
            }

            if (controller.Up)
            {
                LevelChosen = levelSelected+1;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Viewport viewport)
        {
            Vector2 size = titelFont.MeasureString(titel);
            
            spriteBatch.DrawString(titelFont , titel, new Vector2(viewport.Width / 2 - size.X/2, viewport.Height / 4 - size.Y / 2), Color.White);
            spriteBatch.DrawString(regularFont, message, new Vector2(viewport.Width / 2 - size.X / 2, viewport.Height * 0.5f - size.Y / 2), Color.White);

            int i = 0;
            foreach (var option in levelOptions)
            {
                float dividend = 1 + 2 * i;
                float divisor = levelOptions.Count * 2;
                float quotient = dividend / divisor; //gebruik van apart var omdat formule niet klopte bij het gebruik van mathematische haakjes
                
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
