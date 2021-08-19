using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace ConnectFour
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        public int rows = 6;
        public int columns = 7;
        int radius = 30;
        Sprite[,] cells;
        Vector2 center;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            center = new Vector2(radius + radius / 2, radius + radius / 2);
            cells = new Sprite[rows, columns];

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int a = 0; a < cells.GetLength(1); a++)
                {
                    cells[i, a] = new Sprite(center, radius);
                    center.X += 80;
                }
                center.X = radius + radius / 2;
                center.Y += 80;
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here




            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            //_spriteBatch.DrawCircle(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), 30, 32, Color.White);




            for (int a = 0; a < rows; a++)
            {
                for (int i = 0; i < columns; i++)
                {
                    cells[a, i].FillCircle(spriteBatch);
                }

            }
            spriteBatch.End();

            base.Draw(gameTime);

        }
    }
}
