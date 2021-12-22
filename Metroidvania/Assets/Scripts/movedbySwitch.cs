using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedbySwitch : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] positions;

    private int points;

    private SpriteRenderer characterSprite;

    void Awake()
    {
        characterSprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        SwitchMovement(false);
    }

    public void SwitchMovement(bool plateSwtich)
    {
        if (plateSwtich)
        {
            //points++;
            //if (points == 1)
                Destroy(gameObject);
        }
        //else
        //{
            //points = 0;
        //}
    }
    void update()
    {       
       // if(points = 1)
        //transform.position = Vector2.MoveTowards(transform.position, positions[points], Time.deltaTime * speed);
        
    }
}
