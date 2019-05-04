// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using System;

    // Optional struct for inspector convenience (hence mutable)
    [Serializable]
    public struct TweenTiming
    {
        public float Delay;
        public float Duration;
        public I.Ease Ease;
        public I.Easing Easing;

        public TweenTiming(
            float delay,
            float duration,
            I.Ease ease = I.Ease.InOut,
            I.Easing easing = I.Easing.Cubic
        )
        {
            Delay = delay;
            Duration = duration;
            Ease = ease;
            Easing = easing;
        }

        public TweenTiming(
            float duration,
            I.Ease ease = I.Ease.InOut,
            I.Easing easing = I.Easing.Cubic
        ) : this(0, duration, ease, easing)
        {
        }

    }
}