// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using UnityEngine;
    
    public class PositionTween : Tween<Vector3>
    {
        readonly Transform subject;
        readonly bool localPosition;

        public PositionTween(Transform subject, bool localPosition = true)
        {
            this.subject = subject;
            this.localPosition = localPosition;
        }

        protected override void SaveInitialValue()
        {
            InitialValue = localPosition ? subject.localPosition : subject.position;
        }

        protected override void SetSubjectValue()
        {
            Vector3 value = InitialValue + (TargetValue - InitialValue) * ValueRatio;
            if (localPosition)
            {
                subject.localPosition = value;
            }
            else
            {
                subject.position = value;
            }
        }
    }
}