using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching2 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        RoomManager rm = gameObject.GetComponentInParent<RoomManager>();
        rm.Cube2();
    }
}
