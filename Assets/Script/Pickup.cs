using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject bulletType; // Reference to the specific bullet type
    public int bulletIncreaseAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the BulletManager script on the player or another appropriate object
            PlayerAttack bulletManager = other.GetComponent<PlayerAttack>();

            if (bulletManager != null)
            {
                // Check if the bullet type exists in the bullet manager's list
                int bulletIndex = bulletManager.bulletTypes.IndexOf(bulletType);

                if (bulletIndex != -1)
                {
                    // Increase the bullet count for the specific type
                    bulletManager.bulletCounts[bulletIndex] += bulletIncreaseAmount;
                    // Destroy the pickup item
                    Destroy(gameObject);

                    bulletManager.UpdateUI();
                }
            }
        }
    }
}







