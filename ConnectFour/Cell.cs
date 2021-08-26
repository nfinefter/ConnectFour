using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class Cell : Sprite
    {
        public float Radius;

        public Player Player;

        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)(Position.X - Radius), (int)(Position.Y - Radius), (int)(Radius * 2), (int)(Radius * 2));
            }
        }

        public Cell(float radius, Vector2 position, Player player) : base(position)
        {
            Radius = radius;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float radius = Radius;
            while (radius > 0)
            {
                if (Player == Player.None)
                {
                    spriteBatch.DrawCircle(Position, radius, 32, Color.White);
                    radius--;
                }
                if (Player == Player.Red)
                {
                    spriteBatch.DrawCircle(Position, radius, 32, Color.Red);
                    radius--;
                }
                if (Player == Player.Yellow)
                {
                    spriteBatch.DrawCircle(Position, radius, 32, Color.Yellow);
                    radius--;
                }
            }
            //     spriteBatch.DrawRectangle(Hitbox, Color.Red);
        }
    }
}
