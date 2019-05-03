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
            Cubic,
            Linear   
        }

        public delegate float EasingMethod(float k);

        // maps enum to methods 
        public static readonly EasingMethod[,] EasingMethods = new EasingMethod[,]
        {
            {Cubic.InOut, Cubic.In, Cubic.Out},
            {Linear, Linear, Linear}
        };

        public static EasingMethod GetEasingMethod(Easing easing, Ease ease)
        {
            return EasingMethods[(short) easing, (short) ease];
        }
    }
}