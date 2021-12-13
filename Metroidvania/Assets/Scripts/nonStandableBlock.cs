using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonStandableBlock : MonoBehaviour
{
    private BoxCollider2D BoxCollider2D;
    bool wasBroken;
    private float reset = 6f;

    public GameObject nonStandableBlockpre;
    public GameObject nonStandableBlockpost;

    

    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        Break(false);
        wasBroken = false;

    }

    /*void Update()
    {
        
        reset += Time.deltaTime;
       if (reset >= 1f && reset <= 5f)
        {
            Break(true);
        }

        if (reset > 5f)
        {
            Break(false);
       }
    }*/

   void OnTriggerEnter2D(Collider2D BreakableBlock)
    {
        if (BreakableBlock.CompareTag("Player"))
        {
            Break(true);
        } 
   }

    void Break(bool isBroken)
    {
        if (isBroken)
        {
            Destroy(gameObject);
            wasBroken = true;
        }

        /*if(!isBroken)
        {

            if (wasBroken == false)
            {
                //Instantiate(nonStandableBlockpre, transform.position, transform.rotation);
            }
            if(wasBroken == true)
            {
                
            }
           
        }*/
    }
}
