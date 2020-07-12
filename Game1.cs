using Game1.GameControl;
using Game1.Screen;
using Game1.Screen.MenuItems;
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

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        float elapsed;
        Camera camera;
        
        Controller keyboard;
        GameLogic gameLogic;
        List<IScreen> screens;
        GameController gameController;

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
            camera = new Camera(GraphicsDevice.Viewport, new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2)); //why don't do this in constructor
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

            //Used to update and draw correct screen
            gameController = new GameController();

            // Loading character sprites
            Texture2D walkingFatManRight = Content.Load<Texture2D>("walkingFatMan");
            Texture2D walkingFatManLeft = Content.Load<Texture2D>("walkingFatManLeft");

            //Loading blocks
            List<Texture2D> blocksLevel1 = new List<Texture2D>() { Content.Load<Texture2D>("isometric_pixel_flat_0014"),// gras over mud
                                                   Content.Load<Texture2D>("isometric_pixel_flat_0086") //chest
                                                   };

            List<Texture2D> blocksLevel2 = new List<Texture2D>() { Content.Load<Texture2D>("isometric_pixel_flat_0056"),// gras over stone
                                                   Content.Load<Texture2D>("isometric_pixel_flat_0055") //stone
                                                   };

            //loading fonts
            List<SpriteFont> fonts = new List<SpriteFont>() { Content.Load<SpriteFont>("titelFont"),
                                             Content.Load<SpriteFont>("selectedFont"), 
                                             Content.Load<SpriteFont>("regularFont") };

            //Level1
            Level level1 = new Level1(blocksLevel1);
            Player player = new Player(new AnimationEngine(walkingFatManRight, walkingFatManLeft, 64, 8), //should this be in constructor. should I set picture on the class itself etc
                                new MovementEngine(new Vector2(200, 200),
                                new Vector2(0.35f, 0.35f),
                                new Vector2(0.01f, 0.01f)),
                                keyboard);
            gameLogic = new GameLogic(new Finish(new Vector2(6000, 200), Content.Load<Texture2D>("cheeseburger")), player);

            //Level2
            Level level2 = new Level2(blocksLevel2);

            //GameMenu
            List<String> options = new List<string>() { "Level 1", "Level 2" };
            GameMenu gameMenu = new GameMenu(fonts, keyboard, "Hamburger Hunt", "To select press up", options, GraphicsDevice.Viewport, gameController, new MainMenuSetStateBehavior());

            //EndScreen
            options = new List<string>() { "Back To Menu" };
            GameMenu endScreen = new GameMenu(fonts, keyboard, "Level, finished!", "To select press up", options, GraphicsDevice.Viewport, gameController, new MainMenuSetStateBehavior());//Ibehavior moet nog worden geupdate

            screens = new List<IScreen>() { level1, level2, gameMenu, endScreen };

            gameController.addScreens(screens);

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

            gameController.Update(gameTime);        
            
            base.Update(gameTime);
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(RandomColorGenerator.CurrentColor);

            var viewMatrix = camera.GetViewMatrix();
            spriteBatch.Begin(transformMatrix: viewMatrix);
            gameController.Draw(spriteBatch);
            //player.Draw(spriteBatch);
            //gameLogic.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    } 
}
