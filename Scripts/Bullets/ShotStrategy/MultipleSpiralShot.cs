using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleSpiralShot : MonoBehaviour, IShotStrategy
{
    private float shotAngle;
    private float shotAngleRate;
    [SerializeField] private float shotSpeed;
    [SerializeField] private Bullet bullet;
    [SerializeField] private int shotCount = 5;
    Transform enemyTransform;
    public void Init(Vector3 position, Transform targetTransform, Transform enemyTransform)
    {
        this.enemyTransform = enemyTransform;
        transform.position = position;
        this.shotAngle = 0;
        //shotCount = 4;
        //this.shotSpeed = 1;
    }
    public void Action()
    {
        for (int i = 0; i < shotCount; i++)
        {
            var v = Instantiate(bullet);
            v.Init(transform.position, shotSpeed, 0, shotAngle+(float)i/shotCount, shotAngleRate);
        }
        shotAngle += 0.2f;
    }

    [SerializeField] private float intervalTime;
    public float GetInterval()
    {
        return intervalTime;
    }
}
