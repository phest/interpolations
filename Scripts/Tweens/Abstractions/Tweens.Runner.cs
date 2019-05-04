// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using UnityEngine;
    using System.Collections.Generic;

    public static partial class Tweens
    {
        public static T Run<T>(T tween, object uniqueBinding = null) where T : ITween
        {
            return Runner.SceneInstance.StartTween(tween, uniqueBinding);
        }

        class Runner : MonoBehaviour
        {
            static Runner _sceneInstance;

            public static Runner SceneInstance
            {
                get
                {
                    if (_sceneInstance == null)
                    {
                        _sceneInstance = new GameObject("[ Tweens ]").AddComponent<Runner>();
                    }

                    return _sceneInstance;
                }
            }

            readonly List<(ITween, object)> tweenBindingPairs = new List<(ITween, object)>();
            readonly Dictionary<object, ITween> tweenPerBinding = new Dictionary<object, ITween>();

            // Unique binding ensures only one tween bound to a specific object can tween at a given time
            public T StartTween<T>(T tween, object uniqueBinding = null) where T : ITween
            {
                tweenBindingPairs.Add((tween, uniqueBinding));
                tween.StartNonChainable();
                return tween;
            }

            void Update()
            {
                float deltaTime = Time.deltaTime;
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
}