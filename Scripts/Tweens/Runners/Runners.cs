// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using UnityEngine;

    public class Runner : RunnerBase
    {
        void Update()
        {
            UpdateTweens(Time.deltaTime);
        }

        void OnDestroy()
        {
            Tweens.OnRunnerInstanceDestroy();
        }
    }

    public class FixedRunner : RunnerBase
    {
        void FixedUpdate()
        {
            UpdateTweens(Time.deltaTime);
        }

        void OnDestroy()
        {
            Tweens.OnFixedRunnerInstanceDestroy();
        }
    }

    public class LateRunner : RunnerBase
    {
        void LateUpdate()
        {
            UpdateTweens(Time.deltaTime);
        }

        void OnDestroy()
        {
            Tweens.OnLateRunnerInstanceDestroy();
        }
    }
}