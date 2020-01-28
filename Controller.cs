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
        public abstract void Update();
    }

    public class TheKeyBoard : Controller
    {
        public override void Update()
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
        }
    }
    
    public class PS4controller : Controller
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }

    public class XBOX1Controller : Controller
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
