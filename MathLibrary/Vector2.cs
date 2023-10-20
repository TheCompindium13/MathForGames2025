﻿namespace MathLibrary
{
    public struct Vector2
    {
        private float _x;
        private float _y;

        public float X
        {
            get { return _x; }
            set { _x = value; } 
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }
        /// <summary>
        /// change the size of the vector to have a length of 1
        /// </summary>
        public void normalize()
        {

        }
        /// <summary>
        /// divide the vector by the amplitude to get a vector with an amplitude of 1
        /// </summary>
        /// <returns>
        /// </returns> normalized vector that points in same direction
        public Vector2 GetNormalized()
        {
            return new Vector2();
        }
        public float GetMagnitude()
        {
            return MathF.Sqrt(X * X + Y * Y);
        }
        /// <summary>
        /// Create overloaded operators for subtracting a vector 
        /// from another vector,
        /// multiplying a vector by a scalar
        /// and dividing a vector by a scalar.
        /// 
        /// Create a new class called player.
        /// The class should override the update function
        /// and change the position based on player input.
        /// </summary>

        public static Vector2 operator + (Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Vector2 operator - (Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static Vector2 operator * (Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.X * scalar, lhs.Y * scalar);
        }

        public static Vector2 operator / (Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.X * scalar, lhs.Y * scalar);
        }
    }
}