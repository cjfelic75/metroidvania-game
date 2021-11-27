using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCanister : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D Canister)
    {
        if (Canister.CompareTag("Player"))
        {
            playerHealth.currentFullCanisters += 1;
            //Popup saying the following
            Debug.Log("Canister obtained. You can now endure another 99 points of damage");
            //gets rid of the item
            Destroy(gameObject);
        }
    }
}
