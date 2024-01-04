using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NwayShot : MonoBehaviour,IShotStrategy
{
    private float shotAngle;
    private float shotAngleRate;
    private float bulletAngleRate;
    private float bulletSpeedRate;
    [Header("N分割")]
    [SerializeField] private int shotCount = 5;
    private float angleRange;
    Transform enemyTransform;
    [SerializeField] private float shotSpeed;
    [SerializeField] private Bullet bullet;
    public void Init(Vector3 position, Transform targetTransform, Transform enemyTransform)
    {
        this.enemyTransform = enemyTransform;
        transform.position = position;
        shotAngle = -0.25f;
        angleRange = 0.2f;
    }
    public void Action()
    {
        Debug.Log(bullet);
        if (shotCount > 1)
        {
            for (int i = 0; i < shotCount; i++)
            {
                var v = Instantiate(bullet.gameObject);
                Debug.Log(v);
                v.GetComponent<Bullet>().Init(transform.position,shotSpeed,bulletSpeedRate,shotAngle+angleRange*((float)i/(shotCount-1)-0.5f),bulletAngleRate);
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
