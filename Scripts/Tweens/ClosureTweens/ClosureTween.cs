// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using System;

    public abstract class ClosureTween<T> : Tween<T>
    {
        public Func<T> Getter { get; set; }
        public Action<T> Setter { get; set; }
    }
}