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
            I.Ease ease = default,
            I.Easing easing = default
        )
        {
            Delay = delay;
            Duration = duration;
            Ease = ease;
            Easing = easing;
        }

        public TweenTiming(
            float duration,
            I.Ease ease = default,
            I.Easing easing = default
        ) : this(0, duration, ease, easing)
        {
        }

    }
}