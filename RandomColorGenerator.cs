using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    static class RandomColorGenerator
    {
        static int r;
        static int g;
        static int b;
        
        static private Color color = new Color();
        static private Random rand = new Random();
       

        static public Color Next()
        {
            r = rand.Next(0, 255);    
            g = rand.Next(0, 255);  
            b = rand.Next(0, 255);

            color = new Color(r,g,b);

            //Debug.WriteLine(r);
            //Debug.WriteLine(g);
            //Debug.WriteLine(b);
            //Debug.WriteLine("--------------------------------------------");

            return color;
        }


        public static Color CurrentColor
        {
            get { return color; }
        }
    }
}

    //Random rand = new Random();
    //
    //}
