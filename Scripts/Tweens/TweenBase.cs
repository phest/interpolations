// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using UnityEngine;
    
    public partial class TweenBase
    {
        public float Delay;
        public float Duration = 1;
        
        I.Ease _ease;
        public I.Ease Ease
        {
            get => _ease;
            set
            {
                if (_ease == value)
                {
                    return;
                }
                _ease = value;
                UpdateEasingMethod();
            }
        }
        
        I.Easing _easing;
        public I.Easing Easing
        {
            get => _easing;
            set
            {
                if (_easing == value)
                {
                    return;
                }
                _easing = value;
                UpdateEasingMethod();
            }
        }
        I.EasingMethod easingMethod;

        void UpdateEasingMethod()
        {
            easingMethod = I.EasingMethods[(short)_easing, (short)_ease];
        }

        public TweenBase()
        {
        }

        public TweenBase Timing(
            float delay,
            float duration,
            I.Ease ease = default(I.Ease),
            I.Easing easing = default(I.Easing)
        )
        {
            Delay = delay;
            Duration = duration;
            _ease = ease;
            _easing = easing;
            UpdateEasingMethod();
            return this;
        }

        public TweenBase Timing(TweenOptions options)
        {
            return Timing(options.Delay, options.Duration, options.Ease, options.Easing);
        }

        float elapsedActiveTime;
        public float ValueRatio { get; private set; } = 0;
        
        public TweenState State { get; private set; } = default(TweenState);
        
        public void Start()
        {
            elapsedActiveTime = 0;
            
            State = TweenState.InDelay;
        }
        
        public void Update(float timeDelta)
        {
            if (State == TweenState.NotStarted || State == TweenState.Done)
            {
                return;
            }

            elapsedActiveTime += timeDelta;
            
            if (elapsedActiveTime <= Delay)
            {
                State = TweenState.InDelay;
                ValueRatio = 0;
            } 
            else if (elapsedActiveTime <= Delay + Duration)
            {
                if (State == TweenState.InDelay)
                {
                    State = TweenState.Tweening;
                }

                float timingRatio = (elapsedActiveTime - Delay) / Duration;
                ValueRatio = easingMethod?.Invoke(timingRatio) ?? timingRatio;
            }
            else
            {
                State = TweenState.Done;
                ValueRatio = 1;
            }
        }
        
    }    
    
}