using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{

    
    abstract class Character : ICollidable
    {
        public Vector2 Position { get; private set; }
        Rectangle collisionRectangle;
        /*protected*/ public MovementEngine mover;
        protected AnimationEngine animation;
       

        public Rectangle CollisionRect { get => collisionRectangle; set => collisionRectangle = value; }

        public Character(AnimationEngine animationEngine, MovementEngine mover)
        {
            this.collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 60, 64);
            this.mover = mover;
            this.animation = animationEngine;
        }
        public virtual void Update(GameTime gameTime)
        { 
            CollisionRect = new Rectangle((int)Position.X, (int)Position.Y, 60, 64);
            mover.Update(gameTime, this);
            Position = mover.Position;
            animation.Update(Position, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(animation.Texture, new Vector2((int)Position.X, (int)Position.Y), new Rectangle(animation.FramePostion, 0, 64, 64), Color.White);
        }
    }
}
