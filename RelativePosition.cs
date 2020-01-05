using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class RelativePosition
    {
        public int Horizontal { get; set; } = 0;
        public int Vertical { get; set; } = 0;

        public RelativePosition() { }

        public RelativePosition(ICollidable collidable1 ,ICollidable collidable2)//relative positie tegenover collision item
        {
            
            if (collidable1.CollisionRect.X < collidable2.CollisionRect.X && collidable1.CollisionRect.X + collidable1.CollisionRect.Width >= collidable2.CollisionRect.X)
            {
                Horizontal = 1; //collision rechts
            }

            if (collidable1.CollisionRect.X <= collidable2.CollisionRect.X + collidable2.CollisionRect.Width && collidable1.CollisionRect.X + collidable1.CollisionRect.Width > collidable2.CollisionRect.X + collidable2.CollisionRect.Width)
            {
                Horizontal = -1; //collision links
            }

            if (collidable1.CollisionRect.Y > collidable2.CollisionRect.Y && collidable1.CollisionRect.Y - collidable1.CollisionRect.Height <= collidable2.CollisionRect.X)
            {
                Vertical = 1; //collision boven
            }

            if (collidable1.CollisionRect.Y >= collidable2.CollisionRect.Y - collidable2.CollisionRect.Height && collidable1.CollisionRect.Y - collidable1.CollisionRect.Height < collidable2.CollisionRect.Y + collidable2.CollisionRect.Height)
            {
                Vertical = -1; //collision onder
            }
        }
    }
}
