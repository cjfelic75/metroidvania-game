using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D eDamage)
    {
        if (eDamage.tag == "Player")
        {
            var EnemyDamage = eDamage.GetComponent<PlayerHealth>();
            if (EnemyDamage != null)
            {
                EnemyDamage.TakeDamage(damage);
            }
        }
    }
}