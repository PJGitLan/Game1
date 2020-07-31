using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public abstract class Controller
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up { get; set; }
        // public bool down { get; set; }
        public bool Select { get; set; }
        public abstract void Update(GameTime gameTime);
    }

    public class TheKeyBoard : Controller
    {
        float elapsed;
        public override void Update(GameTime gameTime)
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Left))
            {
                Left = true;
            }
            if (key.IsKeyUp(Keys.Left))
            {
                Left = false;
            }

            if (key.IsKeyDown(Keys.Right))
            {
                Right = true;
            }
            if (key.IsKeyUp(Keys.Right))
            {
                Right = false;
            }

            if (key.IsKeyDown(Keys.Up))
            {
                Up = true;
            }
            if (key.IsKeyUp(Keys.Up))
            {
                Up = false;
            }

            elapsed += gameTime.ElapsedGameTime.Milliseconds;
            if (key.IsKeyDown(Keys.Enter))
            {
                if (elapsed > 500)
                {
                    elapsed = 0;
                    Select = true;
                }
                else { Select = false; }    
            }

            if (key.IsKeyUp(Keys.Enter))
            {
                Select = false;
            }
        }
    }
    
    public class PS4controller : Controller
    {
        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }

    public class XBOX1Controller : Controller
    {
        float elapsed;
        public override void Update(GameTime gameTime)
        {
            var key = GamePad.GetState(PlayerIndex.One);

            if (key.IsConnected)
            {
                Console.WriteLine("connected");
            }

            if (key.IsButtonDown(Buttons.DPadLeft))
            {
                Left = true;
            }
            if (key.IsButtonUp(Buttons.DPadLeft))
            {
                Left = false;
            }

            if (key.IsButtonDown(Buttons.DPadRight))
            {
                Right = true;
            }
            if (key.IsButtonUp(Buttons.DPadRight))
            {
                Right = false;
            }

            if (key.IsButtonDown(Buttons.DPadUp))
            {
                Up = true;
            }
            if (key.IsButtonUp(Buttons.DPadUp))
            {
                Up = false;
            }

            elapsed += gameTime.ElapsedGameTime.Milliseconds;
            if (key.IsButtonDown(Buttons.A))
            {
                if (elapsed > 500)
                {
                    elapsed = 0;
                    Select = true;
                }
                else { Select = false; }
            }

            if (key.IsButtonUp(Buttons.A))
            {
                Select = false;
            }
        }
    }   
}
