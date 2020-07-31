using Game1.GameControl;
using Game1.Screen.MenuItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Screen.Levels
{
    class LevelController: IScreen
    {
        Player player;
        Vector2 origPlayerPos;
        Finish finish;
        Level level;
        Camera camera;
        Vector2 origCameraPos;
        public Timer Timer { get; private set; }
        private GameController gameController { get; set ; }

        public LevelController(Player player, Finish finish, Level level, GameController gameController, Camera camera)
        {
            this.level = level;
            this.player = player;
            origPlayerPos = player.mover.Position;
            this.finish = finish;
            this.gameController = gameController;
            this.camera = camera;
            origCameraPos = camera.Position;
            Timer = new Timer();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
            player.Draw(spriteBatch);
            finish.Draw(spriteBatch);
            //Console.WriteLine(player.Position);
        }

        public void Update(GameTime gameTime)
        {
            level.Update(gameTime);
            player.Update(gameTime);
            camera.Update(player.Position);
            finish.Update();
            Timer.Update(gameTime);
            if (finish.GoalReached == true)
            {
                //Console.WriteLine("reset level");
                player.mover.Position = origPlayerPos;
                player.Update(gameTime);
                camera.Position = origCameraPos;
                //Console.WriteLine(player.Position);
      
                gameController.Endscreen(Timer.Stop());
            }
        }
    }
}
