// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using System;

    public class FloatTween : ClosureTween<float>
    {
        public FloatTween(Func<float> getter, Action<float> setter)
        {
            Getter = getter;
            Setter = setter;
        }

        protected override void SaveInitialValue()
        {
            InitialValue = Getter?.Invoke() ?? 0;
        }

        protected override void SetSubjectValue()
        {
            Setter?.Invoke(InitialValue + (TargetValue - InitialValue) * ValueRatio);
        }
    }
}