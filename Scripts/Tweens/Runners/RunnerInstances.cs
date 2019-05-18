// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

namespace Interpolations
{
    using UnityEngine;

    public static class Tweens
    {
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

        public static Runner Runner
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

        public static FixedRunner FixedRunner
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

        public static LateRunner LateRunner
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