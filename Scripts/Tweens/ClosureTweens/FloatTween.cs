// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using System;

    public class FloatTween : ClosureTween<float>
    {
        public FloatTween(Func<float> getter, Action<float> setter)
            : base(getter, setter)
        {
        }

        protected override void GetInitialValueFromSubject()
        {
            OriginValue = Getter?.Invoke() ?? 0;
        }

        protected override void ApplyCurrentValueToSubject()
        {
            Setter?.Invoke(OriginValue + (TargetValue - OriginValue) * ValueRatio);
        }
    }
}