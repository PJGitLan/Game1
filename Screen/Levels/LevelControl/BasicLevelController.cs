using Game1.GameControl;
using Game1.Screen.Levels.LevelControl;
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
    class BasicLevelController : LevelController
    {
        override public Player Player { get; set; }
        public override Finish Finish { get ; set ; }
        public override Level Level { get; set; }
        public override Timer Timer { get; set; }

        Camera camera;
        Vector2 origCameraPos;
        private GameController gameController { get; set ; }
        

        public BasicLevelController(Player player, Finish finish, Level level, GameController gameController, Camera camera)
        {
            this.Level = level;
            this.Player = player;
            this.Finish = finish;
            this.gameController = gameController;
            this.camera = camera;
            origCameraPos = camera.Position;
            Timer = new Timer();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Level.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            Finish.Draw(spriteBatch);
            //Console.WriteLine(player.Position);
        }

        public override void Update(GameTime gameTime)
        {
            Level.Update(gameTime);
            Player.Update(gameTime);
            camera.Update(Player.Position);
            Finish.Update();
            Timer.Update(gameTime);
            if (Finish.GoalReached == true)
            {
                Player.Update(gameTime);
                lvlReset();
                Player.Update(gameTime);
            }
        }

        protected override void lvlReset()
        {
            //Console.WriteLine("reset level");
            camera.Position = origCameraPos;
            Player.ToSpawn();
            gameController.Score = Timer.Stop();
            gameController.Endscreen();
        }
    }
}
