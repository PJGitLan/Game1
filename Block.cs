using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Block : ICollidable
    {
        Texture2D texture;
        Point position;
        Rectangle collisionRectangle;
        public Rectangle CollisionRect { get => collisionRectangle; set => collisionRectangle = value; }

        public Block(Point _position, Texture2D _texture)
        {
            position = _position;
            texture = _texture;
            collisionRectangle = new Rectangle(position.X, position.Y - 25, 36, 25);
        }

        public void Update(GameTime gameTime)
        {
            CollisionRect = new Rectangle(position.X, position.Y-25, 36, 25);
    }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y));
        }
    }
}

