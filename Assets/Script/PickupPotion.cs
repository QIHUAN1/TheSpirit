using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPotion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the BulletManager script on the player or another appropriate object
            AvatarContrllor avatarcontroller = other.GetComponent<AvatarContrllor>();

            avatarcontroller.potionNum += 1;
            Destroy(gameObject);
        }
    }
}
