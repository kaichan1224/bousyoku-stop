using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class KeyInputEventProvider : MonoBehaviour,IInputEventProvider
{
    private readonly ReactiveProperty<int> inputX = new ReactiveProperty<int>(0);
    public IReadOnlyReactiveProperty<int> InputX => inputX;
    private readonly ReactiveProperty<int> inputY = new ReactiveProperty<int>(0);
    public IReadOnlyReactiveProperty<int> InputY => inputY;
    public void ManualUpdate(bool isActivate)
    {
        if (!isActivate)
            return;
        var _inputX = 0;
        var _inputY = 0;
        if (Input.GetKey(KeyCode.A))
        {
            _inputX = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _inputX = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _inputY = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _inputY = -1;
        }
        inputX.SetValueAndForceNotify(_inputX);
        inputY.SetValueAndForceNotify(_inputY);
    }
}
