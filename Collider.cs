using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    static class Collider // Should it be a static or regular function?
    {
        static List<ICollidable> collidables = new List<ICollidable>();

        static public void addCollider(ICollidable colidableObject)
        {
            collidables.Add(colidableObject);
        }

        static public ICollidable CheckCollider(ICollidable source)
        {
            foreach (var collidable in collidables)
            {
                if (source.CollisionRect.Intersects(collidable.CollisionRect))
                {
                    //Debug.WriteLine("intersection");
                    return collidable;
                }
            }
            Debug.WriteLine("no intersection!");
            return null;
        }
    }
}
