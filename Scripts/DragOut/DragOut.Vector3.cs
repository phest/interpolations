// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using UnityEngine;

    public static partial class DragOutMethods
    {
        /// <summary> 
        /// <see cref="DragOut(float, float, float)"/>
        /// </summary>
        public static Vector3 DragOut(this Vector3 current, Vector3 target, float divisor)
        {
            return current + (target - current) / divisor;
        }

        /// <summary>
        /// <see cref="DragOut(float, float, float, float, out bool)"/>
        /// </summary>
        public static Vector3 DragOut(this Vector3 current, Vector3 target, float divisor, float snap, out bool snapped)
        {
            current = current.DragOut(target, divisor);
            if (snap > 0 && (current-target).magnitude < snap)
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
        /// <see cref="DragOut(float, float, float, float)"/>
        /// Version without final out parameter.
        /// </summary>
        public static Vector3 DragOut(this Vector3 current, Vector3 target, float divisor, float snap)
        {
            return DragOut(current, target, divisor, snap, out bool snapped);
        }
    }
}