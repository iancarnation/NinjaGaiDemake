using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaGaiDemake
{
    public class Powerup
    {
        public Texture2D tex;
        public Vector2 position;
        public Rectangle boundingBox;
        public Color color;
        public BoundingRect BoundingBox
        {
            get
            {
                return new BoundingRect(position, boundingBox.Width, boundingBox.Height);
            }
        }
        public BoundingRect CollisionTop, CollisionBottom, CollisionLeft, CollisionRight;
        public bool Active = true;
        public Powerup() { }
        public Powerup(Texture2D setTex, Vector2 setPos, int width, int height, bool isActive)
        {
            color = Color.White;
            tex = setTex;
            boundingBox = new Rectangle(0, 0, width, height);
            SetPosition(setPos);
            Active = isActive;
        }
        public void SetPosition(Vector2 newPos)
        {
            position = newPos;
            boundingBox.X = (int)newPos.X;
            boundingBox.Y = (int)newPos.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(tex, boundingBox, color);
            }
            if (!Active)
            {
            }
        }

        /*public void Initialize(Texture2D m_tex, Vector2 m_setPos)
        {
            color = Color.White;

            tex = m_tex;
            position = m_setPos;
        }*/
        ~Powerup() { }
    }
}
