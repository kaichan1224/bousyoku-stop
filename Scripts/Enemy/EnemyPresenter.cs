using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter : MonoBehaviour
{
    [SerializeField] private EnemyModel enemyModel;
    public void Initialize()
    {
        enemyModel.Initialize();
    }
    public void ManualUpdate()
    {
        //enemyModel.ManualUpdate();
    }
}
