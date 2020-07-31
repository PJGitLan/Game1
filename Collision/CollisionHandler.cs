using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Collision
{
    class CollisionHandler
    {
        private CollidablesHandler colliders;

        public CollisionHandler(CollidablesHandler colliders)
        {
            this.colliders = colliders;
        }

        public void CollisionCheck(Character character)
        {
            var ch = character.mover;
            List<ICollidable> tmp;
            tmp = colliders.CheckCollider(character);

            foreach (var collidable in tmp)
            {
                if (character.TouchLeftOf(collidable))//Left
                {
                    if (ch.Velocity.X < 0)
                    {
                        ch.Velocity = new Vector2(0, ch.Velocity.Y);
                    }
                }

                if (character.TouchRightOf(collidable))//Right
                {
                    if (ch.Velocity.X > 0)
                    {
                        ch.Velocity = new Vector2(0, ch.Velocity.Y);
                    }
                }

                if (character.TouchTopOf(collidable)) //Below
                {
                    if (ch.Velocity.Y > 0)
                    {
                        ch.Velocity = new Vector2(ch.Velocity.X, 0);
                        ch.IsLanded = true;
                    }
                }

                if (character.TouchBottomOf(collidable))//On top
                {
                    if (ch.Velocity.Y < 0)
                    {
                        ch.Position = new Vector2(ch.Position.X, collidable.CollisionRect.Bottom - 1);
                        ch.Velocity = new Vector2(ch.Velocity.X, 0f);
                    }
                }
            }

        }

        /*public void Update(Character character)
        {
            CollisionCheck(character);
        }*/

    }
}
