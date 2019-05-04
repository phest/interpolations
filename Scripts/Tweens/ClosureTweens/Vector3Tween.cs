// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using UnityEngine;
    using System;

    public class Vector3Tween : ClosureTween<Vector3>
    {
        public Vector3Tween(Func<Vector3> getter, Action<Vector3> setter)
        {
            Getter = getter;
            Setter = setter;
        }

        protected override void GetInitialValueFromSubject()
        {
            OriginValue = Getter?.Invoke() ?? Vector3.zero;
        }

        protected override void ApplyCurrentValueToSubject()
        {
            Setter?.Invoke(Vector3.LerpUnclamped(OriginValue, TargetValue, ValueRatio));
        }
    }
}