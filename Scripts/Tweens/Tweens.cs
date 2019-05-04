﻿// Interpolations - https://github.com/phest/interpolations
// Copyright Steph Thirion - Licensed under the MIT license

using System.Security.Cryptography;

namespace Interpolations.Tweens
{
    using UnityEngine;

    public class Tweens
    {
        public static void Run(ITween tween, object uniqueBinding = null)
        {
            AutoTweensRunner.SceneInstance.StartTween(tween, uniqueBinding);
        }
    }
}