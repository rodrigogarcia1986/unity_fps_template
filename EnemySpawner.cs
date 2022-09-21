using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Populate with two game objects prefabs
    [SerializeField] GameObject enemy1prefab;
    [SerializeField] GameObject enemy2prefab;

    //Set Player as game object to follow
    [SerializeField] GameObject player;

    //Set random spawnPos
    float maxSpawnPosX = 700;
    float minSpawnPosX = -700;
    float minSpawnPosY = 2.2f;
    float maxSpawnPosY = 2.2f; 
    float maxSpawnPosZ = 800;
    float minSpawnPosZ = -600;
    

    //set maximum of enemies and keep the count
    public int enemyCount = 0;

    //Set spawnTimer
    float spawnTimer = 0f;
    float minSpawnTimer = 2f;
    float maxSpawnTimer = 5f;

    GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.CheckIfGameIsActive() == true)
        {
            //start spawn timer
            spawnTimer += Time.deltaTime;
            float randomSpawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);

            if (spawnTimer > randomSpawnTimer
            && enemyCount < 40)
            {
                EnemySpawn();
                enemyCount++;
                Debug.Log(enemyCount);
                spawnTimer = 0f;
            }
        }            

    }

    public void EnemySpawn()
    {
        int random = Random.Range(0, 2);

        
        if (random == 0)
        {
           GameObject enemy = Instantiate(enemy1prefab, SetRandomSpawnPos(), 
               enemy1prefab.transform.rotation); 
        }
        else
        {
           GameObject enemy = Instantiate(enemy2prefab, 
               SetRandomSpawnPos(), enemy2prefab.transform.rotation);

        }

    }
    protected Vector3 SetRandomSpawnPos()
    {        
        Vector3 spawnPos = new Vector3(
            Random.Range(minSpawnPosX, maxSpawnPosX),
            Random.Range(minSpawnPosY, maxSpawnPosY),
            Random.Range(minSpawnPosZ, maxSpawnPosZ)
            );

        return spawnPos;
    }
   
}
