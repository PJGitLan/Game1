using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class GameLogic
    {
        public float GameTime { get; set; } = 0;
        public bool GoalReached { get; set; } = false;
        

        Finish finish;
        Player player;

        public GameLogic(Finish finish, Player player)
        {
            this.finish = finish;
            this.player = player;
        } 

        public void Update()
        {
            if (player.CollisionRect.Intersects(finish.Rectangle))
            {
                //Debug.WriteLine("finish");
                GoalReached = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(finish.Texture, finish.Position, new Rectangle(0,0,128,128), Color.White);
        }
    }
}
