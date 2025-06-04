using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI magazineAmmoText;
    [SerializeField] TextMeshProUGUI generalAmmoText;

    // Start is called before the first frame update
    public void SetMagazineAmmoText(int newValue)
    {
        magazineAmmoText.text = newValue.ToString();
    }

    // Update is called once per frame
    public void SetGeneralAmmoText(int newValue)
    {
        generalAmmoText.text = newValue.ToString();
    }
}
