using Game1.Characters;
using Game1.Screen.Levels.LevelControl;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Screen.Levels
{
    class EnemiesDecorator : LevelControllerDecorator
    {
        private readonly LevelController levelController;
        private readonly List<Npc> npcs;
        CollidablesHandler collidablesHandler;
        public override Player Player { get; set; }
        public override Finish Finish { get; set; }
        public override Level Level { get; set; }
        public override Timer Timer { get; set; }

        public EnemiesDecorator(LevelController levelController, List<Npc> npcs) : base(levelController)
        {
            this.levelController = levelController;
            Player = levelController.Player;
            Finish = levelController.Finish;
            Level = levelController.Level;
            Timer = levelController.Timer;
            this.npcs = npcs;
            collidablesHandler = new CollidablesHandler();
            foreach (var item in npcs)
            {
                collidablesHandler.addCollider(item);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (var item in npcs)
            {
                item.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (var item in npcs)
            {
                item.Update(gameTime);
            }
            if (collidablesHandler.CheckCollider(levelController.Player).Count > 0)
            {
                Player.ToSpawn();
            }
        }

        protected override void lvlReset()
        {
            foreach (var item in npcs)
            {
                item.ToSpawn();
            }
            base.lvlReset();
        }
    }
}
