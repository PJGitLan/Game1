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
        //private Character character;
        private CollidablesHandler colliders;

        public CollisionHandler(CollidablesHandler colliders)
        {
           // this.character = character;
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
                        //Position = new Vector2(Position.X, collidable.CollisionRect.Top - character.CollisionRect.Height);
                        ch.Velocity = new Vector2(ch.Velocity.X, 0);
                        ch.IsLanded = true;
                        //hasJumped = false;
                    }
                }

                if (character.TouchBottomOf(collidable))//On top
                {
                    if (ch.Velocity.Y < 0)
                    {
                        ch.Position = new Vector2(ch.Position.X, collidable.CollisionRect.Bottom - 1);
                        ch.Velocity = new Vector2(ch.Velocity.X, 0f);
                        //Debug.WriteLine("touching bottom");
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
