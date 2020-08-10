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
        IScreen Level(List<IScreen> screens);
        IScreen EndScreen(List<IScreen> screens);
        IScreen ScoreScreen(List<IScreen> screens);

    }
}
