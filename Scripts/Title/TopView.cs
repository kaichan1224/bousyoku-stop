using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using UnityEngine.UI;
using UniRx;
using System;

public class TopView : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Slider SESlider;
    [SerializeField] private Slider BGMSlider;
    public IObservable<Unit> OnPlay =>playButton.OnClickAsObservable();
    public IObservable<float> OnSE => SESlider.OnValueChangedAsObservable();
    public IObservable<float> OnBGM => BGMSlider.OnValueChangedAsObservable();

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
