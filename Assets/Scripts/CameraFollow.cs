using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       //Referencia al Transform del jugador
    public Vector3 offset;         //Desplazamiento de la c�mara con respecto al jugador
    public float smoothSpeed = 0.125f; //Velocidad de suavizado del movimiento de la c�mara

    private bool flipped = false;
    private Vector3 originalOffset;

    private void Start()
    {
        originalOffset = offset;
    }

    void LateUpdate()
    {
        //Calcula la posici�n deseada de la c�mara
        Vector3 desiredPosition = player.position + offset;
        //Suaviza el movimiento de la c�mara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //Actualiza la posici�n de la c�mara
        transform.position = smoothedPosition;

        //La c�mara siempre mira al jugador
        transform.LookAt(player);
    }

    public void FlipCamera()
    {
        flipped = !flipped;
        offset = flipped
            ? new Vector3(-originalOffset.x, originalOffset.y, -originalOffset.z) : originalOffset;

        //Posicionamiento inmediato tras el giro
        transform.position = player.position + offset;
        transform.LookAt(player);
    }
}
