using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Matrix4
    {
        public float M00, M01, M02, M03,
                     M10, M11, M12, M13,
                     M20, M21, M22, M23,
                     M30, M31, M32, M33;

        public Matrix4(float m00, float m01, float m02, float m03,
                       float m10, float m11, float m12, float m13,
                       float m20, float m21, float m22, float m23,
                       float m30, float m31, float m32, float m33)
        {

            M00 = m00; M01 = m01; M02 = m02; M03 = m03; 

            M10 = m10; M11 = m11; M12 = m12; M13 = m13;

            M20 = m20; M21 = m21; M22 = m22; M23 = m23;
            
            M30 = m30; M31 = m31; M32 = m32; M33 = m33;
        }
        public static Matrix4 Identity
        {

            get
            {
                return new Matrix4(1.0f, 0.0f, 0.0f, 0.0f,
                                   0.0f, 1.0f, 0.0f, 0.0f,
                                   0.0f, 0.0f, 1.0f, 0.0f,
                                   0.0f, 0.0f, 0.0f, 1.0f);
            }
        }
        /// <summary>
        /// Creates a matrix thats been rotated by the given amount of radians on the x axis.
        /// </summary>
        /// <returns></returns>
        public static Matrix4 CreateRotationX(float radians)
        {
            return new Matrix4(1.0f,                     0.0f,                     0.0f,  0.0f,
                               0.0f, (float)Math.Cos(radians), (float)Math.Sin(-radians),  0.0f,
                               0.0f, (float)Math.Sin(radians), (float)Math.Cos(radians), 0.0f,
                               0.0f,                      0.0f,                     0.0f, 1.0f);
        }
        /// <summary>
        /// Creates a matrix thats been rotated by the given amount of radians on the y axis.
        /// </summary>
        /// <returns></returns>
        public static Matrix4 CreateRotationY(float radians)
        {
            return new Matrix4((float)Math.Cos(radians), 0.0f, (float)Math.Sin(radians), 0.0f,
                               0.0f,               1.0f, 0.0f,                            0.0f,
                               (float)Math.Sin(-radians), 0.0f, (float)Math.Cos(radians),  0.0f,
                               0.0f,               0.0f, 0.0f, 1.0f);
        }
        /// <summary>
        /// Creates a matrix thats been rotated by the given amount of radians on the z axis.
        /// </summary>
        /// <returns></returns>
        public static Matrix4 CreateRotationZ(float radians)
        {
            return new Matrix4((float)Math.Cos(radians), (float)Math.Sin(-radians), 0.0f, 0.0f,
                               (float)Math.Sin(radians), (float)Math.Cos(radians), 0.0f, 0.0f,
                               0.0f, 0.0f, 1.0f, 0.0f,
                               0.0f, 0.0f, 0.0f, 1.0f);
        }

        /// <summary>
        /// Creates a matrix thats been rotated by the given amount of radians
        ///on the y axis.
        /// </summary>
        /// <returns></returns>
        public static Matrix4 CreateTranslation(float x, float y,float z)
        {
            return new Matrix4(1, 0, 0, x,
                               0, 1, 0, y,
                               0, 0, 1, z,
                               0, 0, 0, 1);
        }
        /// <summary>
        /// Creates a matrix thats been scaled by the given vector.
        /// </summary>
        /// <returns></returns>
        public static Matrix4 CreateScale(float x, float y, float z)
        {
            return new Matrix4(x, 0, 0, 0,
                               0, y, 0, 0,
                               0, 0, z, 0,
                               0, 0, 0, 1);
        }
        public static Matrix4 operator +(Matrix4 a, Matrix4 b)
        {
            return new Matrix4(a.M00 + b.M00, a.M01 + b.M01, a.M02 + b.M02, a.M03 + b.M03,
                               a.M10 + b.M10, a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13,
                               a.M20 + b.M20, a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23,
                               a.M30 + b.M30, a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33);

        }
        public static Matrix4 operator -(Matrix4 a, Matrix4 b)
        {
            return new Matrix4(a.M00 - b.M00, a.M01 - b.M01, a.M02 - b.M02, a.M03 - b.M03,
                               a.M10 - b.M10, a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13,
                               a.M20 - b.M20, a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23,
                               a.M30 - b.M30, a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33);
        }
        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            return new Matrix4(a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20 + a.M03 * b.M30, a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21 + a.M03 * b.M31, a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22 + a.M03 * b.M32, a.M00 * b.M03 + a.M01 * b.M13 + a.M02 * b.M23 + a.M03 * b.M33,
                               //-----------------------------------------------------------|--------------------------------------------------------------|--------------------------------------------------------------|--------------------------------------------------------------|    
                               a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20 + a.M13 * b.M30, a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31, a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32, a.M10 * b.M03 + a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,
                               //-----------------------------------------------------------|--------------------------------------------------------------|--------------------------------------------------------------|--------------------------------------------------------------|
                               a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20 + a.M23 * b.M30, a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31, a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32, a.M20 * b.M03 + a.M12 * b.M13 + a.M23 * b.M23 + a.M23 * b.M33,
                               //-----------------------------------------------------------|--------------------------------------------------------------|--------------------------------------------------------------|--------------------------------------------------------------|
                               a.M30 * b.M00 + a.M31 * b.M10 + a.M32 * b.M20 + a.M33 * b.M30, a.M30 * b.M01 + a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31, a.M30 * b.M02 + a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32, a.M30 * b.M03 + a.M13 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33);
        }
        public static Vector4 operator *(Matrix4 a, Vector4 b)
        {
            return new Vector4(a.M00 * b.X + a.M01 * b.Y + a.M02 * b.Z + a.M03 * b.W,
                               a.M10 * b.X + a.M11 * b.Y + a.M12 * b.Z + a.M13 * b.W,
                               a.M20 * b.X + a.M21 * b.Y + a.M22 * b.Z + a.M23 * b.W,
                               a.M30 * b.X + a.M31 * b.Y + a.M32 * b.Z + a.M33 * b.W);
        }
                               // 01 = m00 | 02 = m01 | 03 = m02 | 04 = m03
                               // 05 = m10 | 06 = m11 | 07 = m12 | 08 = m13
                               // 09 = m20 | 10 = m21 | 11 = m22 | 12 = m23
                               // 13 = m30 | 14 = m31 | 15 = m32 | 16 = m33

    }
}
