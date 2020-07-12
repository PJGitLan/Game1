using Game1.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameControl
{
    interface IGameState
    {
        IScreen MainMenu(List<IScreen> screens);
        IScreen Level(int levelnr, List<IScreen> screens);
        IScreen EndScreen(double score, List<IScreen> screens);

    }
}
