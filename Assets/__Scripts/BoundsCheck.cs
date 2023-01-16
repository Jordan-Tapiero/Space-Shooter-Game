using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f; //setting default radius
    public bool keepOnScreen = true;




    [Header("Set Dynamically")]
   
    public float camWidth; 
    public float camHeight;
    public bool isOnScreen = true;

    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown; 


    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }
    void LateUpdate() { 
        Vector3 pos = transform.position;
        offRight = offLeft = offUp = offDown = false;


       //if poition.x out of bounds on the right then set isOnScreen to false and offRight true
        if (pos.x > camWidth - radius) { 

            pos.x = camWidth - radius;
            offRight = true;
            isOnScreen = false;


        }
        //Similar to above comment but checking left bound
        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            offLeft = true;
            isOnScreen = false;

        }
        //looking at the y position, if its out of the screen at the top of the screen
        if (pos.y > camHeight - radius) //
        {
            pos.y = camHeight - radius;
            offUp = true; //set offUp to true
            isOnScreen = false; //set isOnScreen to false


        }

        if (pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
            offDown = true;
            isOnScreen = false;
        }

        //Line 69 essentially says if its not out of bounds on the right, left, up or down then it must be on the screen
        isOnScreen = !(offRight || offLeft || offUp || offDown);
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true; 
            offRight = offLeft = offUp = offDown = false;
        }

    }
    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}