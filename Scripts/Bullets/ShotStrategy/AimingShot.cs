using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingShot : MonoBehaviour,IShotStrategy
{
    private float bulletAngleRate;
    private float bulletSpeedRate;

    [SerializeField] private float shotSpeed;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemyTransform;

    public void Init(Vector3 position,Transform targetTransform, Transform enemyTransform)
    {
        transform.position = position;
        player = targetTransform;
        this.enemyTransform = enemyTransform;
    }
    public void Action()
    {
        if (player == null)
            return;
        var v = Instantiate(bullet);
        v.Init(transform.position,shotSpeed,bulletSpeedRate,GetPlayerAngle(),bulletAngleRate);
    }

    float GetPlayerAngle()
    {
        return Mathf.Atan2(player.position.y-transform.position.y,player.position.x-transform.position.x)/Mathf.PI/2;
    }

    [SerializeField] private float intervalTime;
    public float GetInterval()
    {
        return intervalTime;
    }
}
