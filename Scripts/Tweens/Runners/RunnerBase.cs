// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using UnityEngine;
    using System.Collections.Generic;

    public partial class RunnerBase : MonoBehaviour
    {
        readonly List<(ITween, object)> tweenBindingPairs = new List<(ITween, object)>();
        readonly Dictionary<object, ITween> tweenPerBinding = new Dictionary<object, ITween>();

        // Unique binding ensures only one tween bound to a specific object can tween at a given time (per runner)
        public T Run<T>(T tween, object uniqueBinding = null) where T : ITween
        {
            tweenBindingPairs.Add((tween, uniqueBinding));
            tween.StartNonChainable();
            return tween;
        }

        protected void UpdateTweens(float deltaTime)
        {
            // save initial count (in case callbacks add new tweens)
            int count = tweenBindingPairs.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                (ITween tween, object uniqueBinding) = tweenBindingPairs[i];
                TweenState previousState = tween.State;
                TweenState currentState = tween.Update(deltaTime);

                // if tween left delay, check for binding overwrite
                if (uniqueBinding != null && previousState == TweenState.InDelay && currentState > previousState)
                {
                    if (tweenPerBinding.ContainsKey(uniqueBinding))
                    {
                        ITween boundTween = tweenPerBinding[uniqueBinding];
                        tweenBindingPairs.Remove((boundTween, uniqueBinding));
                    }

                    tweenPerBinding[uniqueBinding] = tween;
                }

                if (currentState != TweenState.Done)
                {
                    continue;
                }

                tweenBindingPairs.RemoveAt(i);
                if (uniqueBinding != null)
                {
                    tweenPerBinding.Remove(uniqueBinding);
                }
            }
        }
    }
}