// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using System;
    using UnityEngine;

    public static partial class Tweens
    {
        public static Tween<float> RunFloat(Func<float> getter, Action<float> setter)
        {
            return Run(new FloatTween(getter, setter));
        }

        public static Tween<Vector3> RunVector3(Func<Vector3> getter, Action<Vector3> setter)
        {
            return Run(new Vector3Tween(getter, setter));
        }

        public static Tween<Color> RunColor(Func<Color> getter, Action<Color> setter)
        {
            return Run(new ColorTween(getter, setter));
        }
        
        public static Tween<Vector3> RunPosition(Transform transform, bool local = true)
        {
            return Run(new PositionTween(transform, local));
        }
        
        public static Tween<Quaternion> RunRotation(Transform transform, bool local = true)
        {
            return Run(new RotationTween(transform, local));
        }
        
        public static Tween<Vector3> RunScale(Transform transform)
        {
            return Run(new ScaleTween(transform));
        }
    }
}