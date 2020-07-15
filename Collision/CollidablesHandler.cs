using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class CollidablesHandler // Should it be a static or regular function?
    {
        List<ICollidable> collidables = new List<ICollidable>();

        public void addCollider(ICollidable colidableObject)
        {
            collidables.Add(colidableObject);
        }

        public void ClearColliders()
        {
            collidables.Clear();
        }

        public List<ICollidable> CheckCollider(ICollidable source)
        {
            List<ICollidable> collisions = new List<ICollidable>();
            foreach (var collidable in collidables)
            {
                if (source.CollisionRect.Intersects(collidable.CollisionRect))
                {
                    //Debug.WriteLine("intersection");
                    collisions.Add(collidable);
                }
            }
            return collisions;
        }
    }
}
