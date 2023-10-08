using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//red boom -1 hp

public class bulletControll1 : MonoBehaviour
{

    private bool hasHit = false;

    [SerializeField]private bool canRelease = false;
    
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Release();

    }

    void Release()
    {
        if(canRelease == true)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                EnemyAI enemyAI = gameObject.GetComponentInParent<EnemyAI>();
                if (enemyAI != null)
                {
                    enemyAI.TakeDamage();
                    Destroy(gameObject);
                }

            }
        }
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!hasHit && collision.gameObject.CompareTag("Monster"))
        {
            // Attach the bullet to the enemy
            Transform enemyTransform = collision.gameObject.transform;
            transform.SetParent(enemyTransform);

            // Disable any movement or physics on the bullet
            Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.isKinematic = true;
                //bulletRigidbody.velocity = Vector3.zero;
            }


            hasHit = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cylinder"))
        {

            canRelease = true;
            Debug.Log("Player collided with the cube!");


        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cylinder"))
        {

            canRelease = false;
            Debug.Log("Player go away!");
        }
    }
}
