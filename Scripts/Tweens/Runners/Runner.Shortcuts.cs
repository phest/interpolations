// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using System;
    using UnityEngine;

    public partial class RunnerBase
    {
        public Tween<float> RunFloat(Func<float> getter, Action<float> setter, object uniqueBinding = null)
        {
            return Run(new FloatTween(getter, setter), uniqueBinding);
        }

        public Tween<Vector2> RunVector2(Func<Vector2> getter, Action<Vector2> setter,
            object uniqueBinding = null)
        {
            return Run(new Vector2Tween(getter, setter), uniqueBinding);
        }
        
        public Tween<Vector3> RunVector3(Func<Vector3> getter, Action<Vector3> setter,
            object uniqueBinding = null)
        {
            return Run(new Vector3Tween(getter, setter), uniqueBinding);
        }

        public Tween<Quaternion> RunQuaternion(Func<Quaternion> getter, Action<Quaternion> setter,
            object uniqueBinding = null)
        {
            return Run(new QuaternionTween(getter, setter), uniqueBinding);
        }

        public Tween<Color> RunColor(Func<Color> getter, Action<Color> setter, object uniqueBinding = null)
        {
            return Run(new ColorTween(getter, setter), uniqueBinding);
        }

        public Tween<Vector3> RunPosition(Transform otherTransform, bool local = true, object uniqueBinding = null)
        {
            return Run(new PositionTween(otherTransform, local), uniqueBinding);
        }

        public Tween<Quaternion> RunRotation(Transform otherTransform, bool local = true, object uniqueBinding = null)
        {
            return Run(new RotationTween(otherTransform, local), uniqueBinding);
        }

        public Tween<Vector3> RunScale(Transform otherTransform, object uniqueBinding = null)
        {
            return Run(new ScaleTween(otherTransform), uniqueBinding);
        }
    }

    public static partial class Tweens
    {
        public static Tween<float> RunFloat(Func<float> getter, Action<float> setter, object uniqueBinding = null)
        {
            return Runner.RunFloat(getter, setter, uniqueBinding);
        }

        public static Tween<Vector2> RunVector2(Func<Vector2> getter, Action<Vector2> setter,
            object uniqueBinding = null)
        {
            return Runner.RunVector2(getter, setter, uniqueBinding);
        }
        
        public static Tween<Vector3> RunVector3(Func<Vector3> getter, Action<Vector3> setter,
            object uniqueBinding = null)
        {
            return Runner.RunVector3(getter, setter, uniqueBinding);
        }

        public static Tween<Quaternion> RunQuaternion(Func<Quaternion> getter, Action<Quaternion> setter,
            object uniqueBinding = null)
        {
            return Runner.RunQuaternion(getter, setter, uniqueBinding);
        }

        public static Tween<Color> RunColor(Func<Color> getter, Action<Color> setter, object uniqueBinding = null)
        {
            return Runner.RunColor(getter, setter, uniqueBinding);
        }

        public static Tween<Vector3> RunPosition(Transform otherTransform, bool local = true, object uniqueBinding = null)
        {
            return Runner.RunPosition(otherTransform, local, uniqueBinding);
        }

        public static Tween<Quaternion> RunRotation(Transform otherTransform, bool local = true, object uniqueBinding = null)
        {
            return Runner.RunRotation(otherTransform, local, uniqueBinding);
        }

        public static Tween<Vector3> RunScale(Transform otherTransform, object uniqueBinding = null)
        {
            return Runner.RunScale(otherTransform, uniqueBinding);
        }
    }
}