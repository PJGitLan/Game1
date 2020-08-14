using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Player : Character
    {
        public Controller controller { get; private set; }
        Viewport viewport;

        /// <remarks>
        /// x and y position of the rectangle object needs to be given relatively to the charachters position
        /// </remarks>
        public Player( AnimationEngine animation, MovementEngine mover, Controller controller, Rectangle collisionRectangle, Viewport viewport) :base( animation, mover, collisionRectangle)
        {
            this.controller = controller;
            this.viewport = viewport;
        }

        public override void Update(GameTime gameTime) //1 klasse die link tussen controller en klasse doet
        {
            base.Update(gameTime);
            controller.Update(gameTime);
            
            if (controller.Left)
            {
                mover.MoveLeft();
            }

            if (controller.Right)
            {
               mover.MoveRight();
            }

            if (controller.Up)
            {
                 mover.MoveUp();
            }

            if(Position.Y > viewport.Bounds.Bottom + 50)
            {
                ToSpawn();
            }
        }
    }
}
