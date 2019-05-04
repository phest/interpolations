﻿// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

using System;

namespace Interpolations.Tweens
{
    using UnityEngine;

    public class ColorTween : ClosureTween<Color>
    {
        public ColorTween(Func<Color> getter, Action<Color> setter)
        {
            Getter = getter;
            Setter = setter;
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