using Game1.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private Vector2 maxVelocity { get; set; } 
        public Vector2 Position { get; set; }
        private readonly Vector2 origPos;

        public Vector2 Velocity { get; set; } 
        private Vector2 Acceleration { get; set; }

        Viewport viewport;

        CollisionHandler collisionHandler;

        public bool IsLanded { get; set; } = false;

        float deltaTime;
        float timeSinceJump;

        public MovementEngine(Vector2 position, Vector2 maxVelocity, Vector2 acceleration, Viewport viewport, CollisionHandler collisionHandler)
        {
            Position = position;
            origPos = Position;
            this.maxVelocity = maxVelocity;
            Acceleration = acceleration;
            this.viewport = viewport;
            this.collisionHandler = collisionHandler;
        }

        public void ToSpawn()
        {
            Position = origPos;
            //Velocity = new Vector2(0, 0);
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
            float duration = 250;
            if (IsLanded || timeSinceJump < duration)
            {
                Velocity = new Vector2(Velocity.X, Velocity.Y - Acceleration.Y * deltaTime);
                IsLanded = false;
                if(timeSinceJump > duration)timeSinceJump = 0;
            }
        }

        public void MoveDown()
        {
                Velocity = new Vector2(Velocity.X, Velocity.Y + Acceleration.Y * deltaTime);   
        }

        private void UpdatePosition(Character character)
        {
            SpeedCheck();

            if (Velocity.X > 0.02)
            {
                Velocity = new Vector2(Velocity.X - Acceleration.X / 4 * deltaTime, Velocity.Y);
            }
            if (Velocity.X < -0.02)
            {
                Velocity = new Vector2(Velocity.X + Acceleration.X / 4 * deltaTime, Velocity.Y);
            }

            if (Velocity.X >= -0.02 && Velocity.X <= 0.02)
            {
                Velocity = new Vector2(0, Velocity.Y);
            }

            Velocity = new Vector2(Velocity.X, Velocity.Y + Acceleration.Y / 6 * deltaTime);

            collisionHandler.CollisionCheck(character); 

            Position = Position + Velocity * deltaTime;

            if (Position.Y > viewport.Bounds.Bottom + 50)
            {
                ToSpawn();
            }
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
         
        public void Update(GameTime gameTime, Character character)
        {
            deltaTime = gameTime.ElapsedGameTime.Milliseconds;
            timeSinceJump += 20;
            UpdatePosition(character);
        }
    }


}
