using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using System;
using Cysharp.Threading.Tasks;
using System.Threading;
using DG.Tweening;

public class UIView : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    public IObservable<Unit> OnExit => exitButton.OnClickAsObservable();
    [SerializeField] private RectTransform startPanel;
    [SerializeField] private RectTransform playingView;
    [SerializeField] private RectTransform gameOverView;
    [SerializeField] private RectTransform resultView;
    [SerializeField] TMP_Text timeText;

    public async UniTask StartShow(CancellationToken token)
    {
        var sequence = DOTween.Sequence();
        await sequence
            .AppendCallback(() => playingView.gameObject.SetActive(false))
            .AppendCallback(()=>startPanel.gameObject.SetActive(true))
            .AppendInterval(0.75f)
            .AppendCallback(() => startPanel.gameObject.SetActive(false))
            .AppendInterval(0.2f)
            .AppendCallback(() => startPanel.gameObject.SetActive(true))
            .AppendInterval(0.15f)
            .AppendCallback(() => startPanel.gameObject.SetActive(false))
            .AppendInterval(0.1f)
            .AppendCallback(() => startPanel.gameObject.SetActive(true))
            .AppendInterval(0.1f)
            .AppendCallback(() => startPanel.gameObject.SetActive(false))
            .AppendInterval(0.1f)
            .AppendCallback(() => playingView.gameObject.SetActive(true))
            .Play()
            .ToUniTask(cancellationToken: token);
    }

    public async UniTask GameOverShow(CancellationToken token, int finishTime)
    {
        var sequence = DOTween.Sequence();
        await sequence
            .AppendCallback(() => gameOverView.gameObject.SetActive(true))
            .AppendInterval(1f)
            .AppendCallback(() =>
            {
                resultView.gameObject.SetActive(true);
                SetResult(finishTime);
            })
            .Play()
            .ToUniTask(cancellationToken: token);
    }

    public void SetResult(float time)
    {
        timeText.text = $"{time}秒耐久";
    }


}
