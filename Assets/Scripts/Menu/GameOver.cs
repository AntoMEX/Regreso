using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar escenas

public class GameOver : MonoBehaviour
{
    // M�todo que ser� llamado al presionar el bot�n
    public void ReturnToMainMenu()
    {
        // Carga la escena del men� principal, reemplaza "MainMenu" con el nombre exacto de la escena
        SceneManager.LoadScene("Menu");
    }
}
