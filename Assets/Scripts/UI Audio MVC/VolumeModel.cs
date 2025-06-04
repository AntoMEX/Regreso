using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeModel
{
    /*public event Action<float> OnVolumeChanged;

    private float volume = 1f;

    public float Volume
    {
        get { return volume; }
        set
        {
            if (Math.Abs(volume - value) > 0.001f)
            {
                volume = value;
                OnVolumeChanged?.Invoke(volume);
            }
        }
    }*/

    public float Volume { get; private set; } = 1f;

    public void SetVolume(float newVolume)
    {
        Volume = newVolume;
    }
}
