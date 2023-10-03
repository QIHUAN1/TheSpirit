using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public GameObject theCircle;


    public bool circleStart = false;


    // Start is called before the first frame update
    void Start()
    {
        circleStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(circleStart == true)
        {
            theCircle.SetActive(true);
        }
        else
        {
            theCircle.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            circleStart = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            circleStart = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            circleStart = false;
        }
    }
}
