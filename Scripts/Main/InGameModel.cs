using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

/// <summary>
/// ゲームの状態管理する
/// </summary>
public class InGameModel
{
    /// <summary>
    /// 現在の状態
    /// </summary>
    private readonly ReactiveProperty<InGameEnum.State> _stateProp;
    public IReadOnlyReactiveProperty<InGameEnum.State> StateProp => _stateProp;
    public InGameEnum.State State => _stateProp.Value;

    /// <summary>
    /// 直前の状態
    /// </summary>
    private InGameEnum.State _prevState;
    // Presenterからアクセスできるように追加
    public InGameEnum.State PrevState => _prevState;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public InGameModel()
    {
        // ゲームの状態を「WaitStart」に設定
        _stateProp = new ReactiveProperty<InGameEnum.State>(InGameEnum.State.WaitStart);
    }

    /// <summary>
    /// リセット
    /// </summary>
    public void ResetState()
    {
        SetState(InGameEnum.State.WaitStart);
    }

    /// <summary>
    /// 状態を設定します
    /// </summary>
    public void SetState(InGameEnum.State state)
    {
        _prevState = state;
        _stateProp.Value = state;
    }
}
