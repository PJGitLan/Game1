using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Camera
    {
        private readonly Viewport _viewport;
        public Vector2 Position { get; set; }

        public Camera(Viewport viewport, Vector2 position)
        {
            _viewport = viewport;
            Update(position);
        }

        public Matrix GetViewMatrix()
        {
            Matrix m =
                Matrix.CreateTranslation(new Vector3(-Position, 0));

            return m;
        }

        public void Update(Vector2 position)
        {
            Position = new Vector2(position.X - _viewport.Width/2, _viewport.Y);
        }
    }
}
