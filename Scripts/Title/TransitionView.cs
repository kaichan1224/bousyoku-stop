using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using DG.Tweening;

public class TransitionView : MonoBehaviour
{
    [SerializeField] private RectTransform upPanel;
    [SerializeField] private RectTransform downPanel;
    [SerializeField] private RectTransform middlePanel;

    public async UniTask Show(CancellationToken token)
    {
        SetActive(true);
        middlePanel.gameObject.SetActive(false);//真ん中は隠す
        upPanel.anchoredPosition = new Vector2(-800,-358);
        downPanel.anchoredPosition = new Vector2(800, 358);
        var sequence = DOTween.Sequence();
        await sequence
            .Append(upPanel.DOAnchorPos(new Vector2(0, -358), 0.35f))
            .Join(downPanel.DOAnchorPos(new Vector2(0, 358), 0.35f))
            .AppendCallback(() => middlePanel.gameObject.SetActive(true))
            .AppendInterval(0.1f)
            .AppendCallback(() => middlePanel.gameObject.SetActive(false))
            .AppendInterval(0.1f)
            .AppendCallback(() => middlePanel.gameObject.SetActive(true))
            .AppendInterval(0.1f)
            .AppendCallback(() => middlePanel.gameObject.SetActive(false))
            .AppendInterval(0.1f)
            .AppendCallback(() => middlePanel.gameObject.SetActive(true))
            .AppendInterval(0.4f)
            .Play()
            .ToUniTask(cancellationToken: token);
    }

    public void SetActive(bool flag)
    {
        this.gameObject.SetActive(flag);
    }
}
