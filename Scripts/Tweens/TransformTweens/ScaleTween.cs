// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using UnityEngine;
    
    public class ScaleTween : Tween<Vector3>
    {
        readonly Transform subject;

        public ScaleTween(Transform subject)
        {
            this.subject = subject;
        }

        protected override void GetInitialValueFromSubject()
        {
            OriginValue = subject.localScale;
        }

        protected override void ApplyCurrentValueToSubject()
        {
            subject.localScale = Vector3.LerpUnclamped(OriginValue, TargetValue, ValueRatio);
        }
    }
}