using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugUtility
{
    /// <summary>
    /// エラーログ
    /// </summary>
    public static void LogError(string message)
    {
        Debug.LogError(message);
    }

    /// <summary>
    /// デバッグログ
    /// </summary>
    public static void Log(string message)
    {
        Debug.Log(message);
    }
}
