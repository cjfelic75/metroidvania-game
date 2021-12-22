using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    
    public movedbySwitch MovedbySwitch;

    void OnTriggerEnter2D(Collider2D PressurePlate)
    {
        if(PressurePlate.tag == "Player")
            {
            bool Plate = PressurePlate.GetComponent<movedbySwitch>();
            MovedbySwitch.SwitchMovement(true);
            if (Plate != null)
                {
                MovedbySwitch.SwitchMovement(true);
                }
        }
    }
}
