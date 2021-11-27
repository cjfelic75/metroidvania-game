using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthOrbLarge : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D healthOrb)
    {
        if (healthOrb.tag == "Player")
        {
            var health = healthOrb.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.Heal(10);
                Destroy(gameObject);
            }
        }
    }
}
