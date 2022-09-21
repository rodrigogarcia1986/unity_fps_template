using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    //Populate with game object prefab for projectiles
    [SerializeField] GameObject enemy2ProjectilePrefab;
    [SerializeField] GameObject enemy2SpawnPos;

    [SerializeField] AudioClip enemy2Shot;

    GameObject player;

    [SerializeField] int pointValue;

    [SerializeField] NavMeshAgent enemy;


    

    Rigidbody rb;


    bool hasShot = false;

    float coolDownTimer = 0f;
    float coolDownTime = 3f;

    GameManager gameManager;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.CheckIfGameIsActive() == true)
        {
            GetComponent<NavMeshAgent>().destination = player.transform.position;

            float distance = Vector3.Distance(player.transform.position, transform.position);

            coolDownTimer += Time.deltaTime;

            if (distance <= 30 && coolDownTimer > coolDownTime)
            {
                hasShot = true;
                ShootPlayer();
                hasShot = false;
                coolDownTimer = 0f;
                Debug.Log("has shot");

            }
        }              

    }
    void ShootPlayer()
    {
        Instantiate(enemy2ProjectilePrefab, enemy2SpawnPos.transform.position, 
            enemy2ProjectilePrefab.transform.rotation);
        audioSource.PlayOneShot(enemy2Shot);

    }

}
