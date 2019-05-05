// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using System;
    using UnityEngine;

    public static partial class Tweens
    {
        public static Tween<float> RunFloat(Func<float> getter, Action<float> setter, object uniqueBinding = null)
        {
            return Run(new FloatTween(getter, setter), uniqueBinding);
        }

        public static Tween<Vector3> RunVector3(Func<Vector3> getter, Action<Vector3> setter,
            object uniqueBinding = null)
        {
            return Run(new Vector3Tween(getter, setter), uniqueBinding);
        }

        public static Tween<Quaternion> RunQuaternion(Func<Quaternion> getter, Action<Quaternion> setter,
            object uniqueBinding = null)
        {
            return Run(new QuaternionTween(getter, setter), uniqueBinding);
        }

        public static Tween<Color> RunColor(Func<Color> getter, Action<Color> setter, object uniqueBinding = null)
        {
            return Run(new ColorTween(getter, setter), uniqueBinding);
        }

        public static Tween<Vector3> RunPosition(Transform transform, bool local = true, object uniqueBinding = null)
        {
            return Run(new PositionTween(transform, local), uniqueBinding);
        }

        public static Tween<Quaternion> RunRotation(Transform transform, bool local = true, object uniqueBinding = null)
        {
            return Run(new RotationTween(transform, local), uniqueBinding);
        }

        public static Tween<Vector3> RunScale(Transform transform, object uniqueBinding = null)
        {
            return Run(new ScaleTween(transform), uniqueBinding);
        }
    }
}