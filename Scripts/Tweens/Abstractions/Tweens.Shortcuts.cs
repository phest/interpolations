// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using System;
    using UnityEngine;
    
    
    public static partial class Tweens
    {
        public static Tween<Color> RunColor(Func<Color> getter, Action<Color> setter)
        {
            return Run(new ColorTween(getter, setter));
        }
    }
}