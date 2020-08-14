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
        Viewport viewport;
        private readonly float directionInterval;
        private readonly float jumpInterval;

        /// <remarks>
        /// x and y position of the rectangle object needs to be given relatively to the charachters position
        /// </remarks>
        public Npc(AnimationEngine animation, MovementEngine mover, Rectangle collionRectangle, Viewport viewport, float directionInterval, float jumpInterval) : base(animation, mover, collionRectangle)
        {
            this.viewport = viewport;
            this.directionInterval = directionInterval;
            this.jumpInterval = jumpInterval;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (gameTime.TotalGameTime.TotalMilliseconds % directionInterval * 2 >= directionInterval)
            {
                mover.MoveLeft();
            }

            if (gameTime.TotalGameTime.TotalMilliseconds % directionInterval * 2 < directionInterval)
            {
                mover.MoveRight();
            }

            if (gameTime.TotalGameTime.TotalMilliseconds % jumpInterval == 0) //Should not work yet
            {
                mover.MoveUp();
            }

            if (Position.Y > viewport.Bounds.Bottom + 50)
            {
                ToSpawn();
            }
        }
    }
}
