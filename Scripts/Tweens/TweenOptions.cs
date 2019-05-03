// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using System;

    // Tween.Setup - optional struct for inspector convenience (hence mutable) 
    [Serializable]
    public struct TweenOptions
    {
        public float Delay;
        public float Duration;
        public I.Ease Ease;
        public I.Easing Easing;

        public TweenOptions(
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

        public TweenOptions(
            float duration,
            I.Ease ease = default,
            I.Easing easing = default
        ) : this(0, duration, ease, easing)
        {
        }
    }
}