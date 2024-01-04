using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using unityroom.Api;



public class InGamePresenter : MonoBehaviour
{
    [SerializeField] private PlayerPresenter player;
    [SerializeField] private EnemyPresenter enemy;
    private InGameModel inGameModel;
    [SerializeField] private InGameView inGameView;
    [SerializeField] private UIPresenter uIPresenter;
    [SerializeField] private TimerPresenter timer;
    private IInputEventProvider inputEventProvider;
    private bool isReady;
    private async void Start()
    {
        isReady = false;
        //ゲームスタート時の表示処理
        SoundManager.instance.PlayBGM(SoundMasterData.SoundName.ゲーム中BGM);
        await uIPresenter.StartAsync(default);
        //インスタンス生成
        inGameModel = new InGameModel();
        //初期化処理
        timer.Initialize();
        player.Initialize();
        enemy.Initialize();
        uIPresenter.Initialize();
        inputEventProvider = GetComponent<KeyInputEventProvider>();
        //データバインドとイベントの登録
        Bind();
        SetEvents();
        isReady = true;
    }

    private void SetEvents()
    {
        player.OnDeathCallBack += () => GameOver();
    }

    private void GameOver()
    {
        inGameModel.SetState(InGameEnum.State.Dead);
        isReady = false;
        UnityroomApiClient.Instance.SendScore(1, timer.GetTime(), ScoreboardWriteMode.HighScoreDesc);
    }

    private void Bind()
    {
        //入力
        inputEventProvider.InputX
            .Subscribe(player.MoveX)
            .AddTo(this);

        inputEventProvider.InputY
            .Subscribe(player.MoveY)
            .AddTo(this);

        //状態を監視
        inGameModel.StateProp
                .Subscribe(OnStateChanged)
                .AddTo(gameObject);

    }

    private void OnStateChanged(InGameEnum.State state)
    {
        switch (state)
        {
            case InGameEnum.State.Dead:
                timer.Stop();
                uIPresenter.GameOverAsync(default,(int)timer.GetTime()).Forget();
                break;
        }
    }

    private void Update()
    {
        if (!isReady)
            return;
        timer.ManualUpdate(Time.deltaTime);
        inputEventProvider.ManualUpdate(isReady);
        enemy.ManualUpdate();
    }

}
