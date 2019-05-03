// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using UnityEngine;
    
    public partial class TweenBase
    {
        public float Delay;
        public float Duration;
        
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

        public TweenBase(
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
        }

        public TweenBase(
            float duration,
            I.Ease ease = default(I.Ease),
            I.Easing easing = default(I.Easing)
        ) : this(0, duration, ease, easing)
        {
        }

        public TweenBase(TweenOptions options)
            : this(options.Delay, options.Duration, options.Ease, options.Easing)
        {   
        }

        float elapsedActiveTime;
        float tweenRatio;
        
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
                tweenRatio = 0;
            } 
            else if (elapsedActiveTime <= Delay + Duration)
            {
                if (State == TweenState.InDelay)
                {
                    State = TweenState.Tweening;
                }
                tween
                
                tweenRatio = (elapsedActiveTime - Delay) / Duration;
            }
            else
            {
                State = TweenState.Done;
                tweenRatio = 1;
            }
        }
        

    }    
    
}