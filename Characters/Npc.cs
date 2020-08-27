using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Characters
{
    class Npc : Character
    {
        private readonly float directionInterval;
        private readonly float jumpInterval;

        /// <remarks>
        /// x and y position of the rectangle object needs to be given relatively to the charachters position
        /// </remarks>
        public Npc(AnimationEngine animation, MovementEngine mover, Rectangle collionRectangle, float directionInterval, float jumpInterval) : base(animation, mover, collionRectangle)
        {
            this.directionInterval = directionInterval;
            this.jumpInterval = jumpInterval;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (gameTime.TotalGameTime.TotalMilliseconds % directionInterval * 2 >= directionInterval)
            {
                Mover.MoveLeft();
            }

            if (gameTime.TotalGameTime.TotalMilliseconds % directionInterval * 2 < directionInterval)
            {
                Mover.MoveRight();
            }

            if (gameTime.TotalGameTime.TotalMilliseconds % jumpInterval * 2 > jumpInterval) 
            {
                Mover.MoveUp();
            }
        }
    }
}
