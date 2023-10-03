using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    public GameObject Room1;
    public GameObject Room2;

    public bool isRoom1;

    // Start is called before the first frame update
    void Start()
    {
        isRoom1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoom1 == true)
        {
            Room1.SetActive(true);
            Room2.SetActive(false);
        }

        else
        {
            Room1.SetActive(false);
            Room2.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRoom1 = !isRoom1;
        }
    }

}