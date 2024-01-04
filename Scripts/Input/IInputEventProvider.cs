using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

/// <summary>
/// 入力を管理するインターフェース
/// </summary>
public interface IInputEventProvider
{
    public IReadOnlyReactiveProperty<int> InputX { get; }
    public IReadOnlyReactiveProperty<int> InputY { get; }
    public void ManualUpdate(bool isActivate);
}
