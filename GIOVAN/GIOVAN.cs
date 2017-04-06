using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GIOVAN
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GIOVAN : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D _MoveRight;
        private Texture2D _MoveLeft;
        private Texture2D _MoveUp;
        private Texture2D _MoveDown;

        private SpriteFont font;
        private int _Score = 0;
        private float _MUAngle = 0;
        private Vector2 _Position = new Vector2(200,200);

        private Song BGMusic1;

        public GIOVAN()
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

            // TODO: use this.Content to load your game content here
            _MoveRight = Content.Load<Texture2D>("right1(new)");
            _MoveLeft = Content.Load<Texture2D>("left1(new)");
            _MoveUp = Content.Load<Texture2D>("up1(new)");
            _MoveDown = Content.Load<Texture2D>("down1(new)");

            font = Content.Load<SpriteFont>("Title"); // Use the name of your sprite font file here instead of 'Score'.

            BGMusic1 = Content.Load<Song>("Tool - Hooker With a Penis");
            MediaPlayer.Volume = 1f;
            MediaPlayer.Play(BGMusic1);

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

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _Position.X += 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _Position.X -= 3;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _Position.Y += 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _Position.Y -= 3;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);

            if (_Score < 1000)
            {
                _Score = _Score + 1;
            }
            if (_Score >= 1000)
            {
                _Score = _Score + 2;
            }

            _MUAngle += 0.01f;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);

            Vector2 location = new Vector2(400, 240);
            Rectangle sourceRectangle = new Rectangle(0, 0, _MoveUp.Width, _MoveUp.Height);
            Vector2 origin = new Vector2(_MoveUp.Width, _MoveUp.Height);
            Vector2 MROrigin = new Vector2(300, 300);

            spriteBatch.Draw(_MoveRight, _Position, sourceRectangle, Color.White, 0, origin, 3.0f, SpriteEffects.None, 1);
            spriteBatch.Draw(_MoveUp, location, sourceRectangle, Color.White, _MUAngle, origin, 3.0f, SpriteEffects.None, 1);

            spriteBatch.DrawString(font, "Giovan", new Vector2(50, 50), Color.Black);
            spriteBatch.DrawString(font, "Score: " + _Score, new Vector2(50, 200), Color.Black);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
