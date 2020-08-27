using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class AnimationEngine //Indien meerder animaties nodig zijn zoals boven, onder, leven kwijt geraken etc... Klasse abstract maken
    {
        private Texture2D Texture { get; set; } //public Texture2D Texture { get; private set; }
        Texture2D textureLeft;
        Texture2D textureRight;
        private int FramePostion { get; set; } //public int FramePostion { get; private set; }
        int frameWidth;
        int framesAmount;
        
        Vector2 prevPosition;
        
        float animationTime;

        public AnimationEngine(Texture2D textureRight, Texture2D textureLeft, int frameWidth, int framesAmount)
        {
            this.textureLeft = textureLeft;
            this.textureRight = textureRight;
            this.Texture = textureLeft;
            this.frameWidth = frameWidth;
            this.framesAmount = framesAmount;
            this.prevPosition = new Vector2(0,0);
        }

        public void MoveLeft()
        {             
            Texture = textureLeft;
            FramePostion -= frameWidth;
            if (FramePostion <= 0)
            {
                FramePostion = (framesAmount-1)*frameWidth;
            }

        }

         public void MoveRight()
         {
             Texture = textureRight;
             FramePostion += frameWidth;
             if (FramePostion >= framesAmount*frameWidth)
             {
                 FramePostion = 0;
             }
         } 

        public void GetMovement(Vector2 position)
        {
            if (position.X < prevPosition.X)
            {
                MoveLeft();
            }
            if (position.X > prevPosition.X)
            {
                MoveRight();
            }

            prevPosition = position;
        }
        
        public void Update(Vector2 position, GameTime gameTime)
        {
            animationTime += gameTime.ElapsedGameTime.Milliseconds;
            if (animationTime > 1000/30)
            {
                GetMovement(position);
                animationTime = 0;
            }   
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(Texture, new Vector2((int)position.X, (int)position.Y), new Rectangle(FramePostion, 0, 64, 64), Color.White);
        }
    }
}
