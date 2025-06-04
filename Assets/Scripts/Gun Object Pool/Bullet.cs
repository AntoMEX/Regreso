using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [HideInInspector] public int gundamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Time.fixedDeltaTime * speed * Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyMovement enemy)) enemy.RecieveDamage(gundamage);
        else if(other.gameObject.TryGetComponent(out NPC npc)) npc.RecieveDamage(gundamage);
        gameObject.SetActive(false);
    }
}
