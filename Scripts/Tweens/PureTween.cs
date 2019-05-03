// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    /// <summary>
    /// Unlinked Tween, no side effects (usable through its ValueRatio)
    /// </summary>
    public class PureTween : Tween<float>
    {
        protected override void SaveInitialValue()
        {
        }

        protected override void SetSubjectValue()
        {
        }
    }
}