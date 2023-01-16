using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : Enemy
{
    private int xDirection;

    private void Start()
    {
        if (Random.Range(0, 2) == 0) //used to change direction of zigzag so it either goes left or right
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }
    }

    void Update()
    {
        Move();
        MoveZigZag();

        if (bndCheck != null && bndCheck.offLeft)
        {
            xDirection =1;
        }

        if (bndCheck != null && bndCheck.offRight)
        {
            xDirection = -1;
        }

        if (bndCheck != null && bndCheck.offDown)
        {
            // Check to make sure it's gone off the bottom of the screen
            if (pos.y < bndCheck.camHeight - bndCheck.radius)
            {
                // We're off the bottom, so destroy this GameObject
                Destroy(gameObject);
            }
        }
    }

    void MoveZigZag() 
    {
        Vector3 tempPos = pos;
        tempPos.x += xDirection * speed * Time.deltaTime;
        pos = tempPos;
    }
}
