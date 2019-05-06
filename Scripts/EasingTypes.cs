// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    public static partial class I
    {
        public enum Ease
        {
            InOut,
            In,
            Out
        }

        public enum Easing
        {
            Linear,
            Sine,
            Quad,
            Cubic,
            Quart,
            Quint,
            Expo,
            Back,
            Elastic,
            Circ,
            Bounce
        }

        public delegate float EasingMethod(float k);

        // maps enum to methods 
        public static readonly EasingMethod[,] EasingMethods = new EasingMethod[,]
        {
            {Linear, Linear, Linear},
            {Sine.InOut, Sine.In, Sine.Out},
            {Quad.InOut, Quad.In, Quad.Out},
            {Cubic.InOut, Cubic.In, Cubic.Out},
            {Quart.InOut, Quart.In, Quart.Out},
            {Quint.InOut, Quint.In, Quint.Out},
            {Expo.InOut, Expo.In, Expo.Out},
            {Back.InOut, Back.In, Back.Out},
            {Elastic.InOut, Elastic.In, Elastic.Out},
            {Circ.InOut, Circ.In, Circ.Out},
            {Bounce.InOut, Bounce.In, Bounce.Out},
        };

        public static EasingMethod GetEasingMethod(Easing easing, Ease ease)
        {
            return EasingMethods[(short) easing, (short) ease];
        }
    }
}