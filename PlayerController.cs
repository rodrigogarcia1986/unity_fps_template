using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    Rigidbody playerRb; //Reference player's rigidbody

    float playerSpeed = 5; //Set basic player's speed

    GameManager gameManager;

    AudioSource audioSource;
     

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); //Get player's rigidbody

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();    

        audioSource = GetComponent<AudioSource>();
                       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.CheckIfGameIsActive() == true)
        {           
            MovePlayer();
        }                    

    }

    void MovePlayer()
    {
        float forward = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * forward * playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * right * playerSpeed * Time.deltaTime);
    }
  
}
