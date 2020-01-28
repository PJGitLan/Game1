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
        public Vector2 maxVelocity { get; set; }
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }
        public Vector2 Acceleration { get; set; }

        float deltaTime;

        public MovementEngine(Vector2 _position, Vector2 _maxVelocity, Vector2 _acceleration)
        {
            Position = _position;
            maxVelocity = _maxVelocity;
            Acceleration = _acceleration;
        }

        public void MoveLeft()
        {
            Velocity = new Vector2(Velocity.X - Acceleration.X * deltaTime, Velocity.Y);
        }

        public void MoveRight()
        {
            Velocity = new Vector2(Velocity.X + Acceleration.X * deltaTime, Velocity.Y);
        }

        public void MoveUp()
        {
            Velocity = new Vector2(Velocity.X, Velocity.Y - Acceleration.Y * deltaTime);
        }

        public void MoveDown()
        {
            Velocity = new Vector2(Velocity.X, Velocity.Y + Acceleration.Y * deltaTime);
        }

        public void UpdatePosition(ICollidable character)
        {
            SpeedCheck();

            if (Velocity.X > 0.01)
            {
                Velocity = new Vector2(Velocity.X - Acceleration.X / 4 * deltaTime, Velocity.Y);
            }
            if (Velocity.X < -0.01)
            {
                Velocity = new Vector2(Velocity.X + Acceleration.X / 4 * deltaTime, Velocity.Y);
            }

            if (Velocity.X >= -0.01 && Velocity.X <= 0.01)
            {
                Velocity = new Vector2(0, Velocity.Y);
            }

            Velocity = new Vector2(Velocity.X, Velocity.Y + Acceleration.Y / 6 * deltaTime);

            CollisoinCheck(character);

            Position = Position + Velocity * deltaTime;
        }

        private void SpeedCheck()
        {
            if (Velocity.X > maxVelocity.X)
            {
                Velocity = new Vector2(maxVelocity.X, Velocity.Y);
            }

            if (-Velocity.X > maxVelocity.X)
            {
                Velocity = new Vector2(-maxVelocity.X, Velocity.Y);
            }

            if (Velocity.Y > maxVelocity.Y)
            {
                Velocity = new Vector2(Velocity.X, maxVelocity.Y);
            }

            if (-Velocity.Y > maxVelocity.X)
            {
                Velocity = new Vector2(Velocity.X, -maxVelocity.Y);
            }
        }

        private void CollisoinCheck(ICollidable character)
        {
            List<ICollidable> tmp;
            tmp = Collider.CheckCollider(character);

            foreach (var collidable in tmp)
            {
                if (character.TouchLeftOf(collidable))//links
                {
                    if (Velocity.X < 0)
                    {
                        Velocity = new Vector2(0, Velocity.Y);
                    }
                }

                if (character.TouchRightOf(collidable))//rechts
                {
                    if (Velocity.X > 0)
                    {
                        Velocity = new Vector2(0, Velocity.Y);
                    }
                }

                if (character.TouchTopOf(collidable)) //onder
                {
                    if (Velocity.Y > 0)
                    {
                        //Position = new Vector2(Position.X, collidable.CollisionRect.Top - character.CollisionRect.Height);
                        Velocity = new Vector2(Velocity.X, 0);
                        //hasJumped = false;
                    }
                }

                if (character.TouchBottomOf(collidable))//boven
                {
                    if (Velocity.Y <  0)
                    {
                        Position = new Vector2(Position.X, collidable.CollisionRect.Bottom - 1);
                        Velocity = new Vector2(Velocity.X, 0f);
                        Debug.WriteLine("touching bottom");
                    }
                }
            }


        }
         
        public void Update(GameTime gameTime, ICollidable character)
        {
            deltaTime = gameTime.ElapsedGameTime.Milliseconds;
            UpdatePosition(character);
          
        }
    }


}
