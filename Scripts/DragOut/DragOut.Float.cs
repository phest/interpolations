// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using UnityEngine;

    public static partial class DragOutMethods
    {
        /// <summary>
        /// Drags out a value. Useful to dampen magnitude of changes over time.
        /// <param name="divisor">
        /// Highest divisor, more drag.
        /// Recommended above 1.
        /// Can't be zero. 1 is no drag, and values less than 1 are unpredictable.
        /// </param>
        /// </summary>
        public static float DragOut(this float current, float target, float divisor)
        {
            return current + (target - current) / divisor;
        }

        /// <summary>
        /// Like <see cref="DragOut(float, float, float)"/>,
        /// but with <paramref name="snap"/> and <paramref name="snapped"/>.
        /// <param name="snap">
        /// Will stop dragging out if difference between current and target is smaller than this value.
        /// 0 or less doesn't snap.
        /// </param>
        /// <param name="snapped">
        /// Will be set to true when snapping is applied.
        /// </param>
        /// </summary>
        public static float DragOut(this float current, float target, float divisor, float snap, out bool snapped)
        {
            current = current.DragOut(target, divisor);
            if (snap > 0 && Mathf.Abs(current - target) < snap)
            {
                current = target;
                snapped = true;
            }
            else
            {
                snapped = false;
            }

            return current;
        }

        /// <summary>
        /// Like <see cref="DragOut(float, float, float, float, out bool)"/>, without snapped output.
        /// </summary>
        public static float DragOut(this float current, float target, float divisor, float snap)
        {
            // ReSharper disable once UnusedVariable
            return DragOut(current, target, divisor, snap, out bool snapped);
        }
    }
}