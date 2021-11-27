using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public SpriteRenderer sp;
    public Transform firePoint;
    public GameObject bullet;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LightATK"))
        {
            ShootLATK();
        }
    }

    void ShootLATK()
    {
        //Instantiate will spawn in the gameobject when condition is met
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
