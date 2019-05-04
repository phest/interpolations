// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using UnityEngine;

    public class RotationTween : Tween<Quaternion>
    {
        readonly Transform subject;
        readonly bool local;

        public RotationTween(Transform subject, bool local = true)
        {
            this.subject = subject;
            this.local = local;
        }

        protected override void GetInitialValueFromSubject()
        {
            OriginValue = local ? subject.localRotation : subject.rotation;
        }

        protected override void ApplyCurrentValueToSubject()
        {
            Quaternion value = Quaternion.LerpUnclamped(OriginValue, TargetValue, ValueRatio);
            if (local)
            {
                subject.localRotation = value;
            }
            else
            {
                subject.rotation = value;
            }
        }
    }
}