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
        Vector2 position;
        Rectangle collisionRectangle;
        public Rectangle CollisionRect { get => collisionRectangle; set => collisionRectangle = value; }

        public Block(Vector2 _position, Texture2D _texture)
        {
            position = _position;
            texture = _texture;
            collisionRectangle = new Rectangle((int) position.X, (int) position.Y, texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            CollisionRect = new Rectangle((int) position.X, (int) position.Y, texture.Width, texture.Height);
        }

        [Obsolete]
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y));
        }
    }
}

