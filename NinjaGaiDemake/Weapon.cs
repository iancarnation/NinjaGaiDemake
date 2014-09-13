using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaGaiDemake
{
    public class Weapon
    {
        public bool isActive;
        public float scale;

        public Color color;
        public Texture2D texture;

        public BoundingRect BoundingBox;

        public float Width { get { return this.width * scale; } } float width;

        public float Height { get { return this.height * scale; } } float height;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position;

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        Vector2 velocity;

        public void Initialize( Texture2D a_texture, Vector2 a_position)
        {
            isActive = false;

            texture = a_texture;
            color = Color.White;
            scale = 1f;

            Position = a_position;

            width = texture.Width;
            height = texture.Height;

            BoundingBox = new BoundingRect(this.Position.X, this.Position.Y, this.Width, this.Height);

        }

        public void Update(Vector2 a_position)
        {
            Position = a_position;
            BoundingBox.UpdatePosition(Position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

    }
}
