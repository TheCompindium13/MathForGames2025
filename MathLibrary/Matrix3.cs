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
            { return new Matrix3(0.0f, 0.0f, 0.0f, 
                                 0.0f, 0.0f, 0.0f, 
                                 0.0f, 0.0f, 0.0f); 
            }
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
            return new Matrix3(a.M00 * b.M00 + a.M00 * b.M00 + a.M00 * b.M00, a.M00 * b.M01 + a.M00 * b.M01 + a.M00 * b.M01, a.M00 * b.M02 + a.M00 * b.M02 + a.M00 * b.M02,
           //-----------------|---------------------------------------------|----------------------------------------------|----------------------------------------------|    
                               a.M10 * b.M00 + a.M10 * b.M00 + a.M10 * b.M00, a.M10 * b.M01 + a.M10 * b.M01 + a.M10 * b.M01, a.M10 * b.M02 + a.M10 * b.M02 + a.M10 * b.M02,
           //-----------------|---------------------------------------------|----------------------------------------------|----------------------------------------------|
                               a.M20 * b.M00 + a.M20 * b.M00 + a.M20 * b.M00, a.M20 * b.M01 + a.M20 * b.M01 + a.M20 * b.M01, a.M20 * b.M02 + a.M20 * b.M02 + a.M20 * b.M02);
        }
    }
}
