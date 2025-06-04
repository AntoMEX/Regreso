using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       //Referencia al Transform del jugador
    public Vector3 offset;         //Desplazamiento de la cámara con respecto al jugador
    public float smoothSpeed = 0.125f; //Velocidad de suavizado del movimiento de la cámara

    private bool flipped = false;
    private Vector3 originalOffset;

    private void Start()
    {
        originalOffset = offset;
    }

    void LateUpdate()
    {
        //Calcula la posición deseada de la cámara
        Vector3 desiredPosition = player.position + offset;
        //Suaviza el movimiento de la cámara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //Actualiza la posición de la cámara
        transform.position = smoothedPosition;

        //La cámara siempre mira al jugador
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
