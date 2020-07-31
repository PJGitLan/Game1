using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Screen.Levels
{
    class Timer
    {
        float time1;
        float time2;
        bool started = false;
        float elapsed;

        /*public Timer(GameTime gameTime)
        {
            this.gameTime = gameTime;
        }*/

        public void Start()
        {
            time1 = elapsed;
            started = true;
        }

        public float Split()
        {
            time2 = elapsed;

            if ( started == true)
            {
                float result = time2 - time1;
                return result;
            }
            
            throw new System.InvalidOperationException("Timer must be started first");
        }

        public float Stop()
        {
            float result = Split();
            started = false;
            elapsed = 0;
            return result;
        }

        public void Update(GameTime gameTime)
        {
            elapsed += gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
