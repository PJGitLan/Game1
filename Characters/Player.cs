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
        Viewport viewport;
        
        public Player( AnimationEngine animation, MovementEngine mover, Controller controller, Viewport viewport) :base( animation, mover)
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
