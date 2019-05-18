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
}