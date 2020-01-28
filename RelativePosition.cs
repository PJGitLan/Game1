using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    /// <summary>
    ///  based on this tutorial https://www.youtube.com/watch?v=l0WS5SvKdY4
    /// </summary>
    static class RelativePosition
    {
        public static bool TouchTopOf(this ICollidable coll1, ICollidable coll2)
        {
            var rect1 = coll1.CollisionRect;
            var rect2 = coll2.CollisionRect;
            return (rect1.Bottom >= rect2.Top - 1 &&
                    rect1.Bottom <= rect2.Top + (rect2.Height / 2) &&
                    rect1.Right >= rect2.Left + (rect2.Width / 5) &&
                    rect1.Left <= rect2.Right - (rect2.Width / 5));
        }

        public static bool TouchBottomOf(this ICollidable coll1, ICollidable coll2)
        {
            var rect1 = coll1.CollisionRect;
            var rect2 = coll2.CollisionRect;
            return (rect1.Top <= rect2.Bottom + (rect2.Height / 5) &&
                    rect1.Top >= rect2.Bottom - 5 &&
                    rect1.Right >= rect2.Left + (rect2.Width / 5) &&
                    rect1.Left <= rect2.Right - (rect2.Width / 5));
        }

        public static bool TouchRightOf(this ICollidable coll1, ICollidable coll2)
        {
            var rect1 = coll1.CollisionRect;
            var rect2 = coll2.CollisionRect;
            return (rect1.Right <= rect2.Right &&
                    rect1.Right >= rect2.Left - 5 &&
                    rect1.Top <= rect2.Bottom - (rect2.Width / 4) &&
                    rect1.Bottom >= rect2.Top + (rect2.Width / 4));
        }

        public static bool TouchLeftOf(this ICollidable coll1, ICollidable coll2)
        {
            var rect1 = coll1.CollisionRect;
            var rect2 = coll2.CollisionRect;
            return (rect1.Left >= rect2.Left &&
                    rect1.Left <= rect2.Right + 5 &&
                    rect1.Top <= rect2.Bottom - (rect2.Width / 4) &&
                    rect1.Bottom >= rect2.Top + (rect2.Width / 4));
        }
    }
}
