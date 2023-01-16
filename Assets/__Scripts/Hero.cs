using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public static Hero S;
    public float speed = 30; //set default hero speed
    public float rollMult = -45; //default shift when controlling hero
    public float pitchMult = 30; //for up and down shift



   
    void Awake()
    {
        if (S == null)
        {

            S = this;
        }
        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }
    }
    void Update() //rotate the ship dynamically
    {
        float xAxis = Input.GetAxis("Horizontal"); //responsible for the hero moving in the x y plane
        float yAxis = Input.GetAxis("Vertical");
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime; 
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
    }

    void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the game
        }
    //Ontrigger method to track collsions

    void OnTriggerEnter(Collider other) 
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        print("Triggered: " + go.name);
        Destroy(this.gameObject); //destroy the hero if triggered
        Destroy(other.gameObject); //destroy the enemy that if triggered
        Restart(); //call restart method to restart the game after trigger occurs
    } 
}

