// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using System;

    public abstract class ClosureTween<T> : Tween<T>
    {
        public abstract Func<T> Getter { get; set; }
        public abstract Action<T> Setter { get; set; }
    }
}