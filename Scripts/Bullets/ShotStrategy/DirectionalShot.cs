using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalShot : MonoBehaviour,IShotStrategy
{
    private float shotAngle;
    private float shotAngleRate;
    [SerializeField] private float shotSpeed;
    [SerializeField] private Bullet bullet;
    Transform enemyTransform;
    public void Init(Vector3 position, Transform targetTransform, Transform enemyTransform)
    {
        this.enemyTransform = enemyTransform;
        transform.position = position;
        this.shotAngle = 0.75f;
        this.shotSpeed = 2.2f;
    }
    public void Action()
    {
        var v = Instantiate(bullet);
        v.Init(transform.position,shotSpeed,0,shotAngle,shotAngleRate);
    }

    [SerializeField] private float intervalTime;
    public float GetInterval()
    {
        return intervalTime;
    }
}
