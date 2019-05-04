// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    public interface ITween
    {
        void StartNonChainable();
        void Update(float timeDelta);
        TweenState State { get; }
    }
}
