using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed; //Velocidad
    public float sprintspeed; //Sprint
    private float lastHorizontalInput;//variable para guardar el último input horizontal del jugador, se usará para girar al jugador a la izq. o derecha
    public float jumpForce = 10f; //Fuerza de salto
    private bool isGrounded; //En el suelo

    public GameObject defeatScreen; //Pantalla de derrota

    [SerializeField] HPBarUIManager hpBarUIManager; //Barra de vida
    [SerializeField, MinAttribute(1)] int maxHP; //Vida máxima
    int currentHP; //Vida actualizada

    [SerializeField] private AudioClip fall; //Audio de caida

    public GameObject objeto; //Respawn por caida de mapa
    public Vector3 posicionRespawn;

    public bool controlsInverted = false; //Inversion de controles

    // Start is called before the first frame update
    void Start()
    {
        lastHorizontalInput = 1; //inicializar en 1 que es el valor default de la escala en x

        Debug.Log("El jugador se mueve"); //Para verificar el movimiento del jugador

        currentHP = maxHP; //Vida actualizada igual a vida máxima
        hpBarUIManager.SetMaxHP(maxHP); //Vida máxima 
        hpBarUIManager.SetCurrentHP(currentHP);//Vida actual

        //fall = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float rawH = Input.GetAxis("Horizontal");
        float h = controlsInverted ? -rawH : rawH;

        //Tres vectores con x horizontal y 0 z vertical
        Vector3 dir = new Vector3(h, 0, 0); //Estan las tres coordenadas para moverte, 0 para que no registre poder moverse en esa coordenada
        dir.Normalize();

        //Sprint
        float framemovespeed; 
        if (Input.GetKey(KeyCode.LeftShift)) //Si recibe la tecla shift
        {
            framemovespeed = Time.deltaTime * sprintspeed; //Hace el sprint
        }
        else
        {
            framemovespeed = Time.deltaTime * speed; //Si no, solo se mueve
        }

        //Segunda opcion
        //float framemovespeed = Time.deltaTime * speed; 
        //if (Input.GetKey(KeyCode.LeftShift)) framemovespeed *= sprintspeedmodifier;

        dir *= framemovespeed;

        transform.Translate(dir);

        //Salto
        if (Input.GetButtonDown("Jump") && isGrounded) //Si esta en el suelo (en un objeto que tiene tag Ground)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Fuerza hacia arriba
            isGrounded = false; //No esta en el suelo
        }

        //Setear la escala en -1 o 1 dependiendo si el jugador esta moviéndose a la izq o derecha, para ello se tiene que crear un nuevo vector y solo modificar el eje x
        //para el y y el z conservar los mismos valores
        transform.localScale = new Vector3(setScaleXValue(h), transform.localScale.y, transform.localScale.z);

        if (transform.position.y < -6f) //Si la posoción del objeto (player) llega a -6 en eje y
        {
            RespawnObject(); //Respawnea
        }
    }

    public void RecieveDamage(int damage) //Daño al jugador
    {
        currentHP -= damage; //Actualizar vida
        hpBarUIManager.SetCurrentHP((int)currentHP); //Actualizar la barra de vida
        if (currentHP <= 0) //Si la vida es 0
        {
            defeatScreen.SetActive(true); //Aparece la pantalla de derrota
            gameObject.SetActive(false); //Desaparece el jugador
        }
        Debug.Log($"Ouch I got hit for {damage} damage"); //Con el $ se puede poner variables en texto
    }

    void OnCollisionEnter(Collision collision) //Jugador en suelo
    {
        // Verificar si el jugador está en el suelo
        if (collision.gameObject.CompareTag("Ground")) //Si esta colisionando con el tag Ground
        {
            isGrounded = true; //Esta en el suelo
            //fall.Play(); //Reproduce caida al suelo
            AudioManager.Instance.SoundEffect(fall);
        }
    }

    /// <summary>
    /// Función para determinar la escala en X del jugador
    /// </summary>
    /// <param name="horizontalValue">el valor del input horizontal</param>
    /// <returns>la última dirección en la que el jugador se movió</returns>
    private float setScaleXValue(float horizontalValue)
    {

        //si el moviminento horizontal del jugador no es cero, es decir, se está moviendo, guardamos él último input en lastHorizontalInput
        // y regresamos el valor del input.
        if (horizontalValue != 0)
        {
            lastHorizontalInput = horizontalValue;
            return horizontalValue;

        }

        //i el moviminento horizontal del jugador es cero retornamos lastHorizontalInput, que fue el último input del jugador, ya sea 1 o -1
        //esto para evitar aplicar una escala de 0
        else
        {
            return lastHorizontalInput;
        }
    }

    void RespawnObject()
    {
        objeto.transform.position = posicionRespawn;
    }

    //Inversion de controles
    public void ToggleInvertedControls()
    {
        controlsInverted = !controlsInverted;
    }
}

//Para que tenga colision se le pone el componente Rigidbody al Player y para que no se caiga, en la parte de Constraints se le pone Freeze Rotation en "X" y "Z"
//Para que no gire al colisionar y se cambien sus controles, se le pone Freeze en "Z"