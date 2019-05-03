// Easing equations Copyright (c) 2001 Robert Penner http://robertpenner.com/easing/
// Open source under the MIT License. See LICENSE file for details.

// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    public static partial class I {

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
        
            public static float InOut(float k)
            {
                k *= 2;
                if (k < 1)
                {
                    return 0.5f * k * k * k;
                }
                k -= 2;
                return 0.5f * (k * k * k + 2);
            }
        }
        
    }
}
