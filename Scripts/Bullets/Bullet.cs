using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //速度
    private float speed;
    //加速度
    private float speedRate;
    //角速度
    private float angleRate;
    //角度
    private float angle;
    //位置
    private float x,y;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector3 position,float speed,float speedRate,float angle,float angleRate)
    {
        x = position.x;
        y = position.y;
        this.speed = speed;
        this.speedRate = speedRate;
        this.angle = angle;
        this.angleRate = angleRate;
        this.transform.position = new Vector3(x,y,0);
    }

    private void Move()
    {
        float rad = angle * Mathf.PI * 2;
        x += speed * Mathf.Cos(rad) * Time.deltaTime;
        y += speed * Mathf.Sin(rad) * Time.deltaTime;
        rb.MovePosition(new Vector2(x,y));
        angle += angleRate;
        speed += speedRate;
    }

    /// <summary>
    /// ManualUpdateにしたい TODOオブジェクトプールで管理する
    /// </summary>
    private void Update()
    {
        Move();
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
