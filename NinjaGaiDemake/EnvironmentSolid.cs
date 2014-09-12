//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaGaiDemake
{
    public class EnvironmentSolid
    {
        public Texture2D EnvTexture;

        public Vector2 Position;

        // Area for collision detection
        public BoundingRect BoundingBox;

        // bool for going through bottom?

        // debug rectangle to draw
        //public Rectangle DebugRect;
        //public Color DebugRectColor;

        public int Width
        {
            get { return EnvTexture.Width; }
        }

        public int Height
        {
            get { return EnvTexture.Height; }
        }

        public void Initialize(Texture2D a_texture, Vector2 a_position)
        {
            EnvTexture = a_texture;
            Position = a_position;
            BoundingBox = new BoundingRect(Position.X, Position.Y, Width, Height);

            //DebugRect = new Rectangle((int)Position.X, (int)Position.Y, (int)Width, (int)Height);
            //DebugRectColor = Color.Red;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(EnvTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);


        }
    }
}
