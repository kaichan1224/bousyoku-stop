using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class TimerModel
{
    // 経過時間
    private ReactiveProperty<float> timeProperty;
    public IReadOnlyReactiveProperty<float> TimeProperty => timeProperty;
    public float Time => timeProperty.Value;

    // コンストラクタ
    public TimerModel()
    {
        timeProperty = new ReactiveProperty<float>(0);
    }

    // 経過時間を設定
    public void SetTime(float timer)
    {
        timeProperty.Value = timer;
    }
}
