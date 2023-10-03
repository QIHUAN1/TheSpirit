using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public bool circleStart;
    public GameObject Circle;
    
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
            Circle.SetActive(true);
        }
        else
        {
            Circle.SetActive(false);
        }
    }
}
