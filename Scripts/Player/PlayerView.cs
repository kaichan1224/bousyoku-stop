using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// player周りのView
/// </summary>
public class PlayerView : MonoBehaviour
{
    [SerializeField] private Slider lifeSlider;

    public void Initialize()
    {
        
    }

    public void Reset()
    {
        
    }

    public void SetLife(int life,int maxLife)
    {
        lifeSlider.value = (float)life / (float)maxLife;
    }

    public void SetPositionX(float posX)
    {
        var tmpPos = transform.position;
        tmpPos.x = posX;
        transform.position = tmpPos;
    }

    public void SetPositionY(float posY)
    {
        var tmpPos = transform.position;
        tmpPos.y = posY;
        transform.position = tmpPos;
    }
}
