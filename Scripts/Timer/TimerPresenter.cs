using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TimerPresenter : MonoBehaviour
{
    [SerializeField] TimerView timerView;
    private TimerModel timerModel;
    public bool isRun;
    public void Initialize()
    {
        timerModel = new TimerModel();
        isRun = true;
        Bind();
    }

    public float GetTime()
    {
        return timerModel.Time;
    }

    public void ManualUpdate(float deltaTime)
    {
        if(isRun)
            AddTime(deltaTime);
    }

    // 時間を進める
    private void AddTime(float deltaTime)
    {
        timerModel.SetTime(timerModel.Time + deltaTime);
    }

    // Bind処理
    public void Bind()
    {
        timerModel.TimeProperty.Subscribe(timerView.SetTime).AddTo(this);
    }

    public void Stop()
    {
        isRun = false;
    }

    public void Run()
    {
        isRun = true;
    }
}
