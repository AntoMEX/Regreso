using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] HPBarUIManager hpBarUIManager; //Barra de vida
    [SerializeField, MinAttribute(1)] int maxHP;
    int currentHP;

    public int pointsForKilling = 5;  // Puntos que restará eliminar al NPC
    public ScoreSystem scoreSystem; //Sistema de puntos

    [SerializeField] private AudioClip badhit;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        hpBarUIManager.SetMaxHP(maxHP);
        hpBarUIManager.SetCurrentHP(currentHP);

        //badhit = GetComponent<AudioSource>();
    }

    public void RecieveDamage(int damage) //Sistema de vida del civil
    {
        currentHP -= damage;
        hpBarUIManager.SetCurrentHP((int)currentHP);

        AudioManager.Instance.SoundEffect(badhit);

        if (currentHP <= 0) //Si su vida es 0
        {
            Die(); //El enemigo murió
        }
        Debug.Log($"Ouch I got hit for {damage} damage"); //Con el $ se puede poner variables en texto
    }
    private void Die() //Muerte de civil
    {
        //Restar los puntos al morir
        if (scoreSystem != null)
        {
            scoreSystem.SubtractPoints(pointsForKilling);
        }

        //Desactivar el civil
        gameObject.SetActive(false);
    }
}
