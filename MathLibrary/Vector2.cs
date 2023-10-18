namespace MathLibrary
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

        public float GetMagnitude()
        {

            float result = MathF.Sqrt(X * X + Y * Y);


            return result;
            
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