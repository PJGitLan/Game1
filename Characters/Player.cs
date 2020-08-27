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

        /// <remarks>
        /// x and y position of the rectangle object needs to be given relatively to the charachters position
        /// </remarks>
        public Player( AnimationEngine animation, MovementEngine mover, Controller controller, Rectangle collisionRectangle) :base( animation, mover, collisionRectangle)
        {
            this.controller = controller;
        }

        public override void Update(GameTime gameTime) //1 klasse die link tussen controller en klasse doet
        {
            base.Update(gameTime);
            controller.Update(gameTime);
            
            if (controller.Left)
            {
                Mover.MoveLeft();
            }

            if (controller.Right)
            {
               Mover.MoveRight();
            }

            if (controller.Up)
            {
                 Mover.MoveUp();
            }
        }
    }
}
