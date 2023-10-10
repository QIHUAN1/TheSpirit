using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSw13 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            RoomManager rm = gameObject.GetComponentInParent<RoomManager>();
            rm.Cube13();
        }

    }
}
