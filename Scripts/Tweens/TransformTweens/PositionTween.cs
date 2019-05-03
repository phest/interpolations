using System.Xml.Schema;
using UnityEngine;

namespace Interpolations.Tweens
{
    public class PositionTween : Tween<Vector3>
    {
        readonly Transform subject;
        
        public override Vector3 InitialValue { get; set; }
        public override Vector3 TargetValue { get; set; }

        public PositionTween(Transform subject)
        {
            this.subject = subject;
        }

        public override Tween<Vector3> To(Vector3 target)
        {
            TargetValue = target;
            return this;
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