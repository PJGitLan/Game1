using Game1.GameControl;
using Game1.Screen.MenuItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Screen
{
    interface IScreen
    {
        //ISetStateBehavior stateBehavior { get; set; }
        //GameController gameController { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
