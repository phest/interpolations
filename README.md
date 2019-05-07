
# Interpolations

Lightweight Unity library for smoothing movements and value progressions in code
(dragging, easing, tweening).

https://twitter.com/stephbysteph/status/1125462189450465280

**API is currently experimental and may change.**

## Current Features

- Drag outs
    - On the fly dampening of changes over time (float and Vector3)
    - Optional control and status of snapping
- Easings
    - Robert Penner easing equations, optimized
    - Easings methods pluggable to Unity's Lerp methods
- Tweens
    - Lightweight and flexible tweening suite
    - Tween class extendable with two one-line methods
    - If needed, direct control over Tween instances and updating,
      for specific requirements in update timing or instancing   
    - Optional runner abstraction handling instances and updates
    - Optional abstraction sugar for different tween types
    - Tween characteristics can be modified while tweening, for dynamic changes
    - Tween instances can be reused, yo-yo-ed, or recycled
    - Tween easings configurable through editor
    - Pure tweens for tweens without side effects
    - Closure tweens for custom tween instances (Float, Vector2-3, Quaternion, Color)
    - Convenience tweens for Transform control (Position, Rotation, Scale)

## Examples

### Smoothing out sudden value changes 

``` c#
// (Within an update call, i.e. FixedUpdate)
mixer.volume = Volume;
                 |
                 v
mixer.volume = mixer.volume.DragOut(Volume, 30);
```

### Adding easing to a lerp call

``` c#
Vector3.Lerp(a, b, ratio);
                     |
                     v
Vector3.Lerp(a, b, I.Cubic.InOut(ratio));
```

Check this [cheat sheet](https://easings.net/en) for the effect of the different equations.

### Tweening a position, the abstracted way

``` c#
Tweens.Run(new PositionTween(transform))
      .To(targetPosition)
      .Timing(0, 1, I.Circ.InOut);
```

or

``` c#
Tweens.RunPosition(transform)
      .To(targetPosition)
      .Timing(0, 1, I.Circ.InOut);
```

### Tweening a position, the controlling way

``` c#
Tween<Vector3> positionTween;
...
positionTween = new PositionTween(transform))
      .To(targetPosition)
      .Timing(0, 1, I.Circ.InOut)
      .Start();
...
// In Update, FixedUpdate, or etc
positionTween.Update(Time.timeDelta)

```

### Custom tweening instances

``` c#
Tweens.RunFloat
(
    () => mixer.GetFloat("sfxVol", out float vol) ? vol : 0,
    vol =>
    {
        mixer.SetFloat("sfxVol", vol);
        indicator.alpha = vol;
    }
)
.To(targetVolume)
.Timing(0, 1, I.Sine.Out);

```

``` c#
Tweens.Run(new ColorTween(myScript.GetColor, myScript.SetColor))
      .To(Color.yellow)
      .Timing(0, 1, I.Cubic.InOut);
```


## Features Roadmap

- Pre-setter value processor closure in Tween
- More drag out types (Color, Quaternion, Vector2, etc)
- More closure tween types (Vector4, etc)
- Documentation

### Possible features

- More convenience tweens for Unity classes (CanvasGroup, Image, etc)
- Eased sliders (editor and UI)
- Bezier and CatmullRom Interpolations

## Meta

Interpolations
https://github.com/phest/interpolations 

By [Steph Thirion](http://trsp.net).

Easing equations by [Robert Penner](http://robertpenner.com/easing), optimized by [Tween.js authors](https://github.com/tweenjs/tween.js/).

All code open source under MIT License. See [LICENSE file](https://github.com/phest/interpolations/blob/master/LICENSE). 

