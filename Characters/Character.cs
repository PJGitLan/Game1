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
        public MovementEngine Mover { get; private set; }

        protected AnimationEngine animation;
       
        public Rectangle CollisionRect { get; set; }
        private Rectangle collisionOffset;
        
        /// <remarks>
        /// x and y position of the rectangle object needs to be given relatively to the charachters position
        /// </remarks>
        public Character(AnimationEngine animationEngine, MovementEngine mover, Rectangle collisionRectangle )  
        {
            this.CollisionRect = collisionRectangle;
            this.collisionOffset = collisionRectangle;
            
            this.Mover = mover;

            this.animation = animationEngine;
        }

        public virtual void Update(GameTime gameTime) //an abstract method forces derived classes to implement it whereas virtual method is optional.
        { 
            CollisionRect = new Rectangle((int)Mover.Position.X + collisionOffset.X, (int)Mover.Position.Y + collisionOffset.Y, CollisionRect.Width, CollisionRect.Height);
            Mover.Update(gameTime, this);
            animation.Update(Mover.Position, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, Mover.Position);
            
            
            //spriteBatch.Draw(animation.Texture, new Vector2((int)Mover.Position.X, (int)Mover.Position.Y), new Rectangle(animation.FramePostion, 0, 64, 64), Color.White);
            //verhuisd naar animatie klasse
        }
    }
}
