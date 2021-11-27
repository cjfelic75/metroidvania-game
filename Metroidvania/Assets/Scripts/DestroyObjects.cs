using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D destroyObject)
    {
        if (destroyObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
