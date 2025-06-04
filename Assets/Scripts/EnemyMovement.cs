using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed; //Velocidad

    Vector3 dir = new Vector3(0, 0, 1);

    public Transform[] targets; //Objetivos

    [SerializeField] HPBarUIManager hpBarUIManager; //Barra de vida
    [SerializeField, MinAttribute(1)] int maxHP;
    int currentHP;

    int targetsIndex; //Objetivos

    Transform currentTarget; //Cambiar objetivo

    public int damage; //Daño

    public int pointsForKilling = 10;  //Puntos que otorga eliminar al enemigo
    public ScoreSystem scoreSystem; //Sistema de puntos

    [SerializeField] private AudioClip attack;  //Sonido al atacar
    [SerializeField] private AudioClip hit;  //Sonido al recibir daño
    //private AudioSource audioSource;   //Componente AudioSource

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        hpBarUIManager.SetMaxHP(maxHP);
        hpBarUIManager.SetCurrentHP(currentHP);

        currentTarget = targets[targetsIndex];
        RotateTowardsTarget();
        FindAndAssingPlayer();

		scoreSystem = GameObject.FindFirstObjectByType<ScoreSystem>();

		//audioSource = GetComponent<AudioSource>();
	}

    //Encontrar al jugador y asignarlo al final de la lista
    private void FindAndAssingPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            return;
        }

        targets[targets.Length - 1] = player.transform;

    }

    private void RotateTowardsTarget()
    {
        Vector3 direction = currentTarget.position - transform.position;
        direction.y = 0;
        direction.Normalize();
        RotateTowardsDirection(direction);
    }

    // Update is called once per frame
    void Update()
    {                         //Solo hacia delante * transform.forward
        transform.Translate(Time.deltaTime * speed * dir);

        Vector3 targetPos = currentTarget.position;
        //targetPos.y = 1;

        if(Vector3.Distance(transform.position, targetPos) <= 0.5f)
        {
            targetsIndex++;
            if(targetsIndex >= targets.Length) targetsIndex = 0;
            currentTarget = targets[targetsIndex];
        }
        RotateTowardsTarget();
    }

    void RotateTowardsDirection(Vector3 direction) //Rotar enemigo
    {
        transform.forward = direction;
    }


    public void RecieveDamage(int damage) //Sistema de vida del enemigo
    {
        currentHP-=damage;
        hpBarUIManager.SetCurrentHP((int)currentHP);

        // Reproducir sonido al ganar puntos
        AudioManager.Instance.SoundEffect(hit);

        if (currentHP <= 0) //Si su vida es 0
        {
            Die(); //El enemigo murió
        }
        Debug.Log($"Ouch I got hit for {damage} damage"); //Con el $ se puede poner variables en texto
    }

    private void Die() //Muerte de enemigo
    {
        //Sumar los puntos al morir
        if (scoreSystem != null)
        {
            scoreSystem.AddPoints(pointsForKilling);
        }

        //Desactivar el enemigo
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision) //Recibe daño el jugador si colisiona con el
    {
        if (collision.gameObject.TryGetComponent(out Movement player)) 
        {
            player.RecieveDamage(damage);
            AudioManager.Instance.SoundEffect(attack);
        }
    }

    // Método para reproducir sonido
    //private void PlaySound(AudioClip clip)
    //{
    //    if (clip != null && audioSource != null)
    //    {
    //        audioSource.PlayOneShot(clip);  // Reproduce el sonido una vez
    //    }
    //}
}
