using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject objeto; //Respawn por caida externa
    public Vector3 posicionRespawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ExternalSpawn();
        }
    }

    private void ExternalSpawn()
    {
        objeto.transform.position = posicionRespawn;
    }
}
