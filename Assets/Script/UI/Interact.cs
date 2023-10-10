using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject notice;
    public bool playerTigger;

    public GameObject Art;
    public bool artTrigger;

    // Start is called before the first frame update
    void Start()
    {
        playerTigger = false;
        artTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTigger == false)
        {
            notice.SetActive(false);
        }

        else
        {
            notice.SetActive(true);
        }


        if(playerTigger == true && Input.GetKeyDown(KeyCode.Space))
        {
            artTrigger = !artTrigger;
        }

        if(artTrigger == true)
        {
            Art.SetActive(true);
        }
        else
        {
            Art.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log(111);

            playerTigger = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log(111);

            playerTigger = false;
            artTrigger = false;
        }

    }
}
