using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarUIManager : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    public Canvas canvas;

    // Start is called before the first frame update
    private void Start()
    {
        if (canvas == null)
        {
            canvas = GetComponentInParent<Canvas>();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        // Solo rotar el forward del canvas si el canas es world, de lo contrario en modo overlay causa probelmas de visibilidad cuando se hace flip a la cámara
        if (IsWorldCanvas())
        {
            canvas.transform.forward = Camera.main.transform.forward;
        }
    }
    public void SetMaxHP(float newMaxHP)
    {
        hpSlider.maxValue = newMaxHP;
    }

    public void SetCurrentHP(float newHP)
    {
        hpSlider.value = newHP;
    }

    /// <summary>
    /// Saber si el canvas del slider esta en modo world o no
    /// </summary>
    /// <returns></returns>
    private bool IsWorldCanvas()
    {
        if (canvas == null)
        {
            return false;
        }

        return canvas.renderMode == RenderMode.WorldSpace;
    }
}
