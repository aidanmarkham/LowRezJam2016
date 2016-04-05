using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LowRezJam
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D scene;
        Texture2D test;
        SpriteFont fipps;

        KeyboardState keyboard;
        KeyboardState oldkeyboard;


        #region Menu Instantiation
        int menuOption;
        Texture2D menuBG;
        List<Texture2D> menuOptions;
        #endregion
        #region Options Instantiation
        int optionsOption;
        Texture2D optionsBG;
        List<Texture2D> optionsOptions;
        List<Texture2D> musicStatus;
        int musicStat;
        List<Texture2D> sfxStatus;
        int sfxStat;
        Texture2D credits;
        #endregion

        GameState gameState;

        enum GameState { Menu, Options, Credits, Game }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 640;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 640;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";


            gameState = GameState.Menu;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            menuOptions = new List<Texture2D>();
            optionsOptions = new List<Texture2D>();
            musicStatus = new List<Texture2D>();
            musicStat = 0;
            sfxStatus = new List<Texture2D>();
            sfxStat = 0;
            base.Initialize();
            menuOption = 0;
            optionsOption = 0;
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            scene = new RenderTarget2D(graphics.GraphicsDevice, 64, 64);
            test = this.Content.Load<Texture2D>("test.jpg");
            fipps = this.Content.Load<SpriteFont>("Fonts/Fipps");

            #region Menu Image Loading
            menuBG = this.Content.Load<Texture2D>("MenuContent/Main/MenuBG.png");
            menuOptions.Add(this.Content.Load<Texture2D>("MenuContent/Main/MenuOption1.png"));
            menuOptions.Add(this.Content.Load<Texture2D>("MenuContent/Main/MenuOption2.png"));
            #endregion
            #region Options Image Loading
            optionsBG = this.Content.Load<Texture2D>("MenuContent/Options/OptionsBG.png");
            optionsOptions.Add(this.Content.Load<Texture2D>("MenuContent/Options/OptionsOption1.png"));
            optionsOptions.Add(this.Content.Load<Texture2D>("MenuContent/Options/OptionsOption2.png"));
            optionsOptions.Add(this.Content.Load<Texture2D>("MenuContent/Options/OptionsOption3.png"));
            optionsOptions.Add(this.Content.Load<Texture2D>("MenuContent/Options/OptionsOption4.png"));
            musicStatus.Add(this.Content.Load<Texture2D>("MenuContent/Options/OptionsON1.png"));
            musicStatus.Add(this.Content.Load<Texture2D>("MenuContent/Options/OptionsOFF1.png"));
            sfxStatus.Add(this.Content.Load<Texture2D>("MenuContent/Options/OptionsON2.png"));
            sfxStatus.Add(this.Content.Load<Texture2D>("MenuContent/Options/OptionsOFF2.png"));
            credits = this.Content.Load<Texture2D>("MenuContent/Options/credits.png");
            #endregion

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            keyboard = Keyboard.GetState();

            #region Menu
            if (gameState == GameState.Menu)
            {
                if (keyboard.IsKeyDown(Keys.Down) && !oldkeyboard.IsKeyDown(Keys.Down))
                {
                    menuOption = 1;
                }
                else if (keyboard.IsKeyDown(Keys.Up) && !oldkeyboard.IsKeyDown(Keys.Up))
                {
                    menuOption = 0;
                }
                if (keyboard.IsKeyDown(Keys.Enter) && !oldkeyboard.IsKeyDown(Keys.Enter))
                {
                    if (menuOption == 0)
                    {
                        gameState = GameState.Game;
                    }
                    else if (menuOption == 1)
                    {
                        gameState = GameState.Options;
                    }
                }
            }
            #endregion
            #region Options
            else if (gameState == GameState.Options)
            {
                if (keyboard.IsKeyDown(Keys.Down) && !oldkeyboard.IsKeyDown(Keys.Down) && optionsOption != optionsOptions.Count - 1)
                {
                    optionsOption += 1;
                }
                else if (keyboard.IsKeyDown(Keys.Up) && !oldkeyboard.IsKeyDown(Keys.Up) && optionsOption > 0)
                {
                    optionsOption -= 1;
                }
                if (keyboard.IsKeyDown(Keys.Enter) && !oldkeyboard.IsKeyDown(Keys.Enter))
                {
                    if (optionsOption == 0)
                    {
                        if (musicStat == 0)
                        {
                            musicStat = 1;
                        }
                        else
                        {
                            musicStat = 0;
                        }
                    }
                    else if (optionsOption == 1)
                    {
                        if (sfxStat == 0)
                        {
                            sfxStat = 1;
                        }
                        else
                        {
                            sfxStat = 0;
                        }
                    }
                    else if (optionsOption == 2)
                    {
                        gameState = GameState.Credits;
                    }
                    else if (optionsOption == 3)
                    {
                        gameState = GameState.Menu;
                    }
                }
            }
            #endregion
            #region Game
            else if (gameState == GameState.Game)
            {

            }
            #endregion
            #region Credits
            else if (gameState == GameState.Credits)
            {
                if (keyboard.IsKeyDown(Keys.Enter) && !oldkeyboard.IsKeyDown(Keys.Enter))
                {
                    gameState = GameState.Options;
                }
            }
            #endregion
            base.Update(gameTime);
            oldkeyboard = keyboard;
        }

        protected override void Draw(GameTime gameTime)
        {
            #region Draw start
            //Clear just in case
            GraphicsDevice.Clear(Color.Black);

            GraphicsDevice.SetRenderTarget(scene);
            #endregion
            //Inside here is the game rendering ----------------------
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            #region Menu
            if (gameState == GameState.Menu)
            {
                spriteBatch.Draw(menuBG, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(menuOptions[menuOption], new Vector2(0, 0), Color.White);
                //spriteBatch.DrawString(fipps, "Go", new Vector2(0, 0), Color.White);
            }
            #endregion
            #region Options
            else if (gameState == GameState.Options)
            {
                spriteBatch.Draw(optionsBG, new Rectangle(0, 0, 64, 64), Color.White);
                spriteBatch.Draw(musicStatus[musicStat], new Vector2(0, 0), Color.White);
                spriteBatch.Draw(sfxStatus[sfxStat], new Vector2(0, 0), Color.White);
                spriteBatch.Draw(optionsOptions[optionsOption], new Vector2(0, 0), Color.White);
            }
            #endregion
            #region Credits
            else if(gameState == GameState.Credits)
            {
                spriteBatch.Draw(credits, new Vector2(0, 0), Color.White);
            }
            #endregion
            #region Game
            else if (gameState == GameState.Game)
            {


                spriteBatch.Draw(test, new Rectangle(0, 0, 64, 64), Color.White);

            }
            #endregion
            //--------------------------------------------------------
            spriteBatch.End();
            #region Draw Finish
            GraphicsDevice.SetRenderTarget(null);
            //Draw screen
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
            //spriteBatch.Begin();
            spriteBatch.Draw(scene, new Rectangle(0, 0, 640, 640), Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
            #endregion
        }
    }
}
