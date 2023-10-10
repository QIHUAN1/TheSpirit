using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSw4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RoomManager rm = gameObject.GetComponentInParent<RoomManager>();
            rm.Cube4();
        }

    }
}
