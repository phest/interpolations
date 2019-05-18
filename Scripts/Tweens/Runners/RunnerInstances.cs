// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using UnityEngine;

    public static partial class Tweens
    {
        public static T Run<T>(T tween, object uniqueBinding = null) where T : ITween
        {
            return Runner.Run(tween, uniqueBinding);
        }

        public static FixedRunner Fixed => FixedRunner;

        public static LateRunner Late => LateRunner;

        static GameObject _runnerHolder;

        static GameObject RunnersHolder
        {
            get
            {
                if (_runnerHolder == null)
                {
                    _runnerHolder = new GameObject("[ Tweens ]");
                }

                return _runnerHolder;
            }
        }

        static Runner _runnerInstance;

        static Runner Runner
        {
            get
            {
                if (_runnerInstance == null)
                {
                    _runnerInstance = RunnersHolder.AddComponent<Runner>();
                }

                return _runnerInstance;
            }
        }

        internal static void OnRunnerInstanceDestroy()
        {
            _runnerInstance = null;
        }

        static FixedRunner _fixedRunnerInstance;

        static FixedRunner FixedRunner
        {
            get
            {
                if (_fixedRunnerInstance == null)
                {
                    _fixedRunnerInstance = RunnersHolder.AddComponent<FixedRunner>();
                }

                return _fixedRunnerInstance;
            }
        }

        internal static void OnFixedRunnerInstanceDestroy()
        {
            _fixedRunnerInstance = null;
        }

        static LateRunner _lateRunnerInstance;

        static LateRunner LateRunner
        {
            get
            {
                if (_lateRunnerInstance == null)
                {
                    _lateRunnerInstance = RunnersHolder.AddComponent<LateRunner>();
                }

                return _lateRunnerInstance;
            }
        }

        internal static void OnLateRunnerInstanceDestroy()
        {
            _lateRunnerInstance = null;
        }
    }
}