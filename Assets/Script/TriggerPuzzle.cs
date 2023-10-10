using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPuzzle : MonoBehaviour
{
    public GameObject block;
    public bool isTriggered;
    
    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered == false)
        {
            block.SetActive(true);
        } 
        else
        {
            block.SetActive(false);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Monster"))
        { 
            //Debug.Log(111);
            isTriggered = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Monster"))
        {
            //Debug.Log(111);
            isTriggered = false;

        }

    }

}
