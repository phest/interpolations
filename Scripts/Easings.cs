// Easing equations Copyright (c) 2001 Robert Penner http://robertpenner.com/easing/
// Open source under the MIT License. See LICENSE file for details.

namespace Interpolations
{
    public static class I {

        public static float Linear(float k) {
            return k;
        }

        public static class Cubic
        {
            public static float In(float k) {
                return k * k * k;
            }
        
            public static float Out(float k) {
                return --k * k * k + 1;
            }
        
            public static float InOut(float k) {
                if ((k *= 2) < 1) return 0.5f * k * k * k;
                return 0.5f * ((k -= 2) * k * k + 2);
            }            
        }
        
    }
}
