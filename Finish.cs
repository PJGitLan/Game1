﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Finish
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public Rectangle Rectangle { get; set; }

        public Finish(Vector2 position, Texture2D texture)
        {
            Position = position;
            Texture = texture;
            Rectangle = new Rectangle((int) Position.X, (int) Position.Y, 128, 128);
        }
    }
}
