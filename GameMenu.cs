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
        private SpriteFont font;
        public GameMenu(SpriteFont _font)
        {
            font = _font;
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Debug.WriteLine("Fuuuuuk");
            spriteBatch.DrawString(font, "Test djebfkebfkhbefhbefjbfjh", new Vector2(90, 600), Color.Black);
        }
    }
}
