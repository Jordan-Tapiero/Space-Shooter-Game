using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f; //default speed of enemy
    

    public BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    public Vector3 pos
    {

        get
        {
            return (this.transform.position); //get position of Vecotr3
        }
        set
        {
            this.transform.position = value; //set the transform position to value
        }
    }
    void Update()
    {
        Move();

        if (bndCheck != null && !bndCheck.isOnScreen) //checking to see if enemy is off the screen
        {

            if (pos.y < bndCheck.camHeight - bndCheck.radius)
            {

                Destroy(gameObject); //destroy the enemy once it is off the screen
            }
        }
    }
    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}