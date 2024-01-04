using System.Collections;
using System;
using UnityEngine;
using UniRx;

public class PlayerModel : MonoBehaviour
{
    private float velocityX;
    private float velocityY;
    private ReactiveProperty<float> positionX;
    public IReadOnlyReactiveProperty<float> PositionX => positionX;
    private ReactiveProperty<float> positionY;
    public IReadOnlyReactiveProperty<float> PositionY => positionY;
    private ReactiveProperty<int> life;
    public IReadOnlyReactiveProperty<int> Life => life;
    public event Action OnDeathCallBack;
    public void Initialize()
    {
        velocityX = 0;
        velocityY = 0;
        positionX = new ReactiveProperty<float>(0);
        positionY = new ReactiveProperty<float>(0);
        life = new ReactiveProperty<int>(0);
    }

    public void Reset()
    {

    }

    public void MoveX(int inputX)
    {
        this.velocityX = inputX * InGameConst.moveSpeed * Time.deltaTime;
        var nextX = positionX.Value + velocityX;
        positionX.Value = Mathf.Clamp(nextX, InGameConst.minX, InGameConst.maxX);
    }

    public void MoveY(int inputY)
    {
        this.velocityY = inputY * InGameConst.moveSpeed * Time.deltaTime;
        var nextY = positionY.Value + velocityY;
        positionY.Value = Mathf.Clamp(nextY, InGameConst.minY, InGameConst.maxY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            SoundManager.instance.PlaySE(SoundMasterData.SoundName.ダメージSE);
            life.Value++;
            if (life.Value >= InGameConst.life)
            {
                OnDeathCallBack?.Invoke();
            }
        }
    }
}
