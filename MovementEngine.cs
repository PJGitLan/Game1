using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MovementEngine
    {
       // public Vector2 maxVelocity { get; set; } = new Vector2(0.01f,0.01f);
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        //public Vector2 Acceleration { get; set; } 
       
        float deltaTime;
        public RelativePosition relative { private get; set; }

        public MovementEngine(Vector2 _position, Vector2 _velocity)
        {
            Position = _position;
            Velocity = _velocity;
            //Acceleration = new Vector2(0.001f, 0.001f);
        }

        public void MoveLeft()
        {
            if (relative == null || relative.Horizontal != -1)
            {
                //Velocity = new Vector2(Velocity.X - Acceleration.X * deltaTime, Velocity.Y);
                Position = new Vector2(Position.X - Velocity.X * deltaTime, Position.Y);
            }
        }

        public void MoveRight()
        {
            if (relative == null || relative.Horizontal != 1 )
            {
                //Velocity = new Vector2(Velocity.X + Acceleration.X * deltaTime, Velocity.Y);
                Position = new Vector2(Position.X + Velocity.X * deltaTime, Position.Y);
            }
        }

        public void MoveUp()
        {
            if (relative == null || relative.Vertical != 1)
            {
                //Velocity = new Vector2(Velocity.X, Velocity.Y - Acceleration.Y * deltaTime);
                Position = new Vector2(Position.X, Position.Y - Velocity.Y * deltaTime);
            }
        }

        public void MoveDown()
        {
            if (relative == null || relative.Vertical != -1)
            {
                //Velocity = new Vector2(Velocity.X, Velocity.Y + Acceleration.Y * deltaTime);
                Position = new Vector2(Position.X, Position.Y + Velocity.Y * deltaTime);
            }
        }

        /*public void SpeedControl()
        {
            if(maxVelocity.LengthSquared() <= Velocity.LengthSquared())
            {
                Acceleration = new Vector2(0f, 0f);
            }
             

            else
            {
                Acceleration = new Vector2(0.05f, 0.05f);
            }
        }*/

        public void CollisoinCheck(ICollidable character)
        {
            ICollidable tmp;
            tmp = Collider.CheckCollider(character);
            if (tmp != null) //exception throwen en catchen wss beter
            {
                relative = new RelativePosition(character, tmp);
            }
            else relative = null;
        }

        public void Update(GameTime gameTime, ICollidable character)
        {
            //SpeedControl();
            deltaTime = gameTime.ElapsedGameTime.Milliseconds;
            CollisoinCheck(character);

        }
    }


}
