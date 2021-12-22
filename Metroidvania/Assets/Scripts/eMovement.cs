using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eMovement : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[points], Time.deltaTime * speed);

        if(transform.position == positions[points])
        {
            if (points == positions.Length -1)
            {
                points = 0;
                characterSprite.flipX = false;
            }
            else
            {
                points++;
                characterSprite.flipX = true;
            }
        }
    }
}
