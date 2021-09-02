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
        Cell[,] cells;
        Vector2 center;
        Player player = Player.Red;
        int[] columnHeight = new int[7];
        bool pressed = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public bool CheckRow(int Row)
        {
            int InRowCount = 0;
            for (int col = 0; col < columns; col++)
            {

                if (cells[Row, col].Player == player)
                {
                    InRowCount++;
                    if (InRowCount >= 4)
                    {
                        return true;
                    }
                }
                else
                {
                    InRowCount = 0;
                }
            }
            return false;

        }
        public bool CheckCol(int Col)
        {
            int InColCount = 0;
            for (int row = 0; row < rows; row++)
            {

                if (cells[row, Col].Player == player)
                {
                    InColCount++;
                    if (InColCount >= 4)
                    {
                        return true;
                    }
                }
                else
                {
                    InColCount = 0;
                }
            }
            return false;
        }
        public bool CheckDiagTopLeft(int Row, int Col)
        {
            int InDiagCount = 0;
            // if the row is bigger, column will start as 0, if the col is bigger, row will start at 0

            int startRow;
            int startCol;

            if (Row > Col)
            {
                startCol = 0;
                startRow = Row - Col;

            }
            else
            {
                startRow = 0;
                startCol = Col - Row;

            }



            // figure out the diagonal logic (should only be one for loop)

            while (startRow < rows && startCol < columns)
            {
                if (cells[startRow, startCol].Player == player)
                {
                    InDiagCount++;
                    if (InDiagCount >= 4)
                    {
                        return true;
                    }
                }
                else
                {
                    InDiagCount = 0;
                }
                startRow++;
                startCol++;
            }
            return false;
        }
        public bool CheckDiagTopRight(int Row, int Col)
        {
            int InDiagCount = 0;
            // if the row is bigger, column will start as 0, if the col is bigger, row will start at 0

            int startRow;
            int startCol;

            if (Row >= Col)
            {
                startRow = 0;
                startCol = Col + Row;

            }
            else
            {
                int steps = columns - Col;
                startRow = Row - steps;
                startCol = columns;

            }
            // figure out the diagonal logic (should only be one for loop)

            while (startRow < rows && startCol > 0 && startCol < columns)
            {
                if (cells[startRow, startCol].Player == player)
                {
                    InDiagCount++;
                    if (InDiagCount >= 4)
                    {
                        return true;
                    }
                }
                else
                {
                    InDiagCount = 0;
                }
                startRow++;
                startCol--;
            }
            return false;
        }
        public bool CheckWin(int Row, int Col)
        {
            return CheckRow(Row) || CheckCol(Col) || CheckDiagTopRight(Row, Col) || CheckDiagTopLeft(Row, Col);
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            center = new Vector2(radius + radius / 2, radius + radius / 2);
            cells = new Cell[rows, columns];

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int a = 0; a < cells.GetLength(1); a++)
                {
                    cells[i, a] = new Cell(radius, center, Player.None);
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

            MouseState ms = Mouse.GetState();

            if (!pressed && ms.LeftButton == ButtonState.Pressed)
            {
                pressed = true;
            }
            else if (pressed && ms.LeftButton == ButtonState.Released)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        if (cells[row, col].Hitbox.Contains(ms.Position))
                        {
                            if (columnHeight[col] < rows)
                            {
                                int placementRow = rows - 1 - columnHeight[col];
                                cells[placementRow, col].Player = player;


                                columnHeight[col]++;

                                // fix top right diagonal
                                if (CheckWin(placementRow, col))
                                {

                                }

                                if (player == Player.Red)
                                {
                                    player = Player.Yellow;
                                }
                                else if (player == Player.Yellow)
                                {
                                    player = Player.Red;
                                }
                            }

                            break;
                        }
                    }
                }

                pressed = false;
            }
            


            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            //_spriteBatch.DrawCircle(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), 30, 32, Color.White);

            for (int a = 0; a < rows; a++)
            {
                for (int i = 0; i < columns; i++)
                {
                    cells[a, i].Draw(spriteBatch);
                }

            }

            spriteBatch.End();

            base.Draw(gameTime);

        }
    }

}
