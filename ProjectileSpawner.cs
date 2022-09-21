using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    //Add two kinds of projectiles
    [SerializeField] GameObject normalShot;
    [SerializeField] GameObject strongShot;

    [SerializeField] AudioClip firstShot;
    [SerializeField] AudioClip secondShot;  

    [SerializeField] Transform firePoint;

    GameManager gameManager;

    AudioSource audioSource;

    // Set default value of pickup
    public bool hasPickup = false;

    bool hasShot = false;
     

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.CheckIfGameIsActive() == true
            && gameManager.isGamePaused == false)
        {
            if (Input.GetButtonUp("Fire1") && !hasPickup && hasShot == false)
            {
                hasShot = true;
                Instantiate(normalShot, firePoint.position, transform.rotation);
                Debug.Log("normal shot");
                audioSource.PlayOneShot(firstShot);
                hasShot = false;

            }
            else if (Input.GetButtonUp("Fire1") && hasPickup)
            {
                Instantiate(strongShot, firePoint.position, transform.rotation);
                Debug.Log("strong shot");
                audioSource.PlayOneShot(secondShot);

            }
        }
        
    }
   

}
