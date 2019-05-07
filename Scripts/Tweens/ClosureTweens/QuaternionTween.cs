// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using UnityEngine;
    using System;

    public class QuaternionTween : ClosureTween<Quaternion>
    {
        public QuaternionTween(Func<Quaternion> getter, Action<Quaternion> setter)
            : base(getter, setter)
        {
        }

        protected override void GetInitialValueFromSubject()
        {
            OriginValue = Getter?.Invoke() ?? Quaternion.identity;
        }

        protected override void ApplyCurrentValueToSubject()
        {
            Setter?.Invoke(Quaternion.LerpUnclamped(OriginValue, TargetValue, ValueRatio));
        }
    }
}