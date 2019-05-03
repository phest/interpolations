namespace Interpolations.Tweens
{
    /// <summary>
    /// Unlinked Tween, used only for its ValueRatio.
    /// </summary>
    public class RatioTween : Tween<float>
    {
        public override float InitialValue { get; set; }
        public override float TargetValue { get; set; }

        public override Tween<float> To(float target)
        {
            return this;
        }

        protected override void SaveInitialValue()
        {
        }
        
        protected override void SetSubjectValue()
        {
        }
    }
}