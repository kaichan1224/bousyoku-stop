using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// インゲームで使用するEnumはここでまとめる
/// 
/// </summary>
public static class InGameEnum
{
    public enum State
    {
        None,
        WaitStart,     // 開始待ち
        Moving,
        Dead, // 墜落（地面への衝突）
    }

    public enum ShotAlgo
    {
        方向弾,//Directional
        渦巻き弾,//Spiral
        旋回加速渦巻き弾,//BENT_SPIRAL_SHOT
        両回転渦巻き弾,//BI_DIRECTIONAL_SHOT
        NWAY弾,
        狙い球,//Aiming
        多方向渦巻き弾,//MultipleSpiral
        円形弾,
    }
}
