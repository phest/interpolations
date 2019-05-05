
# Interpolations

Lightweight easing and tweening library for Unity 3D.

**API is currently experimental and may change.**

## Features

### Current features

- Easings
    - All Robert Penner easing equations, optimized
    - Easings API friendly with Unity's Lerps API
- Tweens
    - Lightweight and performant tweening suite
    - Tween class extendable with two one-line methods 
    - If needed, direct control over Tween instances and updating, 
      for specific memory and/or flow needs
    - Optional runner abstraction handling instances and updates
    - Optional abstraction sugar for different tweens 
    - Tween animations can be modified while tweening
    - Tween instances can be reused or yo-yo-ed
    - Tween easings configurable through editor
    - Pure tweens for tweens without side effects outside of instance
    - Closure tweens for custom tween instances (Float, Vector3, Color)    
    - Transform tweens for easy Transform control (Position, Rotation, Scale)

### Next features

- More closure tweens (Vector2, Quaternion)
- UniqueBinding in tween shortcuts
- Euler setter for RotationTween
- Documentation

### Possible future features

- Eased sliders (editor and UI)
- Bezier and CatmullRom Interpolations

## Examples

### Adding easing to a lerp call

```
Vector3.Lerp(a, b, ratio);
                     |
                     v
Vector3.Lerp(a, b, I.Cubic.InOut(ratio));
```

Check this [cheat sheet](https://easings.net/en) for the effect of the different equations.

### Tweening a position, the abstracted way

```
Tweens.Run(new PositionTween(transform))
      .To(targetPosition)
      .Timing(0, 1, I.Circ.InOut);
```

or

```
Tweens.RunPosition(transform)
      .To(targetPosition)
      .Timing(0, 1, I.Circ.InOut);
```

### Tweening a position, the controlling way

```
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

```
Tweens.Run
(
    new FloatTween
    (
        () => mixer.GetFloat("sfxVol", out float vol) ? vol : 0,
        vol =>
        {
            mixer.SetFloat("sfxVol", vol);
            indicator.alpha = vol;
        }
    )
)
.To(targetVolume)
.Timing(0, 1, I.Sine.Out);
```

```
Tweens.Run(new ColorTween(myScript.GetColor, myScript.SetColor))
      .To(Color.yellow)
      .Timing(0, 1, I.Cubic.InOut);
```

## Meta

By [Steph Thirion](http://trsp.net).

Easing equations by [Robert Penner](http://robertpenner.com/easing), optimized by [Tween.js authors](https://github.com/tweenjs/tween.js/).

All code open source under MIT License. See [LICENSE file](https://github.com/phest/interpolations/blob/master/LICENSE). 