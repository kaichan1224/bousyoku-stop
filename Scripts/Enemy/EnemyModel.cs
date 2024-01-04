using System;
using System.Collections;
using System.Collections.Generic;
using TNRD;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    private ShotStrategy shotStrategy;
    private ShotStrategy shotStrategy1;
    private ShotStrategy shotStrategy2;
    private ShotStrategy shotStrategy3;
    [SerializeField] int index = 0;
    [SerializeField] List<SerializableInterface<IShotStrategy>> shots;
    [SerializeField] private ShotMasterData shotMasterData;
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed;
    private int moveXDirection = -1;
    public void Initialize()
    {
        shotStrategy = new ShotStrategy();
        shotStrategy1 = new ShotStrategy();
        shotStrategy2 = new ShotStrategy();
        shotStrategy3 = new ShotStrategy();
        SetShotStrategy(shots[index].Value);
        StartCoroutine(ActionStart());
        StartCoroutine(ActionStart1());
        StartCoroutine(ActionStart2());
        StartCoroutine(ActionStart3());
    }

    private void SetShotStrategy(IShotStrategy shot)
    {
        shotStrategy.SetStrategy(shot);
        shotStrategy.Init(transform.position,player,this.transform);
    }

    private void SetShotStrategy1(IShotStrategy shot)
    {
        shotStrategy1.SetStrategy(shot);
        shotStrategy1.Init(transform.position, player, this.transform);
    }

    private void SetShotStrategy2(IShotStrategy shot)
    {
        shotStrategy2.SetStrategy(shot);
        shotStrategy2.Init(transform.position, player, this.transform);
    }

    private void SetShotStrategy3(IShotStrategy shot)
    {
        shotStrategy3.SetStrategy(shot);
        shotStrategy3.Init(transform.position, player, this.transform);
    }

    /// <summary>
    /// 敵の動き
    /// </summary>
    /// <returns></returns>
    IEnumerator ActionStart()
    {
        while (true)
        {
            yield return Action1();
            Next();
        }
    }

    IEnumerator ActionStart1()
    {
        yield return new WaitForSeconds(30f);
        yield return ActionNerai();
    }

    IEnumerator ActionStart2()
    {
        yield return new WaitForSeconds(50f);
        yield return ActionKurukuru();
    }

    IEnumerator ActionStart3()
    {
        yield return new WaitForSeconds(70f);
        yield return ActionWakeru();
    }


    IEnumerator Action1()
    {
        float timer = 0.0f;
        float maxTime = 10.0f; // 30秒を表す
        while (timer < maxTime)
        {
            shotStrategy.Action();
            var interval = shotStrategy.GetInterval();
            timer += interval; // ループごとに0.1秒経過したと仮定
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator ActionNerai()
    {
        Debug.Log("Action2");
        SetShotStrategy1(shotMasterData.GetData(InGameEnum.ShotAlgo.狙い球));
        float timer = 0.0f;
        float maxTime = 10.0f; // 30秒を表す
        while (timer < maxTime)
        {
            shotStrategy1.Action();
            var interval = shotStrategy1.GetInterval();
            timer += interval; // ループごとに0.1秒経過したと仮定
            yield return new WaitForSeconds(interval);
        }
        SetShotStrategy1(shotMasterData.GetData(InGameEnum.ShotAlgo.NWAY弾));
        timer = 0.0f;
        maxTime = 40.0f; // 30秒を表す
        while (timer < maxTime)
        {
            shotStrategy1.Action();
            var interval = shotStrategy1.GetInterval();
            timer += interval; // ループごとに0.1秒経過したと仮定
            yield return new WaitForSeconds(interval);
        }
        yield return new WaitForSeconds(100f);
        SetShotStrategy1(shotMasterData.GetData(InGameEnum.ShotAlgo.多方向渦巻き弾));
        while (true)
        {
            shotStrategy1.Action();
            var interval = shotStrategy1.GetInterval();
            timer += interval; // ループごとに0.1秒経過したと仮定
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator ActionKurukuru()
    {
        SetShotStrategy2(shotMasterData.GetData(InGameEnum.ShotAlgo.渦巻き弾));
        float timer = 0.0f;
        float maxTime = 50.0f; // 30秒を表す
        while (timer < maxTime)
        {
            shotStrategy2.Action();
            var interval = shotStrategy2.GetInterval();
            timer += interval; // ループごとに0.1秒経過したと仮定
            yield return new WaitForSeconds(interval);
        }
        SetShotStrategy2(shotMasterData.GetData(InGameEnum.ShotAlgo.方向弾));
        timer = 0f;
        maxTime = 50.0f; // 30秒を表す
        while (timer < maxTime)
        {
            shotStrategy2.Action();
            var interval = shotStrategy2.GetInterval();
            timer += interval; // ループごとに0.1秒経過したと仮定
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator ActionWakeru()
    {
        SetShotStrategy3(shotMasterData.GetData(InGameEnum.ShotAlgo.方向弾));
        float timer = 0.0f;
        float maxTime = 10.0f; // 30秒を表す
        while (timer < maxTime)
        {
            shotStrategy3.Action();
            var interval = shotStrategy3.GetInterval();
            timer += interval; // ループごとに0.1秒経過したと仮定
            yield return new WaitForSeconds(interval);
        }
        SetShotStrategy3(shotMasterData.GetData(InGameEnum.ShotAlgo.狙い球));
        timer = 0.0f;
        maxTime = 100.0f; // 30秒を表す
        while (timer < maxTime)
        {
            shotStrategy3.Action();
            var interval = shotStrategy3.GetInterval();
            timer += interval; // ループごとに0.1秒経過したと仮定
            yield return new WaitForSeconds(interval);
        }
    }

    void Next()
    {
        if (index < shots.Count-1)
        {
            index++;
        }
        SetShotStrategy(shots[index].Value);
    }

}
