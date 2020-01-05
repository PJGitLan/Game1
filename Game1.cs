using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D walkingFatManRight;
        Texture2D walkingFatManLeft;
        Texture2D grasMudBlock;
        Player player;
        Level level1;
        float elapsed;
        // Texture2D pixel;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GraphicsDevice.Clear(RandomColorGenerator.Next());
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            walkingFatManRight = Content.Load<Texture2D>("walkingFatMan");
            walkingFatManLeft = Content.Load<Texture2D>("walkingFatManLeft");
            grasMudBlock = Content.Load<Texture2D>("isometric_pixel_flat_0014");
            Controller keyboard = new TheKeyBoard();
            level1 = new Level1(grasMudBlock);
            player = new Player(walkingFatManRight, walkingFatManLeft, new MovementEngine(new Vector2(200,200), new Vector2(0.75f, 0.75f)), keyboard);

            // TODO: use this.Content to load your game content here

            //pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            //pixel.SetData(new[] { Color.White });
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>        
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

            elapsed += gameTime.ElapsedGameTime.Milliseconds;

            level1.Update(gameTime);

            if (elapsed > 2000)
            {
                RandomColorGenerator.Next();
                elapsed = 0;
            }
            
            player.Update(gameTime);
            base.Update(gameTime);
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(RandomColorGenerator.CurrentColor);
            spriteBatch.Begin();
            level1.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    } 
}
