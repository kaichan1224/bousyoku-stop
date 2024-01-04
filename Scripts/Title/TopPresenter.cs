using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using UniRx;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System.Threading;

/// <summary>
/// Top画面のpresenter
/// Viewのみインスペクターから登録
/// </summary>
public class TopPresenter : MonoBehaviour
{
    [SerializeField] TopView topView;
    [SerializeField] TransitionView transitionView;
    [SerializeField] private List<GameObject> foods;
    [SerializeField] private Vector3 genPos;
    void Start()
    {
        //ゲームスタート時点の演出
        //StartCoroutine(Spwan());
        SoundManager.instance.PlayBGM(SoundMasterData.SoundName.タイトルBGM);
        Bind();
    }

    private void Bind()
    {
        topView.OnPlay
            .Subscribe(_ =>
            {
                SoundManager.instance.PlaySE(SoundMasterData.SoundName.スタートSE);
                ShowAsync(default).Forget();
                //SceneManager.LoadSceneAsync("Game");
            })
            .AddTo(gameObject);

        topView.OnBGM.Subscribe(SoundManager.instance.SetBGMVolume)
            .AddTo(this);

        topView.OnSE.Subscribe(SoundManager.instance.SetSEVolume)
            .AddTo(this);
    }

    IEnumerator Spwan()
    {
        while (true)
        {
            var r = Random.Range(-3, 3);
            Instantiate(foods[Random.Range(0, foods.Count)],new Vector3(r,5,0),Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private async UniTask ShowAsync(CancellationToken token)
    {
        var async = SceneManager.LoadSceneAsync("Game");
        async.allowSceneActivation = false;
        await transitionView.Show(token);
        async.allowSceneActivation = true;
    }
}
