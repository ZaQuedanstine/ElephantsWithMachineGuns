using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ElephantsWithMachineGuns;

namespace ElaphantsWithMachineGuns
{
    public class ElephantGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont bangers;
        private Ground grass;
        private Banner banner;
        private Elephant elephant;
        private Clouds clouds;

        public ElephantGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Elephants With Machine Guns";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            banner = new Banner(GraphicsDevice);
            grass = new Ground(GraphicsDevice);
            elephant = new Elephant(GraphicsDevice);
            clouds = new Clouds(GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            bangers = Content.Load<SpriteFont>("bangers");
            grass.LoadContent(Content);
            banner.LoadContent(Content);
            elephant.LoadContent(Content);
            clouds.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            banner.Update(gameTime);
            elephant.Update(gameTime);
            clouds.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            grass.Draw(gameTime, _spriteBatch);
            clouds.Draw(gameTime, _spriteBatch);
            _spriteBatch.DrawString(bangers, "Press esc to close", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 32), Color.Gold);
            banner.Draw(gameTime, _spriteBatch);
            elephant.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
