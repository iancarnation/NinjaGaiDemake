//////  modified from http://www.java2s.com/Code/CSharp/Development-Class/BoundingRectangle.htm

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using System.Globalization;
using System.Runtime.InteropServices;

namespace NinjaGaiDemake
{
    /// <summary>
    /// Much like Rectangle, but uses float values
    /// </summary>
    public struct BoundingRect
    {
        public Vector2 Position;
        //public Vector2 Max;
        public float Width, Height;

        public float Left { get { return this.Position.X; } }
        public float Right { get { return this.Position.X + Width; } }
        public float Top { get { return this.Position.Y; } }
        public float Bottom { get { return this.Position.Y + Height; } }

        public bool isLadder;

        // debug rectangle to draw
        public Rectangle DebugRect;
        public Color DebugRectColor;

        //public float Width { get { return this.Right - this.Min.X; } }
        //public float Height { get { return this.Bottom - this.Min.Y; } }

        //public Vector2 Position { 
        //    get { return this.Min; } 
        //    set { this.Min = value; } 
        //}

        //private static BoundingRect mEmpty;
        //private static BoundingRect mMinMax;

        //static BoundingRect()
        //{
        //    BoundingRect.mEmpty = new BoundingRect();
        //    BoundingRect.mMinMax = new BoundingRect(Vector2.One * float.MinValue, Vector2.One * float.MaxValue);
        //}

        public Vector2 Center
        {
            get { return this.Position / 2; }
        }

        //public static BoundingRect Empty
        //{
        //    get { return BoundingRect.mEmpty; }
        //}


        //public static BoundingRect MinMax
        //{
        //    get { return BoundingRect.mMinMax; }
        //}

        //public bool IsZero
        //{
        //    get
        //    {
        //        return
        //            (this.Position.X == 0) &&
        //            (this.Position.Y == 0) &&
        //            (this.Right == 0) &&
        //            (this.Bottom == 0);
        //    }
        //}

        public BoundingRect(float x, float y, float width, float height)
        {
            this.Position.X = x;
            this.Position.Y = y;
            this.Width = width;
            this.Height = height;

            this.isLadder = false;

            DebugRect = new Rectangle((int)Position.X, (int)Position.Y, (int)width, (int)height);
            DebugRectColor = Color.Red;
        }

        public BoundingRect(Vector2 position, float width, float height)
        {
            this.Position = position;
            this.Width = width;
            this.Height = height;

            this.isLadder = false;

            DebugRect = new Rectangle((int)Position.X, (int)Position.Y, (int)width, (int)height);
            DebugRectColor = Color.Red;
        }

        public bool Contains(float x, float y)
        {
            return
                (this.Position.X <= x) &&
                (this.Position.Y <= y) &&
                (this.Right >= x) &&
                (this.Bottom >= y);
        }

        public bool Contains(Vector2 vector)
        {
            return
                (this.Position.X <= vector.X) &&
                (this.Position.Y <= vector.Y) &&
                (this.Right >= vector.X) &&
                (this.Bottom >= vector.Y);
        }

        public void Contains(ref Vector2 rect, out bool result)
        {
            result =
                (this.Position.X <= rect.X) &&
                (this.Position.Y <= rect.Y) &&
                (this.Right >= rect.X) &&
                (this.Bottom >= rect.Y);
        }

        public bool Contains(BoundingRect rect)
        {
            return
                (this.Position.X <= rect.Position.X) &&
                (this.Position.Y <= rect.Position.Y) &&
                (this.Right >= rect.Right) &&
                (this.Bottom >= rect.Bottom);
        }

        public void Contains(ref BoundingRect rect, out bool result)
        {
            result =
                (this.Position.X <= rect.Position.X) &&
                (this.Position.Y <= rect.Position.Y) &&
                (this.Right >= rect.Right) &&
                (this.Bottom >= rect.Bottom);
        }

        public bool Intersects(BoundingRect rect)
        {
            return
                (this.Position.X < rect.Right) &&
                (this.Position.Y < rect.Bottom) &&
                (this.Right > rect.Position.X) &&
                (this.Bottom > rect.Position.Y);
        }

        public void Intersects(ref BoundingRect rect, out bool result)
        {
            result =
                (this.Position.X < rect.Right) &&
                (this.Position.Y < rect.Bottom) &&
                (this.Right > rect.Position.X) &&
                (this.Bottom > rect.Position.Y);
        }

        //public static BoundingRect Intersect(BoundingRect rect1, BoundingRect rect2)
        //{
        //    BoundingRect result;

        //    float num8 = rect1.Right;
        //    float num7 = rect2.Right;
        //    float num6 = rect1.Bottom;
        //    float num5 = rect2.Bottom;
        //    float num2 = (rect1.Position.X > rect2.Position.X) ? rect1.Position.X : rect2.Position.X;
        //    float num = (rect1.Position.Y > rect2.Position.Y) ? rect1.Position.Y : rect2.Position.Y;
        //    float num4 = (num8 < num7) ? num8 : num7;
        //    float num3 = (num6 < num5) ? num6 : num5;

        //    if ((num4 > num2) && (num3 > num))
        //    {
        //        result.Position.X = num2;
        //        result.Position.Y = num;
        //        result.Right = num4;
        //        result.Bottom = num3;

        //        return result;
        //    }

        //    result.Position.X = 0;
        //    result.Position.Y = 0;
        //    result.Right = 0;
        //    result.Bottom = 0;

        //    return result;
        //}

        //public static void Intersect(ref BoundingRect rect1, ref BoundingRect rect2, out BoundingRect result)
        //{
        //    float num8 = rect1.Right;
        //    float num7 = rect2.Right;
        //    float num6 = rect1.Bottom;
        //    float num5 = rect2.Bottom;
        //    float num2 = (rect1.Position.X > rect2.Position.X) ? rect1.Position.X : rect2.Position.X;
        //    float num = (rect1.Position.Y > rect2.Position.Y) ? rect1.Position.Y : rect2.Position.Y;
        //    float num4 = (num8 < num7) ? num8 : num7;
        //    float num3 = (num6 < num5) ? num6 : num5;

        //    if ((num4 > num2) && (num3 > num))
        //    {
        //        result.Position.X = num2;
        //        result.Position.Y = num;
        //        result.Right = num4;
        //        result.Bottom = num3;
        //    }

        //    result.Position.X = 0;
        //    result.Position.Y = 0;
        //    result.Right = 0;
        //    result.Bottom = 0;
        //}

        //public static BoundingRect Union(BoundingRect rect1, BoundingRect rect2)
        //{
        //    BoundingRect result;

        //    float num6 = rect1.Right;
        //    float num5 = rect2.Right;
        //    float num4 = rect1.Bottom;
        //    float num3 = rect2.Bottom;
        //    float num2 = (rect1.Position.X < rect2.Position.X) ? rect1.Position.X : rect2.Position.X;
        //    float num = (rect1.Position.Y < rect2.Position.Y) ? rect1.Position.Y : rect2.Position.Y;
        //    float num8 = (num6 > num5) ? num6 : num5;
        //    float num7 = (num4 > num3) ? num4 : num3;

        //    result.Position.X = num2;
        //    result.Position.Y = num;
        //    result.Right = num8;
        //    result.Bottom = num7;

        //    return result;
        //}

        //public static void Union(ref BoundingRect rect1, ref BoundingRect rect2, out BoundingRect result)
        //{
        //    float num6 = rect1.Right;
        //    float num5 = rect2.Right;
        //    float num4 = rect1.Bottom;
        //    float num3 = rect2.Bottom;
        //    float num2 = (rect1.Position.X < rect2.Position.X) ? rect1.Position.X : rect2.Position.X;
        //    float num = (rect1.Position.Y < rect2.Position.Y) ? rect1.Position.Y : rect2.Position.Y;
        //    float num8 = (num6 > num5) ? num6 : num5;
        //    float num7 = (num4 > num3) ? num4 : num3;

        //    result.Position.X = num2;
        //    result.Position.Y = num;
        //    result.Right = num8;
        //    result.Bottom = num7;
        //}

        public bool Equals(BoundingRect other)
        {
            return
                (this.Position.X == other.Position.X) &&
                (this.Position.Y == other.Position.Y) &&
                (this.Right == other.Right) &&
                (this.Bottom == other.Bottom);
        }

        //public override int GetHashCode()
        //{
        //    return this.Position.GetHashCode() + this.Max.GetHashCode();
        //}

        public static bool operator ==(BoundingRect a, BoundingRect b)
        {
            return
                (a.Position.X == b.Position.X) &&
                (a.Position.Y == b.Position.Y) &&
                (a.Right == b.Right) &&
                (a.Bottom == b.Bottom);
        }

        public static bool operator !=(BoundingRect a, BoundingRect b)
        {
            return
                (a.Position.X != b.Position.X) ||
                (a.Position.Y != b.Position.Y) ||
                (a.Right != b.Right) ||
                (a.Bottom != b.Bottom);
        }

        public override bool Equals(object obj)
        {
            if (obj is BoundingRect)
            {
                return this == (BoundingRect)obj;
            }

            return false;
        }

        public void UpdateDebugRect()
        {
            this.DebugRect.X = (int)this.Position.X;
            this.DebugRect.Y = (int)this.Position.Y;
        }

        public void UpdatePosition(Vector2 newPos)
        {
            this.Position = newPos;
            // debug rectangle
            this.DebugRect.X = (int)newPos.X;
            this.DebugRect.Y = (int)newPos.Y;
        }
    }
}
