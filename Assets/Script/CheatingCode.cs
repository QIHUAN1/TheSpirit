using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatingCode : MonoBehaviour
{

    public GameObject red;
    public GameObject blue;
    public GameObject yellow;

    public GameObject potion;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(red,transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(yellow, transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(blue, transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(potion, transform.position, Quaternion.identity);
        }
    }
}
