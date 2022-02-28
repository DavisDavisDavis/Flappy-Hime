using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flappy_Hime
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D hime;
        Texture2D background;

        Rectangle hime_rectan = new Rectangle(100, 100, 100, 100);
        Vector2 background_position = new Vector2(0, 0);

        KeyboardState button = Keyboard.GetState();
        KeyboardState button_old = Keyboard.GetState();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            hime = Content.Load<Texture2D>("hime happy 2");
            background = Content.Load<Texture2D>("background");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            button_old = button;
            button = Keyboard.GetState();

            hime_rectan.Y += 1;

            if (button.IsKeyDown(Keys.Space) && button_old.IsKeyUp(Keys.Space))
            {
                hime_rectan.Y -= 50;
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(background, background_position, Color.White);
            _spriteBatch.Draw(hime, hime_rectan, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
