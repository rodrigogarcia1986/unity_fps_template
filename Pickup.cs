using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    GameManager gameManager;

    ProjectileSpawner projectileSpawner;


    // Start is called before the first frame update
    void Start()
    {
        projectileSpawner = GameObject.Find("ProjectileSpawner").GetComponent<ProjectileSpawner>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)  
    {
        if (collision.gameObject.tag != "Terrain" && collision.gameObject.tag != "Enemy"
            && collision.gameObject.tag != "PlayerShot")            

        {
            projectileSpawner.hasPickup = true;
            
            Destroy(gameObject);
        }
        

        
    }
}
