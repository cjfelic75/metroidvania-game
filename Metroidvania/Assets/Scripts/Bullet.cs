using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float time = 0f;
    private float speed = 600f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = Time.fixedDeltaTime * (transform.right * speed);

    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 0.2)
        {
            Debug.Log("Bullet has destabilized");
            //gets rid of the item
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D LBullet)
    {
        if (LBullet.CompareTag("Enemy"))
        {
            int damage = 5;
            var PlayerDamage = LBullet.GetComponent<EnemyHealth>();
            if (PlayerDamage != null)
            {
                PlayerDamage.TakeDamage(damage);
            }
            Debug.Log("Bullet has touched an enemy");
            //gets rid of the item
            Destroy(gameObject);
        }

        else if (LBullet.CompareTag("Surface"))
        {
            Debug.Log("Bullet has touched a surface");
            //gets rid of the item
            Destroy(gameObject);
        }
    }
}
