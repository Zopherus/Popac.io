using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pacman
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PacmanGame : Microsoft.Xna.Framework.Game
    {
        public const int screenWidth = 31 * gridSize;
        public const int screenHeight = 17 * gridSize;
        public const int gridSize = 25;
        
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public static KeyboardState keyboard;
        public static KeyboardState oldKeyboard;
        public static MouseState mouse;
        public static MouseState oldMouse;

        public static Pacman pacman;
        public static Ghost ghost;

        public static Texture2D PacmanTexture;
        public static Texture2D WallTexture;
        public static Texture2D DotTexture;
        public static Texture2D PowerupTexture;
        public static Texture2D GhostTexture;
        public static Texture2D GhostPowerupTexture;
        public static Texture2D BlackTexture;
        public static SpriteFont spriteFont;
        
        public PacmanGame()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = screenHeight,
                PreferredBackBufferWidth = screenWidth
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        //Used to initialize the program
        public void Start()
        {
            UpdateStates.TimerMaze.resetTimer();
            pacman = new Pacman(new Rectangle(gridSize, gridSize, gridSize, gridSize));
            ghost = new Ghost(new Rectangle(screenWidth - 2 * gridSize, screenHeight - 2 * gridSize, gridSize, gridSize));
            Map.InitializeMap();
            Highscore.ReadFromFile();
            Map.Ghosts.Add(ghost);
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
            GameState.MenuTrue();
            Start();
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
            PacmanTexture = Content.Load<Texture2D>("Sprites/Pacman");
            WallTexture = Content.Load<Texture2D>("Sprites/Wall");
            DotTexture = Content.Load<Texture2D>("Sprites/Dot");
            PowerupTexture = Content.Load<Texture2D>("Sprites/Powerup");
            GhostTexture = Content.Load<Texture2D>("Sprites/Ghost");
            GhostPowerupTexture = Content.Load<Texture2D>("Sprites/GhostPowerup");
            BlackTexture = Content.Load<Texture2D>("Sprites/Black");
            spriteFont = Content.Load<SpriteFont>("SpriteFonts/SpriteFont");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            oldKeyboard = keyboard;
            oldMouse = mouse;
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();
            if (GameState.Menu)
                UpdateStates.UpdateMenu();
            if (GameState.Maze)
                UpdateStates.UpdateMaze(gameTime);
            if (GameState.Powerup)
                UpdateStates.UpdatePowerup(gameTime);
            if (GameState.EnterName)
                UpdateStates.UpdateEnterName();
            if (GameState.HighScore)
                UpdateStates.UpdateHighScore();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (GameState.Menu)
                DrawStates.DrawMenu();
            if (GameState.Maze)
                DrawStates.DrawMaze();
            if (GameState.Powerup)
                DrawStates.DrawPowerup();
            if (GameState.EnterName)
                DrawStates.DrawEnterName();
            if (GameState.HighScore)
                DrawStates.DrawHighScore();
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
