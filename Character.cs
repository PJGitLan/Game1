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
        Texture2D texture;
        Texture2D textureLeft;
        Texture2D textureRight;

        public Vector2 Position { get; set; }         

        int frameX = 0;
        int frameWidth = 64; //moet in constructor
        int frameAmount = 8;
        Rectangle collisionRectangle;
        protected MovementEngine mover;
       
        //int health;

        public Rectangle CollisionRect { get => collisionRectangle; set => collisionRectangle = value; }

        public Character(Texture2D _textureRight, Texture2D _textureLeft, MovementEngine _mover)
        {
            textureLeft = _textureLeft;
            textureRight = _textureRight;
            texture = _textureLeft;
            collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 128, 64);
            mover = _mover;
        }



        /*public void MoveLeft()
        {
            if (allowLeft)
            {
                Position = new Vector2(Position.X - Velocity.X * deltaTime, Position.Y);
            }
            
            texture = textureLeft;
            frameX -= frameWidth;
            if (frameX <= 0)
            {
                frameX = (frameAmount-1)*frameWidth;
            }

        }*/

       /*public void MoveRight()
        {
            if (allowRight)
            {
                Position = new Vector2(Position.X + Velocity.X * deltaTime, Position.Y);
            }

            texture = textureRight;
            frameX += frameWidth;
            if (frameX >= frameAmount*frameWidth)
            {
                frameX = 0;
            }
        }*/

        /*public void MoveDown()
        {
            if (allowDown)
            {
                 Position = new Vector2(Position.X, Position.Y + Velocity.Y * deltaTime);
            }
            //frameX = (frameAmount-2) * frameWidth;
        }*/

        /*public void MoveUp()
        {
            if (allowUp)
            {
                Position = new Vector2(Position.X, Position.Y - Velocity.Y * 4* deltaTime);
            }
            //frameX = (frameAmount-2) * frameWidth;
        }*/

        public virtual void Update(GameTime gameTime) //relative uit paramaters halen
        { 
            CollisionRect = new Rectangle((int)Position.X, (int)Position.Y, 128, 64);
            mover.Update(gameTime, this);
            Position = mover.Position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture, new Vector2((int)Position.X, (int)Position.Y), new Rectangle(frameX, 0, 64, 64), Color.White);
        }
    }
}
