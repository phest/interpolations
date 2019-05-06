// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using UnityEngine;
    using System;

    public class Vector2Tween : ClosureTween<Vector2>
    {
        public Vector2Tween (Func<Vector2> getter, Action<Vector2> setter)
        {
            Getter = getter;
            Setter = setter;
        }

        protected override void GetInitialValueFromSubject()
        {
            OriginValue = Getter?.Invoke() ?? Vector2.zero;
        }

        protected override void ApplyCurrentValueToSubject()
        {
            Setter?.Invoke(Vector2.LerpUnclamped(OriginValue, TargetValue, ValueRatio));
        }
    }
}