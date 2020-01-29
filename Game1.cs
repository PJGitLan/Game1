using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>

    enum GameState
    {
        MainMenu,
        Level1,
        Level2,
    }

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
        Camera camera;
        List<SpriteFont> fonts;
        GameMenu gameMenu;
        Controller keyboard;
        
        GameState CurrGameState = GameState.Level1;
        GameState PrevGameState = GameState.Level1;

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
            
            //set initial background color
            GraphicsDevice.Clear(RandomColorGenerator.Next());

            //initialize a controller and camera
            camera = new Camera(GraphicsDevice.Viewport, new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2));
            keyboard = new TheKeyBoard();

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

            // Loading character sprites
            walkingFatManRight = Content.Load<Texture2D>("walkingFatMan");
            walkingFatManLeft = Content.Load<Texture2D>("walkingFatManLeft");

            //Loading blocks
            grasMudBlock = Content.Load<Texture2D>("isometric_pixel_flat_0014");

            //loading fonts
            fonts = new List<SpriteFont>() { Content.Load<SpriteFont>("titelFont"),
                                             Content.Load<SpriteFont>("selectedFont"), 
                                             Content.Load<SpriteFont>("regularFont") };

            ReLoadLevel();

        }

        protected void ReLoadLevel()
        {
            //Level1
            level1 = new Level1(grasMudBlock);
            player = new Player(new AnimationEngine(walkingFatManRight, walkingFatManLeft, 64, 8),
                                new MovementEngine(new Vector2(200, 200),
                                new Vector2(0.35f, 0.35f),
                                new Vector2(0.01f, 0.01f)),
                                keyboard);

            //GameMenu
            gameMenu = new GameMenu(fonts, keyboard);
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

            if (elapsed > 2000)
            {
                RandomColorGenerator.Next();
                elapsed = 0;
            }

            CurrGameState = (GameState) gameMenu.levelChosen ;
            if (CurrGameState != PrevGameState)
            {
                PrevGameState = CurrGameState;
                ReLoadLevel();
            }

            //Loading right level. Inspired by https://www.youtube.com/watch?v=54L_w0PiRa8&list=PL667AC2BF84D85779&index=30
            switch (CurrGameState)
            {
                default:
                    level1.Update(gameTime);
                    
                    //Player and camera update
                    player.Update(gameTime);
                    camera.Update(player.Position);
                    break;

                case GameState.Level2:
                    break;

                case GameState.Level1:
                    gameMenu.Update(gameTime);
                    break;
            }

            
            
            base.Update(gameTime);
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(RandomColorGenerator.CurrentColor);

            switch (CurrGameState)
            {
                default:
                    Debug.WriteLine(CurrGameState);
                    var viewMatrix = camera.GetViewMatrix();
                    spriteBatch.Begin(transformMatrix: viewMatrix);
                    level1.Draw(spriteBatch); //testen of het echt obsolete is
                    player.Draw(spriteBatch);
                    break;

                case GameState.Level2:
                    break;

                case GameState.Level1:
                    Debug.WriteLine(CurrGameState);
                    spriteBatch.Begin();
                    gameMenu.Draw(spriteBatch, GraphicsDevice.Viewport);
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    } 
}
