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
    class Finish
    {
        //public float GameTime { get; set; } = 0;
        public bool GoalReached { get; set; } = false;
        

        Block finish;
        Player player;

        public Finish(Block finish, Player player)
        {
            this.finish = finish;
            this.player = player;
        } 

        public void Update()
        {
            if (player.CollisionRect.Intersects(finish.CollisionRect))
             GoalReached = true;
            else { GoalReached = false; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            finish.Draw(spriteBatch);
        }
    }
}
