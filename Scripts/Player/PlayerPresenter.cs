using System;
using UnityEngine;
using UniRx;

/// <summary>
/// playermodelとplayerViewを繋ぐメソッド
/// </summary>
public class PlayerPresenter : MonoBehaviour
{
    [SerializeField] private PlayerModel playerModel;
    [SerializeField] private PlayerView playerView;
    public event Action OnDeathCallBack;

    /// <summary>
    /// 初期化メソッド
    /// </summary>
    public void Initialize()
    {
        playerModel.Initialize();
        playerView.Initialize();
        Bind();
        SetEvent();
    }

    /// <summary>
    /// modelの値をviewに反映させる
    /// </summary>
    private void Bind()
    {
        playerModel.PositionX.Subscribe(x =>
        {
            playerView.SetPositionX(x);
        })
        .AddTo(this);

        playerModel.PositionY.Subscribe(y =>
        {
            playerView.SetPositionY(y);
        }).AddTo(this);
            

        playerModel.Life.Subscribe(value =>
        {
            playerView.SetLife(value,InGameConst.life);
        }).AddTo(this);
    }

    /// <summary>
    /// イベント設定
    /// </summary>
    private void SetEvent()
    {
        playerModel.OnDeathCallBack += () => OnDeathCallBack?.Invoke();
    }

    public void MoveX(int inputX)
    {
        playerModel.MoveX(inputX);
    }

    public void MoveY(int inputY)
    {
        playerModel.MoveY(inputY);
    }
}
