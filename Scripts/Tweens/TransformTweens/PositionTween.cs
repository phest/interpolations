// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using UnityEngine;

    public class PositionTween : Tween<Vector3>
    {
        readonly Transform subject;
        readonly bool local;

        public PositionTween(Transform subject, bool local = true)
        {
            this.subject = subject;
            this.local = local;
        }

        protected override void SaveInitialValue()
        {
            InitialValue = local ? subject.localPosition : subject.position;
        }

        protected override void SetSubjectValue()
        {
            Vector3 value = Vector3.LerpUnclamped(InitialValue, TargetValue, ValueRatio);
            if (local)
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