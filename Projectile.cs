using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    Rigidbody projectileRb;

    Transform playerPos;

    [SerializeField] float projectileSpeed;
  

        // Start is called before the first frame update
    void Start()
    {
       projectileRb = GetComponent<Rigidbody>();
       Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider>(), GetComponent<Collider>());



    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider>(), GetComponent<Collider>());

        //projectileRb.AddForce((playerPos.position - transform.position) * projectileSpeed, ForceMode.Impulse);
        //projectileRb.AddRelativeForce(new Vector3(0, 0, projectileSpeed),ForceMode.Force);
        //projectileRb.AddRelativeForce((playerPos.position - transform.position) * projectileSpeed, ForceMode.Force);
        projectileRb.AddForce(-Camera.main.transform.forward * projectileSpeed, ForceMode.Impulse);
        projectileRb.AddForce(-Camera.main.transform.forward * projectileSpeed, ForceMode.Force);

        //projectileRb.AddRelativeTorque(-Camera.main.transform.forward * projectileSpeed, ForceMode.Impulse);
    }

    private void OnBecameInvisible()
    {
        //Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
              
    }
}
