using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public bool circleStart;
    public GameObject theCircle;
    
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
    }

    private void OnTriggerEnter(Collider other)
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
