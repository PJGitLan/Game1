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
        List<Texture2D> blockTextures;

        public Level(List<Texture2D> _blockTextures)
        {
            blockTextures = _blockTextures;
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
                    int i = 0;
                    foreach (var blockTexture in blockTextures)
                    {
                        if (ByteArray[rij, kolom] == i+1)
                        {
                            blockArray[rij, kolom] = new Block(new Vector2(kolom * blockTexture.Width, rij * blockTexture.Height), blockTexture); ;
                            Collider.addCollider(blockArray[rij, kolom]);
                        }
                        i++;
                    }
                }
            }
        }

        [Obsolete]
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
