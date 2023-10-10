using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSw6 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RoomManager rm = gameObject.GetComponentInParent<RoomManager>();
        rm.Cube6();
    }
}
