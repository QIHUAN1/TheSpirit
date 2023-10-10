using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextimage : MonoBehaviour
{
    public GameObject nextOne;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            nextOne.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
