using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using VContainer;

class ShotStrategy
{
    public IShotStrategy shot;
    public void SetStrategy(IShotStrategy strategy)
    {
        shot = strategy;
    }
    public void Init(Vector3 position,Transform targetTransform,Transform enemyTransform)
    {
        shot.Init(position,targetTransform, enemyTransform);
    }
    public void Action()
    {
        shot.Action();
    }

    public float GetInterval()
    {
        return shot.GetInterval();
    }
}