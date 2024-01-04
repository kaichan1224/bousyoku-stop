using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BentSpiralShot : MonoBehaviour, IShotStrategy
{
    private float shotAngle;
    private float shotAngleRate;
    private float bulletAngleRate;
    private float bulletSpeedRate;
    Transform enemyTransform;
    [SerializeField] private float shotSpeed;
    [SerializeField] private Bullet bullet;
    [SerializeField] private int shotCount;
    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="position">弾幕発生の初期位置を指定,敵のtransformを渡せばOK</param>
    public void Init(Vector3 position, Transform targetTransform, Transform enemyTransform)
    {
        transform.position = position;
        shotAngleRate = 0.001f;
        bulletAngleRate = -0.000003f;
        bulletSpeedRate = 0.001f;
    }
    public void Action()
    {
        for (int i = 0; i < shotCount; i++)
        {
            var v = Instantiate(bullet);
            v.Init(transform.position, shotSpeed, bulletSpeedRate, shotAngle + (float)i / shotCount, bulletAngleRate);
            shotAngle += shotAngleRate;
        }
    }

    [SerializeField] private float intervalTime;
    public float GetInterval()
    {
        return intervalTime;
    }
}
