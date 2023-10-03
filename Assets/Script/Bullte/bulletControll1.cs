using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControll1 : MonoBehaviour
{

    private bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                bulletRigidbody.velocity = Vector3.zero;
            }

            // Optionally, add any other behavior you want for the bullet on hit

            // Mark as hit to prevent multiple attachments
            hasHit = true;
        }
    }
}
