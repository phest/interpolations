// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license
//
// Easing equations open source under MIT License:
// Copyright (c) 2001 Robert Penner, http://robertpenner.com/easing
// Copyright (c) 2010-2012 Tween.js authors, https://github.com/tweenjs/tween.js
//
// See LICENSE file for details.

using System;

namespace Interpolations
{
    using UnityEngine;

    public static partial class I
    {
        public static float Linear(float k)
        {
            return k;
        }

        public static class Quad
        {
            public static float In(float k)
            {
                return k * k;
            }

            public static float Out(float k)
            {
                return k * (2 - k);
            }

            public static float InOut(float k)
            {
                if ((k *= 2) < 1)
                {
                    return 0.5f * k * k;
                }

                return -0.5f * (--k * (k - 2) - 1);
            }
        }

        public static class Sine
        {
            public static float In(float k)
            {
                return 1 - Mathf.Cos(k * Mathf.PI / 2);
            }

            public static float Out(float k)
            {
                return Mathf.Sin(k * Mathf.PI / 2);
            }

            public static float InOut(float k)
            {
                return 0.5f * (1 - Mathf.Cos(Mathf.PI * k));
            }
        }

        public static class Cubic
        {
            public static float In(float k)
            {
                return k * k * k;
            }

            public static float Out(float k)
            {
                return --k * k * k + 1;
            }

            public static float InOut(float k)
            {
                if ((k *= 2) < 1)
                {
                    return 0.5f * k * k * k;
                }

                return 0.5f * ((k -= 2) * k * k + 2);
            }
        }

        public static class Quart
        {
            public static float In(float k)
            {
                return k * k * k * k;
            }

            public static float Out(float k)
            {
                return 1 - (--k * k * k * k);
            }

            public static float InOut(float k)
            {
                if ((k *= 2) < 1)
                {
                    return 0.5f * k * k * k * k;
                }

                return -0.5f * ((k -= 2) * k * k * k - 2);
            }
        }

        public static class Quint
        {
            public static float In(float k)
            {
                return k * k * k * k * k;
            }

            public static float Out(float k)
            {
                return --k * k * k * k * k + 1;
            }

            public static float InOut(float k)
            {
                if ((k *= 2) < 1)
                {
                    return 0.5f * k * k * k * k * k;
                }

                return 0.5f * ((k -= 2) * k * k * k * k + 2);
            }
        }

        public static class Back
        {
            public static float In(float k)
            {
                const float s = 1.70158f;

                return k * k * ((s + 1) * k - s);
            }

            public static float Out(float k)
            {
                const float s = 1.70158f;

                return --k * k * ((s + 1) * k + s) + 1;
            }

            public static float InOut(float k)
            {
                const float s = 1.70158f * 1.525f;

                if ((k *= 2) < 1)
                {
                    return 0.5f * (k * k * ((s + 1) * k - s));
                }

                return 0.5f * ((k -= 2) * k * ((s + 1) * k + s) + 2);
            }
        }

        public static class Elastic
        {
            public static float In(float k)
            {
                switch (k)
                {
                    case 0:
                        return 0;
                    case 1:
                        return 1;
                    default:
                        return -Mathf.Pow(2, 10 * (k - 1)) * Mathf.Sin((k - 1.1f) * 5 * Mathf.PI);
                }
            }

            public static float Out(float k)
            {
                switch (k)
                {
                    case 0:
                        return 0;
                    case 1:
                        return 1;
                    default:
                        return Mathf.Pow(2, -10 * k) * Mathf.Sin((k - 0.1f) * 5 * Mathf.PI) + 1;
                }
            }

            public static float InOut(float k)
            {
                switch (k)
                {
                    case 0:
                        return 0;
                    case 1:
                        return 1;
                    default:
                        k *= 2;

                        if (k < 1)
                        {
                            return -0.5f * Mathf.Pow(2, 10 * (k - 1)) * Mathf.Sin((k - 1.1f) * 5 * Mathf.PI);
                        }

                        return 0.5f * Mathf.Pow(2, -10 * (k - 1)) * Mathf.Sin((k - 1.1f) * 5 * Mathf.PI) + 1;
                }
            }
        }

        public static class Circ
        {
            public static float In(float k)
            {
                return 1 - Mathf.Sqrt(1 - k * k);
            }

            public static float Out(float k)
            {
                return Mathf.Sqrt(1 - (--k * k));
            }

            public static float InOut(float k)
            {
                if ((k *= 2) < 1)
                {
                    return -0.5f * (Mathf.Sqrt(1 - k * k) - 1);
                }

                return 0.5f * (Mathf.Sqrt(1 - (k -= 2) * k) + 1);
            }
        }

        public static class Bounce
        {
            public static float In(float k)
            {
                return 1 - Out(1 - k);
            }

            public static float Out(float k)
            {
                if (k < (1 / 2.75f))
                {
                    return 7.5625f * k * k;
                }

                if (k < (2 / 2.75f))
                {
                    return 7.5625f * (k -= (1.5f / 2.75f)) * k + 0.75f;
                }

                if (k < (2.5f / 2.75))
                {
                    return 7.5625f * (k -= (2.25f / 2.75f)) * k + 0.9375f;
                }

                return 7.5625f * (k -= (2.625f / 2.75f)) * k + 0.984375f;
            }

            public static float InOut(float k)
            {
                if (k < 0.5f)
                {
                    return In(k * 2) * 0.5f;
                }

                return Out(k * 2 - 1) * 0.5f + 0.5f;
            }
        }
    }
}