using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int score = 0;  //Inicia en 0 los puntos
    private ScoreUIManager ScoreUIManager;  //UI Manager

    [SerializeField] private AudioClip gainPointsSound;  //Para poner el sonido al ganar puntos en unity
    [SerializeField] private AudioClip losePointsSound;  //Para poner el sonido al perder puntos en unity
    //private AudioSource audioSource;   //Componente AudioSource

    void Start()
    {
        //Encontrar el ScoreUIManager
        ScoreUIManager = FindObjectOfType<ScoreUIManager>();

        //Obtener el componente AudioSource
        //audioSource = GetComponent<AudioSource>();

        UpdateUI();
    }

    public void AddPoints(int points) //Sumar puntos cuando se elimina un enemigo
    {
        score += points; //Puntos más al score
        Debug.Log("Puntos sumados: " + points + ". Puntos actuales: " + score); //Comprobación

        //Reproducir sonido al ganar puntos
        AudioManager.Instance.SoundEffect(gainPointsSound);

        UpdateUI();
    }

    public void SubtractPoints(int points) //Restar puntos cuando se elimina un NPC
    {
        score -= points; //Puntos menos al score
        Debug.Log("Puntos restados: " + points + ". Puntos actuales: " + score); //Comprobación

        //Reproducir sonido al perder puntos
        AudioManager.Instance.SoundEffect(losePointsSound);

        UpdateUI();
    }
    private void UpdateUI()
    {
        if (ScoreUIManager != null)
        {
            ScoreUIManager.UpdateScore(score);
        }
    }

    //Método para reproducir sonido
    //private void PlaySound(AudioClip clip)
    //{
    //    if (clip != null && audioSource != null)
    //    {
    //        audioSource.PlayOneShot(clip);  //Reproduce el sonido una vez
    //    }
    //}
}
