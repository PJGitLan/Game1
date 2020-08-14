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
        public MovementEngine mover;
        protected AnimationEngine animation;
        private readonly Vector2 origPos;
        public Rectangle CollisionRect { get; set; }
        int colissionOffsetX;
        int colissionOffsetY;
        /// <remarks>
        /// x and y position of the rectangle object needs to be given relatively to the charachters position
        /// </remarks>
        public Character(AnimationEngine animationEngine, MovementEngine mover, Rectangle collisionRectangle )  
        {
            this.CollisionRect = collisionRectangle; /*new Rectangle((int)Position.X, (int)Position.Y, 60, 64);*/
            this.colissionOffsetX = collisionRectangle.X;
            this.colissionOffsetY = collisionRectangle.Y;
            
            this.mover = mover;
            origPos = mover.Position;

            this.animation = animationEngine;
            
        }

        public void ToSpawn()
        {
            mover.Position = origPos;
        }

        public virtual void Update(GameTime gameTime) //an abstract method forces derived classes to implement it whereas virtual method is optional.
        { 
            CollisionRect = new Rectangle((int)Position.X + colissionOffsetX, (int)Position.Y + colissionOffsetY, CollisionRect.Width, CollisionRect.Height);
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
