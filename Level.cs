using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public abstract class Level
    {
        protected byte[,] ByteArray;
        Block[,] blockArray;
        Texture2D blockTexture;

        public Level(Texture2D _blockTexture)
        {
            blockTexture = _blockTexture;
            LoadByteList();
            blockArray = new Block[ByteArray.GetLength(0), ByteArray.GetLength(1)];
            LoadBlocks();
        }

        protected abstract void LoadByteList(); 
        
        private void LoadBlocks()
        {
            for (int rij = 0; rij < ByteArray.GetLength(0); rij++)
            {
                for (int kolom = 0; kolom < ByteArray.GetLength(1); kolom++)
                {
                    if (ByteArray[rij, kolom] == 1)
                    {
                        blockArray[rij, kolom] = new Block(new Point(kolom * 36, rij * 50), blockTexture);
                        Collider.addCollider(blockArray[rij, kolom]);
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < ByteArray.GetLength(0); x++)
            {
                for (int y = 0; y < ByteArray.GetLength(1); y++)
                {
                    if (blockArray[x, y] != null)
                    {
                        blockArray[x, y].Draw(spriteBatch);
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int x = 0; x < ByteArray.GetLength(0); x++)
            {
                for (int y = 0; y < ByteArray.GetLength(1); y++)
                {
                    if (blockArray[x, y] != null)
                    {
                        blockArray[x, y].Update(gameTime);
                    } 
                }
            }
        }
    }
}
