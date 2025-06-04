using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro

public class ScoreUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Referencia al componente de texto
    //private int currentScore = 0;

    // Actualizar la UI con el nuevo puntaje
    public void UpdateScore(int score)
    {
        //currentScore = score;
        scoreText.text = "Puntos: " + score.ToString();
    }
}
