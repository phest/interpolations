// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations.Tweens
{
    using UnityEngine;
    using System.Collections.Generic;

    public class AutoTweensRunner : MonoBehaviour
    {
        static AutoTweensRunner _sceneInstance;

        public static AutoTweensRunner SceneInstance
        {
            get
            {
                if (_sceneInstance == null)
                {
                    _sceneInstance = new GameObject("[ Tweens ]").AddComponent<AutoTweensRunner>();
                }

                return _sceneInstance;
            }
        }

        readonly List<(ITween, object)> tweenBindingPairs = new List<(ITween, object)>();
        readonly Dictionary<object, ITween> tweenPerBinding = new Dictionary<object, ITween>();

        public void StartTween(ITween tween, object uniqueBinding = null)
        {
            tweenBindingPairs.Add((tween, uniqueBinding));
            tween.StartNonChainable();
        }

        void Update()
        {
            float deltaTime = Time.deltaTime;
            // save initial count (in case callbacks add new tweens)
            int count = tweenBindingPairs.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                (ITween, object) pair = tweenBindingPairs[i];
                ITween tween = pair.Item1;
                object uniqueBinding = pair.Item2;

                TweenState previousState = tween.State;
                tween.Update(deltaTime);
                TweenState currentState = tween.State;

                // if tween left delay, check for binding replacement
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