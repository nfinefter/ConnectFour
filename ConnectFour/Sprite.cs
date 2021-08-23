using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended;

namespace ConnectFour
{
    public class Sprite
    {
        public Vector2 Position;
        public float Radius;
        

        public Sprite (Vector2 position, float radius)
        {
            Position = position;
            Radius = radius;
            
        }

        public void FillCircle(SpriteBatch spriteBatch, bool fill)
        {
            float radius = Radius;
            while (radius > 0)
            {
                if (fill == false)
                {
                    spriteBatch.DrawCircle(Position, radius, 32, Color.White);
                    radius--;
                }
                if (fill == true)
                {
                    spriteBatch.DrawCircle(Position, radius, 32, Color.Red);
                    radius--;
                }
            }
       //     spriteBatch.DrawRectangle(Hitbox, Color.Red);
        }

        public Rectangle Hitbox
        {
            get 
            {
                return new Rectangle((int)(Position.X - Radius), (int)(Position.Y - Radius), (int)(Radius * 2), (int)(Radius * 2));
            }
        }

    }
}
