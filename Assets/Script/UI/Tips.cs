using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public GameObject tutorial;
    public bool openOrNot;
    // Start is called before the first frame update
    void Start()
    {
        openOrNot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {

            openOrNot = !openOrNot;
        }

        if(openOrNot == true)
        {
            tutorial.SetActive(true);
        }
        else
        {
            tutorial.SetActive(false);
        }
        
    }
}
