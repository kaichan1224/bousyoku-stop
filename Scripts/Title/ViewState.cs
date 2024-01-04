using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


/// <summary>
/// どのView(画面)が今表示しているかの状態をもつクラス
/// </summary>
public class ViewState
{
    public enum View
    {
        TOP,
    };

    ReactiveProperty<View> currentViewInstance = new(View.TOP);
    public IReadOnlyReactiveProperty<View> currentView => currentViewInstance;

    public void ChangeView(View nextView)
    {
        currentViewInstance.Value = nextView;
    }
}
