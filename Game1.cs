﻿using Microsoft.Xna.Framework;
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
        EndScreen
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D walkingFatManRight;
        Texture2D walkingFatManLeft;
        
        Player player;
        Level1 level1;
        Level level2;
        float elapsed;
        Camera camera;
        List<SpriteFont> fonts;
        List<Texture2D> blocksLevel1;
        List<Texture2D> blocksLevel2;
        GameMenu gameMenu;
        GameMenu endScreen;
        Controller keyboard;
        GameLogic gameLogic;
        
        GameState CurrGameState = GameState.MainMenu;
        GameState PrevGameState = GameState.MainMenu;

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
            blocksLevel1 = new List<Texture2D>() { Content.Load<Texture2D>("isometric_pixel_flat_0014"),// gras over mud
                                                   Content.Load<Texture2D>("isometric_pixel_flat_0086") //chest
                                                   };

            blocksLevel2 = new List<Texture2D>() { Content.Load<Texture2D>("isometric_pixel_flat_0056"),// gras over stone
                                                   Content.Load<Texture2D>("isometric_pixel_flat_0055") //stone
                                                   };

            //loading fonts
            fonts = new List<SpriteFont>() { Content.Load<SpriteFont>("titelFont"),
                                             Content.Load<SpriteFont>("selectedFont"), 
                                             Content.Load<SpriteFont>("regularFont") };

            //Level1
            level1 = new Level1(blocksLevel1);
            player = new Player(new AnimationEngine(walkingFatManRight, walkingFatManLeft, 64, 8),
                                new MovementEngine(new Vector2(200, 200),
                                new Vector2(0.35f, 0.35f),
                                new Vector2(0.01f, 0.01f)),
                                keyboard);
            gameLogic = new GameLogic(new Finish(new Vector2(6000, 200), Content.Load<Texture2D>("cheeseburger")), player);

            //Level2
            level2 = new Level1(blocksLevel1);

            //GameMenu
            List<String> options = new List<string>() { "Level 1", "Level 2" };
            gameMenu = new GameMenu(fonts, keyboard, "Hamburger Hunt", "To select press up", options);

            //EndScreen
            options = new List<string>() { "Back To Menu" };
            endScreen = new GameMenu(fonts, keyboard, "Level, finished!", "To select press up", options);

            //ReLoadLevel();

        }

        protected void ReLoadLevel()
        {
            //Loading right level. Inspired by https://www.youtube.com/watch?v=54L_w0PiRa8&list=PL667AC2BF84D85779&index=30
            switch (CurrGameState)
            {
                case GameState.Level1:
                    //Level1
                    level1 = new Level1(blocksLevel1);
                    player = new Player(new AnimationEngine(walkingFatManRight, walkingFatManLeft, 64, 8),
                                        new MovementEngine(new Vector2(200, 200),
                                        new Vector2(0.35f, 0.35f),
                                        new Vector2(0.01f, 0.01f)),
                                        keyboard);
                    gameLogic = new GameLogic(new Finish(new Vector2(2300, 300), Content.Load<Texture2D>("cheeseburger")), player);
                    break;

                case GameState.Level2:
                    //Level2
                    level2 = new Level1(blocksLevel2);
                    player = new Player(new AnimationEngine(walkingFatManRight, walkingFatManLeft, 64, 8),
                                        new MovementEngine(new Vector2(200, 200),
                                        new Vector2(0.35f, 0.35f),
                                        new Vector2(0.01f, 0.01f)),
                                        keyboard);
                    gameLogic = new GameLogic(new Finish(new Vector2(2300,300), Content.Load<Texture2D>("cheeseburger")), player);
                    break;

                case GameState.EndScreen:
                    List<String> options1 = new List<string>() { "Back To Menu" };
                    endScreen = new GameMenu(fonts, keyboard, "Level, finished!", "To select press up", options1);
                    break;

                default:
                    //GameMenu
                    List<String> options = new List<string>() { "Level 1", "Level 2" };
                    gameMenu = new GameMenu(fonts, keyboard, "Hamburger Hunt", "To select press up", options);
                    break;
            }
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
            
            if (CurrGameState != PrevGameState)
            {
                PrevGameState = CurrGameState;
                ReLoadLevel();
            }

            //Loading right level. Inspired by https://www.youtube.com/watch?v=54L_w0PiRa8&list=PL667AC2BF84D85779&index=30
            switch (CurrGameState)
            {
                case GameState.Level1:
                    //level1.Update(gameTime);
                    
                    //Player and camera update
                    player.Update(gameTime, GraphicsDevice.Viewport);
                    camera.Update(player.Position);
                    gameLogic.Update();
                    if (gameLogic.GoalReached)
                    {
                        CurrGameState = GameState.EndScreen;
                    }
                    break;

                case GameState.Level2:
                    //level2.Update(gameTime);

                    player.Update(gameTime, GraphicsDevice.Viewport);
                    camera.Update(player.Position);
                    gameLogic.Update();
                    if (gameLogic.GoalReached)
                    {
                        CurrGameState = GameState.EndScreen;
                    }
                    break;

                case GameState.EndScreen:
                    endScreen.Update(gameTime);
                    CurrGameState = (GameState)gameMenu.LevelChosen+5;
                    break;

                default:
                    gameMenu.Update(gameTime);
                    CurrGameState = (GameState)gameMenu.LevelChosen;
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
                case GameState.Level1:
                    var viewMatrix = camera.GetViewMatrix();
                    spriteBatch.Begin(transformMatrix: viewMatrix);
                    level1.Draw(spriteBatch); //testen of het echt obsolete is
                    player.Draw(spriteBatch);
                    gameLogic.Draw(spriteBatch);
                    break;

                case GameState.Level2:
                    var viewMatrix1 = camera.GetViewMatrix();
                    spriteBatch.Begin(transformMatrix: viewMatrix1);
                    level2.Draw(spriteBatch); //testen of het echt obsolete is
                    player.Draw(spriteBatch);
                    gameLogic.Draw(spriteBatch);
                    break;

                case GameState.EndScreen:
                    spriteBatch.Begin();
                    endScreen.Draw(spriteBatch, GraphicsDevice.Viewport);
                    break;

                default:
                    //Debug.WriteLine(CurrGameState);
                    spriteBatch.Begin();
                    gameMenu.Draw(spriteBatch, GraphicsDevice.Viewport);
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    } 
}
