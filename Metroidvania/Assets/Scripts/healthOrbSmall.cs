using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthOrbSmall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D healthOrb)
    {
        if (healthOrb.tag == "Player")
        {
            var health = healthOrb.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.Heal(5);
                Destroy(gameObject);
            }
        }
    } 
}


