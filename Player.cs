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
        Controller controller;

        public Player( AnimationEngine _animation, MovementEngine _mover, Controller _controller) :base( _animation, _mover)
        {
            controller = _controller; 
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            controller.Update();
            
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
        }
    }
}
