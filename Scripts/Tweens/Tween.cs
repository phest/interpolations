// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    public abstract class Tween<T>
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
            easingMethod = I.EasingMethods[(short) _easing, (short) _ease];
        }

        public T TargetValue { get; set; }
        public T InitialValue { get; set; }

        public Tween<T> To(T target)
        {
            TargetValue = target;
            return this;
        }

        public Tween<T> Timing(
            float delay,
            float duration,
            I.Ease ease = default,
            I.Easing easing = default
        )
        {
            Delay = delay;
            Duration = duration;
            _ease = ease;
            _easing = easing;
            UpdateEasingMethod();
            return this;
        }

        public Tween<T> Timing(TweenTiming timing)
        {
            return Timing(timing.Delay, timing.Duration, timing.Ease, timing.Easing);
        }

        float elapsedActiveTime;
        public float ValueRatio { get; private set; }

        public TweenState State { get; private set; }

        public Tween<T> Start()
        {
            elapsedActiveTime = 0;

            State = TweenState.InDelay;

            return this;
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
                return;
            }

            if (elapsedActiveTime <= Delay + Duration)
            {
                if (State == TweenState.InDelay)
                {
                    State = TweenState.Tweening;
                    SaveInitialValue();
                }

                float timingRatio = (elapsedActiveTime - Delay) / Duration;
                ValueRatio = easingMethod?.Invoke(timingRatio) ?? timingRatio;
            }
            else
            {
                State = TweenState.Done;
                ValueRatio = 1;
            }

            SetSubjectValue();
        }

        protected abstract void SaveInitialValue();
        protected abstract void SetSubjectValue();
    }
}