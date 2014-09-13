#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion



namespace NinjaGaiDemake
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class NinjaGaiDemake_Game : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;

        SpriteFont Font1;
        Texture2D pixel;

        bool debugBoxesOn, editorModeOn;

        // Represents player
        public Player player;
        Weapon playerSword;
        Camera camera;
        //Player enemy;

        // Sounds
        //SoundEffect backgroundMusic;
        //bool songStart = false;


        // Environment stuff
        //public Layer[] layers;

        // Screen iterator
        public int currentScreen;

        // SCREENS (List)
        //public Screen screen;
        public List<Screen> screens;

        public List<EnvironmentSolid> collisionSolids; // deprecate
        public List<BoundingRect> collisionAreas;
        EnvironmentSolid floor;
        EnvironmentSolid tower1;

        // Keyboard states used to determine key presses
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        // Gamepad states used to determine button presses
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        // Mouse states used to track mouse button presses
        MouseState currentMouseState;
        MouseState previousMouseState;


        public Texture2D introScreen;
        public Texture2D winScreen;
        public Texture2D loseScreen;

        // A movement speed for the player
        //float playerMoveSpeed;

        //private Texture2D flatulina;

        public NinjaGaiDemake_Game()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 728;
            graphics.ApplyChanges();
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
            this.IsMouseVisible = true;

            // Initialize the player class
            player = new Player();
            playerSword = new Weapon();
            camera = new Camera();

            //enemy = new Player();


            collisionSolids = new List<EnvironmentSolid>(); // deprecate
            collisionAreas = new List<BoundingRect>();
            floor = new EnvironmentSolid();
            tower1 = new EnvironmentSolid();

            collisionSolids.Add(floor);
            collisionSolids.Add(tower1);


            debugBoxesOn = false;
            editorModeOn = false;

            currentScreen = new int();
            currentScreen = 0;
            //screen = new Screen();
            screens = new List<Screen>();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Font1 = Content.Load<SpriteFont>("Graphics\\Courier New");
            //Vector2 fontPosition = new Vector2(graphics.GraphicsDevice.Viewport.TitleSafeArea.X + 10, graphics.GraphicsDevice.Viewport.TitleSafeArea.Y + 10);

            // for drawing debug rectangles
            pixel = new Texture2D(graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White }); // so that we can draw whatever color we want on top of it

            // Load player resources
            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 20f, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            // Vector2 enemyPosition = new Vector2(500, 100);

            playerSword.Initialize(Content.Load<Texture2D>("Graphics\\ninja_sword"), playerPosition);
            player.Initialize(this, Content.Load<Texture2D>("Graphics\\ninja_stand"), playerPosition, playerSword);
            //enemy.Initialize(Content.Load<Texture2D>("Graphics\\cherub-flying-arms"), enemyPosition);


            introScreen = Content.Load<Texture2D>("Graphics\\IntroScreen");
            winScreen = Content.Load<Texture2D>("Graphics\\WinScreen");
            loseScreen = Content.Load<Texture2D>("Graphics\\LoseScreen");


            // Sound
            //backgroundMusic = Content.Load<SoundEffect>("Sound\\LuteSong");

            // Environment

            // vvvvvvvvvvvvvvv New vvvvvvvvvvvvvvvvvvv

            // SCREEN 1

            // add new screen to screen list
            //screens.Add(new Screen());

            // load collision area list

            // 

            // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

            // vvvvvvvvvvvvvv Original Caleb Implementation vvvvvvvvvvvvvvvvvvvv

            // SCREEN 1
            screens.Add(new Screen());

            screens[0].objs.Add(new EnvironmentSolid());
            screens[0].objs[0].Initialize(Content.Load<Texture2D>("Graphics\\tower"), new Vector2(400, GraphicsDevice.Viewport.TitleSafeArea.Height - 450));
            screens[0].objs.Add(new EnvironmentSolid());
            screens[0].objs[1].Initialize(Content.Load<Texture2D>("Graphics\\floor"), new Vector2(0, GraphicsDevice.Viewport.TitleSafeArea.Height - 100));

            screens[0].enemies.Add(new Enemy());
            screens[0].enemies[0].Initialize(Content.Load<Texture2D>("Graphics\\tempCherub"), new Vector2(700, 570));
            screens[0].enemies[0].SetPath(new Vector2(600, 570), new Vector2(900, 570), new Vector2(700, 520));

            //Initialize PowerUps
            screens[0].powerups.Add(new Powerup(Content.Load<Texture2D>("Graphics\\powerUp"), new Vector2(600, 525), 100, 100, true));


            //// SCREEN 2
            //screens.Add(new Screen());

            screens[0].objs.Add(new EnvironmentSolid());
            screens[0].objs[2].Initialize(Content.Load<Texture2D>("Graphics\\tower"), new Vector2(900, GraphicsDevice.Viewport.TitleSafeArea.Height - 450));

            screens[0].objs.Add(new EnvironmentSolid());
            screens[0].objs[3].Initialize(Content.Load<Texture2D>("Graphics\\tower"), new Vector2(1700, GraphicsDevice.Viewport.TitleSafeArea.Height - 450));

            screens[0].objs.Add(new EnvironmentSolid());
            screens[0].objs[4].Initialize(Content.Load<Texture2D>("Graphics\\tower"), new Vector2(2700, GraphicsDevice.Viewport.TitleSafeArea.Height - 450));

            screens[0].objs.Add(new EnvironmentSolid());
            screens[0].objs[5].Initialize(Content.Load<Texture2D>("Graphics\\tower"), new Vector2(2900, GraphicsDevice.Viewport.TitleSafeArea.Height - 450));

            screens[0].objs.Add(new EnvironmentSolid());
            screens[0].objs[6].Initialize(Content.Load<Texture2D>("Graphics\\tower"), new Vector2(3100, GraphicsDevice.Viewport.TitleSafeArea.Height - 450));

            screens[0].objs.Add(new EnvironmentSolid());
            screens[0].objs[7].Initialize(Content.Load<Texture2D>("Graphics\\tower"), new Vector2(3500, GraphicsDevice.Viewport.TitleSafeArea.Height - 450));
          

            screens[0].enemies.Add(new Enemy());
            screens[0].enemies[1].Initialize(Content.Load<Texture2D>("Graphics\\tempCherub"), new Vector2(600, 450));
            screens[0].enemies[1].SetPath(new Vector2(600, 570), new Vector2(750, 570), new Vector2(600, 220));

            screens[0].enemies.Add(new Enemy());
            screens[0].enemies[2].Initialize(Content.Load<Texture2D>("Graphics\\tempCherub"), new Vector2(200, 570));
            screens[0].enemies[2].SetPath(new Vector2(200, 570), new Vector2(300, 570), new Vector2(800, 520));

            screens[0].powerups.Add(new Powerup(Content.Load<Texture2D>("Graphics\\powerUp"), new Vector2(400, 525), 100, 100, true));



            // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


            // vvvvvvvvvvvvvvvvv Old vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
            //Vector2 floorPosition = new Vector2(0, GraphicsDevice.Viewport.TitleSafeArea.Height - 100);
            //floor.Initialize(Content.Load<Texture2D>("Graphics\\floor"), floorPosition);

            //Vector2 tower1Position = new Vector2(400, GraphicsDevice.Viewport.TitleSafeArea.Height - 450);
            //tower1.Initialize(Content.Load<Texture2D>("Graphics\\tower"), tower1Position);

            //Console.WriteLine("Loadeddddd");

            //flatulina = Content.Load<Texture2D>("Player/cherub-flying-arms");
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
            // vvvvvvvvvvvvv New vvvvvvvvvvvvvvvvvvvvv
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update the player
            player.Update(gameTime, currentKeyboardState, currentGamePadState);

            // update camera
            camera.Update(player.Position);

            // Save the previous state of the keyboard and game pad so we can determine single key/button presses
            previousGamePadState = currentGamePadState;
            previousKeyboardState = currentKeyboardState;

            // Read the current state of the keyboard and gamepad and store it
            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.B) && previousKeyboardState.IsKeyUp(Keys.B))
            {
                debugBoxesOn = !debugBoxesOn;
            }

            if (currentKeyboardState.IsKeyDown(Keys.L) && previousKeyboardState.IsKeyUp(Keys.L))
            {
                editorModeOn = !editorModeOn;
            }

            if (editorModeOn)
                MakeCollisionAreas();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // update enemies
            for (int i = 0; i < screens[currentScreen].enemies.Count; i++)
            {
                screens[currentScreen].enemies[i].Update(this, deltaTime);
            }

            // Sound

            ////BackGround music//////////SOUNDS BAD RIGHT NOW WILL EDIT
            //if (!songStart)
            //{
            //    SoundEffectInstance backgroundInstance = backgroundMusic.CreateInstance();
            //    backgroundInstance.IsLooped = true;
            //    backgroundInstance.Volume = 0.01f;
            //    backgroundInstance.Play();
            //}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, 
                null, null, null, null, camera.ViewMatrix);

            // draw mouse coordinates
            //currentMouseState = Mouse.GetState();
            //string mouseCoord = currentMouseState.X.ToString() + "  " + currentMouseState.Y.ToString();
            //Vector2 fontPosition = new Vector2(graphics.GraphicsDevice.Viewport.TitleSafeArea.X + 10, graphics.GraphicsDevice.Viewport.TitleSafeArea.Y + 10);
            //_spriteBatch.DrawString(Font1, mouseCoord, fontPosition, Color.White);

            //// draw velocity
            //string playerVel = player.Velocity.ToString();
            //Vector2 velFontPosition = new Vector2(graphics.GraphicsDevice.Viewport.TitleSafeArea.X + 10, graphics.GraphicsDevice.Viewport.TitleSafeArea.Y + 40);
            //_spriteBatch.DrawString(Font1, playerVel, velFontPosition, Color.White);

            // Draw Player
            player.Draw(_spriteBatch);
            if (player.sword.isActive)
                player.sword.Draw(_spriteBatch);

            // HUD
            _spriteBatch.Draw(pixel, player.fuelFill, Color.Red);
            DrawBorder(player.fuelOutline, 2, Color.White);

            // draw player debug rect
            if (debugBoxesOn)
            {
                DrawBorder(player.BoundingBox.DebugRect, 2, player.BoundingBox.DebugRectColor);
                DrawBorder(player.CollisionTop.DebugRect, 1, player.CollisionTop.DebugRectColor);
                DrawBorder(player.CollisionBottom.DebugRect, 1, player.CollisionBottom.DebugRectColor);
                DrawBorder(player.CollisionLeft.DebugRect, 1, player.CollisionLeft.DebugRectColor);
                DrawBorder(player.CollisionRight.DebugRect, 1, player.CollisionRight.DebugRectColor);
                DrawBorder(player.sword.BoundingBox.DebugRect, 1, player.sword.BoundingBox.DebugRectColor);
            }

            //enemy.Draw(_spriteBatch);
            for (int i = 0; i < screens[currentScreen].enemies.Count; i++)
            {
                if (screens[currentScreen].enemies[i].isAlive)
                    screens[currentScreen].enemies[i].Draw(_spriteBatch);
            }

            // draw powerups
            for (int i = 0; i < screens[currentScreen].powerups.Count; i++)
            {
                screens[currentScreen].powerups[i].Draw(_spriteBatch);
            }

            for (int i = 0; i < screens[currentScreen].objs.Count; i++)
            {
                screens[currentScreen].objs[i].Draw(_spriteBatch);

                // draw debug rectangles
                if (debugBoxesOn)
                    DrawBorder(screens[currentScreen].objs[i].BoundingBox.DebugRect, 2, screens[currentScreen].objs[i].BoundingBox.DebugRectColor);
            }

            // splash screens

            if (!player.playing)
            {
                _spriteBatch.Draw(introScreen, new Rectangle(0, 0, 1024, 728), Color.White);
            }
            else if (player.Position.X > 4700 && currentScreen == 1)
            {
                _spriteBatch.Draw(winScreen, new Rectangle(0, 0, 1024, 728), Color.White);
            }
            else if (!player.IsAlive)
            {
                _spriteBatch.Draw(loseScreen, new Rectangle(0, 0, 1024, 728), Color.White);
            }

            // draw collision volumes being created in editor mode
            if (editorModeOn)
            {
                // toggle 'editor' notification on screen
                string e = "Editor Mode On";
                Vector2 ePos = new Vector2(graphics.GraphicsDevice.Viewport.TitleSafeArea.Width - 200, graphics.GraphicsDevice.Viewport.TitleSafeArea.Y + 10);
               // _spriteBatch.DrawString(Font1, e, ePos, Color.White);

                // draw the rectangle area being defined by mouse drag
                DrawBorder(drawArea, 1, Color.Orange);

                // for each CA, draw a border for it
                for (int i = 0; i < collisionAreas.Count; i++)
                {
                    // draw debug rectangles
                    if (debugBoxesOn)
                        DrawBorder(collisionAreas[i].DebugRect, 2, collisionAreas[i].DebugRectColor);
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Will draw a border (hollow rectangle) of the given 'thicknessOfBorder' (in pixels)
        /// of the specified color.
        ///
        /// By Sean Colombo, from http://bluelinegamestudios.com/blog
        /// </summary>
        /// <param name="rectangleToDraw"></param>
        /// <param name="thicknessOfBorder"></param>
        public void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Draw top line
            _spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            _spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            _spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            _spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);
        }

        #region Level Creation

        public Rectangle drawArea;
        public int minX, minY, maxX, maxY, w, h;

        public void MakeCollisionAreas()
        {
            // if left mouse button has just been pressed
            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                // store location for min coordinate
                minX = currentMouseState.X;
                minY = currentMouseState.Y;

                // Initialize rectangle preview drawing position at pointer
                drawArea = new Rectangle(minX, minY, 0, 0);
            }

            // if left button is still held down
            if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                // modify size of the rectangle with current mouse values
                drawArea = new Rectangle(drawArea.X, drawArea.Y, currentMouseState.X - drawArea.X, currentMouseState.Y - drawArea.Y);
            }

            // if left mouse has been released
            if (currentMouseState.LeftButton == ButtonState.Released && previousMouseState.LeftButton == ButtonState.Pressed)
            {
                // store mouse location for dimension calculation // ** maybe change to just use drawArea?
                maxX = currentMouseState.X;
                maxY = currentMouseState.Y;
                w = maxX - minX;
                h = maxY - minY;

                // make a Bounding Rectangle and store it in the list
                BoundingRect newArea = new BoundingRect(minX, minY, w, h);
                collisionAreas.Add(newArea);

                // reset drawArea
                drawArea = new Rectangle(-1, -1, 0, 0);
            }
        }



        #endregion

    }
}
