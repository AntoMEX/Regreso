using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeView : MonoBehaviour
{
    /*public Slider volumeSlider;


    public void init(float startvolume)
    {
        volumeSlider.value = startvolume;
    }


    public void SliderCallback(UnityEngine.Events.UnityAction<float> onValueChange)
    {
        volumeSlider.onValueChanged.AddListener(onValueChange);
    }*/

    public GameObject menuUI;

    public Slider volumeSlider;

    public void ToggleMenu()
    {
        menuUI.SetActive(!menuUI.activeSelf);
    }

    public void Init(float initialVolume)
    {
        volumeSlider.value = initialVolume;
    }

    public void SetSliderCallback(UnityEngine.Events.UnityAction<float> callback)
    {
        volumeSlider.onValueChanged.AddListener(callback);
    }
}
