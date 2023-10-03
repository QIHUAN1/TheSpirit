using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching2 : MonoBehaviour
{
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
        RoomManager rm = gameObject.GetComponentInParent<RoomManager>();
        rm.Cube2();
    }
}
