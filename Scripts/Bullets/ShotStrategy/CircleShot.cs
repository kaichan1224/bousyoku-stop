using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShot : MonoBehaviour,IShotStrategy
{
    [SerializeField] private float shotAngle;
    [SerializeField] private float shotAngleRate;
    [SerializeField] private float bulletAngleRate;
    [SerializeField] private float bulletSpeedRate;
    [SerializeField] private int shotCount;
    [SerializeField] private float angleRange;
    Transform enemyTransform;
    [SerializeField] private float shotSpeed;
    [SerializeField] private Bullet bullet;
    public void Init(Vector3 position, Transform targetTransform, Transform enemyTransform)
    {
        this.enemyTransform = enemyTransform;
        transform.position = position;
        shotAngle = -0.25f;
        angleRange = 1 - 1 /shotCount;
    }
    public void Action()
    {

        if (shotCount > 1)
        {
            for (int i = 0; i < shotCount; i++)
            {
                var v = Instantiate(bullet);
                v.Init(transform.position, shotSpeed, bulletSpeedRate, shotAngle + angleRange * ((float)i / (shotCount - 1) - 0.5f), bulletAngleRate);
            }
        }
        else
        {
            var v = Instantiate(bullet);
            v.Init(transform.position, shotSpeed, bulletSpeedRate, shotAngle, shotAngleRate);
        }
    }

    [SerializeField] private float intervalTime;
    public float GetInterval()
    {
        return intervalTime;
    }
}
