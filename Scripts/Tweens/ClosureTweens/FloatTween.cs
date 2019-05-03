// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using System;
    
    public class FloatTween : ClosureTween<float>
    {
        public sealed override Func<float> Getter { get; set; }
        public sealed override  Action<float> Setter { get; set; }
        
        public FloatTween(Func<float> getter, Action<float> setter)
        {
            Getter = getter;
            Setter = setter;
        }
        
        protected override void SaveInitialValue()
        {
            InitialValue = Getter?.Invoke() ?? 0;
        }

        protected override void SetSubjectValue()
        {
            float currentValue = InitialValue + (TargetValue - InitialValue) * ValueRatio;
            Setter?.Invoke(currentValue);
        }
    }
}