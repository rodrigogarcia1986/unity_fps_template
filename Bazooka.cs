using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    int health; //Player's health - it should be in the player object,
                        //but bazooka is the reference

    //Method for accessing player's health
    public int GetHealth()
    {
        return health;
    }

    GameManager gameManager; //reference

    // Start is called before the first frame update
    void Start()
    {
        //Code to ignore bazooka and player's body colliding with each other and the terrain
       Physics.IgnoreCollision(GameObject.Find("Terrain").GetComponent<Collider>(), 
           GetComponent<Collider>());
       Physics.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider>(), 
           GetComponent<Collider>());


        //set initial players'health
        //it can be changed according to implementation of difficulty
        health = 5;

        //reference for the game manager
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //checking players health 
        if (health == 0)
        {
            Destroy(GameObject.Find("Player"));
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //code to decrement health if player is hit by enemies' projectiles
        if (collision.gameObject.tag != "Terrain" 
            && collision.gameObject.tag != "Player" 
            && collision.gameObject.tag != "PlayerShot"
            && collision.gameObject.tag != "Pickup")
        {
            health--;
            gameManager.UpdateHealthText(health);
            Debug.Log(health);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            health--;
            gameManager.UpdateHealthText(health);
            Debug.Log(health);
        }
        
    }
    


}
