using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public GameObject tutorial;
    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            tutorial.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            tutorial.SetActive(false);
        }
    }
}
