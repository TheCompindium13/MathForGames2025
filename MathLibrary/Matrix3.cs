using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Matrix3
    {
        public float M00, M01, M02, 
                     M10, M11, M12,
                     M20, M21, M22;

        public Matrix3(float m00, float m01, float m02, 
                       float m10, float m11, float m12, 
                       float m20, float m21, float m22)
        {

            M00 = m00; M01 = m01; M02 = m02;
            
            M10 = m10; M11 = m11; M12 = m12;
            
            M20 = m20; M21 = m21; M22 = m22;
        }
        public static Matrix3 Identity
        {
             
            get 
            { 
                return new Matrix3(1.0f, 0.0f, 0.0f, 
                                   0.0f, 1.0f, 0.0f, 
                                   0.0f, 0.0f, 1.0f); 
            }
        }
        public static Matrix3 CreateRotation(float radians)
        {
            return new Matrix3((float)Math.Cos(radians),(float)Math.Sin(-radians),0, 
                               (float)Math.Sin(radians),(float)Math.Cos(radians), 0,
                                0,                     0,                         1);
        }
        public static Matrix3 CreateTranslation(float x, float y)
        {
            return new Matrix3(1, 0, x,
                               0, 1, y,
                               0, 0, 1);
        }
        /// <summary>
        /// Creates scale through change x and y values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Matrix3 CreateScale(float x, float y)
        {
            return new Matrix3(x, y, 0,
                               0, 1, 0,
                               0, 0, 1);
        }
        public static Matrix3 operator +(Matrix3 a, Matrix3 b)
        {
            return new Matrix3(a.M00 + b.M00, a.M01 + b.M01, a.M02 + b.M02,
                               a.M10 + b.M10, a.M11 + b.M11, a.M12 + b.M12,
                               a.M20 + b.M20, a.M21 + b.M21, a.M22 + b.M22);
        }
        public static Matrix3 operator -(Matrix3 a, Matrix3 b)
        {
            return new Matrix3(a.M00 - b.M00, a.M01 - b.M01, a.M02 - b.M02,
                               a.M10 - b.M10, a.M11 - b.M11, a.M12 - b.M12,
                               a.M20 - b.M20, a.M21 - b.M21, a.M22 - b.M22);
        }
        public static Matrix3 operator *(Matrix3 a, Matrix3 b)
        {
            return new Matrix3(a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20, a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21, a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22,
           //-----------------|---------------------------------------------|----------------------------------------------|----------------------------------------------|    
                               a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20, a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21, a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22,
           //-----------------|---------------------------------------------|----------------------------------------------|----------------------------------------------|
                               a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20, a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21, a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22);
        }
        public static Vector3 operator *(Matrix3 a, Vector3 b)
        {
            return new Vector3(a.M00 * b.X + a.M01 * b.Y + a.M02 * b.Z,
                               a.M10 * b.X + a.M11 * b.Y + a.M12 * b.Z,
                               a.M20 * b.X + a.M21 * b.Y + a.M22 * b.Z);
        }
        // 1 = m00 | 2 = m01 | 3 = m02
        // 4 = m10 | 5 = m11 | 6 = m12
        // 7 = m20 | 8 = m21 | 9 = m22
    }
}
