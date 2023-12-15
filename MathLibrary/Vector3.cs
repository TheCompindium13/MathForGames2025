using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Vector3
    {
        private float _x;
        private float _y;
        private float _z;



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
        public float Z
        {
            get { return _z; }
            set { _z = value; }
        }
        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
        /// <summary>
        /// Returns the cross product of the two vectors given.
        /// </summary>
        public static Vector3 CrossProduct(Vector3 a, Vector3 b)
        {
            return new Vector3(a.Y * b.Z - a.Z * b.Y,
                               a.Z * b.X - a.X * b.Z, 
                               a.X * b.Y - a.Y * b.X);
        }
        /// <summary>
        /// change the size of the vector to have a length of 1
        /// </summary>
        public void Normalize()
        {
            float Magnitude = GetMagnitude();

            if (Magnitude == 0)
            {
                return;
            }

            X /= Magnitude;
            Y /= Magnitude;
            Z /= Magnitude;
        }
        /// <summary>
        /// divide the vector by the amplitude to get a vector with an amplitude of 1
        /// </summary>
        /// <returns>
        /// </returns> normalized vector that points in same direction
        public Vector3 GetNormalized()
        {
            float Magnitude = GetMagnitude();

            if (Magnitude == 0)
            {
                return new Vector3();
            }

            return new Vector3(X / Magnitude, Y / Magnitude, Z / Magnitude);

        }
        /// <summary>
        /// Returns the dot product of the two vectors given.
        /// </summary>
        public static float DotProduct(Vector3 a, Vector3 b)
        {
            float dot = a.X * b.X + a.Y * b.Y + a.Z * b.Z;
            return dot;
        }
        /// <summary>
        /// Returns the difference of the two vectors given.
        /// </summary>
        public static float GetDistance(Vector3 a, Vector3 b)
        {
            return (a - b).GetMagnitude();
        }
        /// <summary>
        /// Returns the length of the vector.
        /// </summary>
        public float GetMagnitude()
        {
            return MathF.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        public static Vector3 operator *(float scalar, Vector3 lhs)
        {
            return new Vector3(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar);
        }
        public static Vector3 operator *(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar);
        }

        public static Vector3 operator / (Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar);
        }
    }
}
