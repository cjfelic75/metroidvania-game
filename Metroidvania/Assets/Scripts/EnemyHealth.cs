using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Transform dropPoint;
    public int currentHealth;
    public GameObject SmallHealthOrb;
    public GameObject LargeHealthOrb;
    
    private PlayerHealth playerHealth;

    void Awake ()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }


    public void TakeDamage(int playerDamage)
    {
        currentHealth -= playerDamage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            if (playerHealth.currentHealth <= 65)
                {
                Instantiate(LargeHealthOrb, dropPoint.position, dropPoint.rotation);
                }
            else
            {
                Instantiate(SmallHealthOrb, dropPoint.position, dropPoint.rotation);
            }
        }
    }
}
