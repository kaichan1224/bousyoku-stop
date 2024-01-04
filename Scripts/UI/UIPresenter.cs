using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;

/// <summary>
/// UI周りの表示更新処理を一括で管理している
/// </summary>
public class UIPresenter : MonoBehaviour
{
    [SerializeField] private PlayerModel playerModel;
    [SerializeField] private UIView uIView;
    public async UniTask StartAsync(CancellationToken token)
    {
        await uIView.StartShow(token);
    }

    public async UniTask GameOverAsync(CancellationToken token,int finishTime)
    {
        await uIView.GameOverShow(token,finishTime);
    }

    public void Initialize()
    {
        Bind();
    }

    public void Bind()
    {
        uIView.OnExit.Subscribe(_ =>
        {
            SceneManager.LoadSceneAsync("Title");
        }).AddTo(this);
    }
}
