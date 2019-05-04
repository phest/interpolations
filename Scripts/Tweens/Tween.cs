// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using System;

    public abstract class Tween<T> : ITween
    {
        #region timing 

        public float Delay;
        public float Duration = 1;
        public I.EasingMethod EasingMethod = I.Cubic.InOut;

        public Tween<T> Timing(
            float delay,
            float duration,
            I.EasingMethod easingMethod
        )
        {
            Delay = delay;
            Duration = duration;
            EasingMethod = easingMethod;
            return this;
        }

        public Tween<T> Timing(
            float delay,
            float duration
        )
        {
            Delay = delay;
            Duration = duration;
            EasingMethod = I.Cubic.InOut;
            return this;
        }

        public Tween<T> Timing(TweenTiming timing)
        {
            return Timing(
                timing.Delay,
                timing.Duration,
                I.EasingMethods[(short) timing.Easing, (short) timing.Ease]
            );
        }

        #endregion

        #region origin and target

        public T TargetValue { get; set; }
        public T OriginValue { get; set; }

        public Tween<T> To(T target)
        {
            TargetValue = target;
            return this;
        }

        #endregion

        #region callbacks

        Action<Tween<T>> onBegin;
        Action<Tween<T>> onUpdate;
        Action<Tween<T>> onDone;

        public Tween<T> OnBegin(Action<Tween<T>> callback)
        {
            onBegin = callback;
            return this;
        }

        public Tween<T> OnUpdate(Action<Tween<T>> callback)
        {
            onUpdate = callback;
            return this;
        }

        public Tween<T> OnDone(Action<Tween<T>> callback)
        {
            onDone = callback;
            return this;
        }

        #endregion

        #region state control

        public TweenState State { get; private set; }

        float elapsedActiveTime;
        public float ValueRatio { get; private set; }

        public Tween<T> Start()
        {
            elapsedActiveTime = 0;

            State = TweenState.InDelay;

            return this;
        }

        public void StartNonChainable()
        {
            Start();
        }

        public TweenState Update(float timeDelta)
        {
            if (State == TweenState.NotStarted || State == TweenState.Done)
            {
                return State;
            }

            elapsedActiveTime += timeDelta;

            if (elapsedActiveTime <= Delay)
            {
                State = TweenState.InDelay;
                ValueRatio = 0;
                return State;
            }

            TweenState preCallbackState = State;

            if (State == TweenState.InDelay)
            {
                State = TweenState.Tweening;
                preCallbackState = State;

                GetInitialValueFromSubject();
                onBegin?.Invoke(this);
            }

            if (elapsedActiveTime < Delay + Duration)
            {
                float timingRatio = (elapsedActiveTime - Delay) / Duration;
                ValueRatio = EasingMethod?.Invoke(timingRatio) ?? timingRatio;
                ApplyCurrentValueToSubject();
                onUpdate?.Invoke(this);
            }
            else
            {
                State = TweenState.Done;
                preCallbackState = State;

                ValueRatio = 1;
                ApplyCurrentValueToSubject();
                onUpdate?.Invoke(this);
                onDone?.Invoke(this);
            }

            return preCallbackState;
        }

        protected abstract void GetInitialValueFromSubject();
        protected abstract void ApplyCurrentValueToSubject();

        #endregion
    }
}