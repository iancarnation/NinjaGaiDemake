using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaGaiDemake
{
    public class Enemy
    {
        // direction
        public enum Direction { LEFT = -1, RIGHT = 1 }
        public enum Behaviour { PATH = 0, COLLIDE = 1, FALL = 2, FOLLOW = 3 }
        public Direction dir;
        public Behaviour behaviour;
        // scale
        public float scale;
        // sprite
        public Texture2D tex;
        // position
        public Vector2 position;
        // speed
        float speed;
        // original width and height
        public int width, height;
        // new width anf height
        public float Width { get { return this.width * scale; } }
        public float Height { get { return this.height * scale; } }

        // bounding rectangle
        public BoundingRect boundingBox;

        // min and max distance for PATH
        Vector2 min, max;


        public Enemy() { }
        ~Enemy() { }

        // INIT //
        public void Initialize(Texture2D a_texture, Vector2 a_position)
        {
            tex = a_texture;
            position = a_position;

            speed = 1.5f;
            scale = 0.4f;

            // Change later if needed //
            width = tex.Width;
            height = tex.Height;

            boundingBox = new BoundingRect(position, Width, Height);

            dir = Direction.LEFT;
            behaviour = Behaviour.PATH;
        }

        public void SetPath(Vector2 setMin, Vector2 setMax, Vector2 setPos)
        {
            min = setMin;
            max = setMax;
            if (behaviour == Behaviour.PATH)
                position = setPos;
        }

        public void Update(float deltaTime)
        {
            // move enemy
            position.X += speed * (int)dir;
            // update bounding box
            boundingBox.UpdatePosition(new Vector2(position.X, position.Y));
            if (behaviour == Behaviour.PATH)
            {
                if (position.X < min.X)
                    dir = Direction.RIGHT;
                else if (position.X > max.X)
                    dir = Direction.LEFT;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}
