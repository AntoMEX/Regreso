using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
	/*public VolumeView volumeView;
    public VolumeModel volumeModel;

    private void Awake()
    {
        volumeModel = new VolumeModel();
    }

    private void Start()
    {
        volumeModel.OnVolumeChanged += OnVolumeChanged;

        if (volumeView != null)
        {
            volumeView.init(volumeModel.Volume);
            volumeView.SliderCallback(OnSliderValueChanged);
        }
    }

    public void OnSliderValueChanged(float newValue)
    {
        volumeModel.Volume = newValue;
    }

    private void OnVolumeChanged(float newVolume)
    {
        AudioListener.volume = newVolume;
        Debug.Log("El volumen cambió a: "+ newVolume);
    }*/

	public VolumeModel model = new VolumeModel();
	public VolumeView view;
	private bool paused = false;

	private void Start()
	{
		view.Init(model.Volume);
		view.SetSliderCallback(OnSliderChanged);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			ToggleMenuView();
			//view.ToggleMenu();
			//Time.timeScale = 0f;
		}
	}

	private void ToggleMenuView()
	{
		bool active = view.isActiveAndEnabled;
		view.gameObject.SetActive(!active);

		paused = !paused;
		Time.timeScale = paused ? 0 : 1;

		//      if (paused)
		//      {
		//          Time.timeScale = 0;
		//}
		//      else
		//      {
		//	Time.timeScale = 1;
		//}

	}

	private void OnSliderChanged(float newValue)
	{
		model.SetVolume(newValue);
		AudioListener.volume = newValue;
	}
}
