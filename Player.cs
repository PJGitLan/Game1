using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Player : Character
    {
        float runSpeedTime;
        Controller controller;

        public Player( Texture2D _textureRight, Texture2D _textureLeft, MovementEngine _mover, Controller _controller) :base( _textureRight, _textureLeft, _mover)
        {
            controller = _controller;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            controller.Update();
            runSpeedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (runSpeedTime > 1000 / 30)
            {

                if (controller.Left)
                {
                    mover.MoveLeft();
                }

                if (controller.Right)
                {
                    mover.MoveRight();
                }

                if (controller.Up)
                {
                    mover.MoveUp();
                }
                runSpeedTime = 0;
            }
        }
    }
}
