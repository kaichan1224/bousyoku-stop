using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShotStrategy
{
    void Init(Vector3 position,Transform targetTransform, Transform enemyTransform);
    void Action();
    float GetInterval();
}
