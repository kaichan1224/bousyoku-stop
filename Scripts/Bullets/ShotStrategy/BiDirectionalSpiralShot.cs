using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiDirectionalSpiralShot : MonoBehaviour,IShotStrategy
{
    private float[] shotAngle = new float[2];
    private float[] shotAngleRate = new float[2];
    [SerializeField] private float shotSpeed;
    [SerializeField] private Bullet bullet;
    [SerializeField] private int shotCount;
    Transform enemyTransform;
    public void Init(Vector3 position, Transform targetTransform, Transform enemyTransform)
    {
        transform.position = position;
        this.enemyTransform = enemyTransform;
        this.shotAngle[0] = 0;
        this.shotAngle[1] = 0;
        this.shotAngleRate[0] = 0.03f;
        this.shotAngleRate[1] = -0.02f;
    }
    public void Action()
    {
        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < shotCount; i++)
            {
                var v = Instantiate(bullet);
                v.Init(transform.position, shotSpeed, 0, shotAngle[j] + (float)i / shotCount, 0);
            }
            shotAngle[j] += shotAngleRate[j];
        }

    }

    [SerializeField] private float intervalTime;
    public float GetInterval()
    {
        return intervalTime;
    }
}
