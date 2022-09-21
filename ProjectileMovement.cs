using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float velocity;

    Rigidbody projectileRb;

    GameManager gameManager;
    private int pointValue = 1;

    public int enemiesDown = 0;

    public float GetProjectileVelocity()
    {
        return velocity;
    }
    // Start is called before the first frame update
    void Start()
    {

        projectileRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        projectileRb.AddForce(Camera.main.transform.forward * GetProjectileVelocity(), ForceMode.Impulse);
        projectileRb.AddTorque(Camera.main.transform.forward * GetProjectileVelocity(), ForceMode.Impulse);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag != "Player"
            && collision.gameObject.tag != "Terrain" && collision.gameObject.tag == "Enemy")
        {
            gameManager.UpdateScore(pointValue);
            gameManager.EnemiesDown++;
            Destroy(collision.gameObject);
            gameManager.PlayExplosionSound();
            Destroy(gameObject);
            


        }
    }
    

}
