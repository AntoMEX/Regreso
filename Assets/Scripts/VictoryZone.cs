using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject victoryScreen; // Pantalla de victoria

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto que entra al trigger tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            ShowVictoryScreen(); // Llamar al método para mostrar la pantalla de victoria
        }
    }

    private void ShowVictoryScreen()
    {
        // Activar la pantalla de victoria
        victoryScreen.SetActive(true);

        // Pausar el juego para que el jugador no siga moviéndose
        Time.timeScale = 0f;
    }
}
