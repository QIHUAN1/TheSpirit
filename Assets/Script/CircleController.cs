using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public GameObject theCircle;


    public delegate void BullStateChanged(bool newState);
    public static event BullStateChanged OnBullStateChanged;

    public bool circleStart;


    public bool IsBullActive
    {
        get { return circleStart; }
        set
        {
            circleStart = value;
            // Trigger the event when the bull state changes
            OnBullStateChanged?.Invoke(circleStart);
        }
    }

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
