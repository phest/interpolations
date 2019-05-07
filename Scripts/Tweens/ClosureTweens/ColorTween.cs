// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using System;
    using UnityEngine;

    public class ColorTween : ClosureTween<Color>
    {
        public ColorTween(Func<Color> getter, Action<Color> setter)
            : base(getter, setter)
        {
        }

        protected override void GetInitialValueFromSubject()
        {
            OriginValue = Getter?.Invoke() ?? Color.black;
        }

        protected override void ApplyCurrentValueToSubject()
        {
            Setter?.Invoke(Color.LerpUnclamped(OriginValue, TargetValue, ValueRatio));
        }
    }
}