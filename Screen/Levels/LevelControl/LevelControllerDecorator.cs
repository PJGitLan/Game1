using Game1.Screen.Levels.LevelControl;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Screen.Levels
{
    abstract class LevelControllerDecorator : LevelController
    {
        LevelController baseController;
        public LevelControllerDecorator(LevelController levelController)
        {
            this.baseController = levelController;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            baseController.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            baseController.Update(gameTime);
        }
    }
}
