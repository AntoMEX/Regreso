using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSide : MonoBehaviour
{
    public GameObject objeto; //Respawn por caida externa
    public Vector3 posicionRespawn;

    private Movement playerMovement;
    private CameraFollow cameraFollow;

    void Start()
    {
        //Referencias para poder invertir controles y girar la cámara
        playerMovement = FindObjectOfType<Movement>();
        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objeto.transform.position = posicionRespawn;

            if (playerMovement != null)
            {
                playerMovement.ToggleInvertedControls();
            }

            if (cameraFollow != null)
            {
                cameraFollow.FlipCamera();
            }
        }
    }

}
