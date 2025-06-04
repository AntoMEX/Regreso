using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar escenas

public class GameOver : MonoBehaviour
{
    // Método que será llamado al presionar el botón
    public void ReturnToMainMenu()
    {
        // Carga la escena del menú principal, reemplaza "MainMenu" con el nombre exacto de la escena
        SceneManager.LoadScene("Menu");
    }
}
