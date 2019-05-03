// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using UnityEngine;
    
    public class PositionTween : Tween<Vector3>
    {
        readonly Transform subject;

        public PositionTween(Transform subject)
        {
            this.subject = subject;
        }

        protected override void SaveInitialValue()
        {
            InitialValue = subject.position;
        }

        protected override void SetSubjectValue()
        {
            subject.position = InitialValue + (TargetValue - InitialValue) * ValueRatio;
        }
    }
}