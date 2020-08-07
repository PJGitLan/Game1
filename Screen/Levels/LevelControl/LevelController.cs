using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Screen.Levels.LevelControl
{
    abstract class LevelController: IScreen
    {
        abstract public Player Player { get; set; }
        abstract public Finish Finish { get; set; }
        abstract public Level  Level { get; set; }
        abstract public Timer Timer { get; set; }

        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
        protected virtual void lvlReset() { }

    }
}
