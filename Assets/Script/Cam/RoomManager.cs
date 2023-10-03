using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public bool room1;
    public bool room2;
    public bool room3;

    public GameObject room1object;
    public GameObject room2object;
    public GameObject room3object;

    private void Start()
    {
        room1object.SetActive(true);
        room2object.SetActive(false);
        room3object.SetActive(false);
    }

    private void Update()
    {
        Rooms();
    }
    
    void Rooms()
    {
        if (room1 == true)
        {
            room1object.SetActive(true);
        }
        else
        {
            room1object.SetActive(false);
        }

        if (room2 == true)
        {
            room2object.SetActive(true);
        }
        else
        {
            room2object.SetActive(false);
        }

        if (room3 == true)
        {
            room3object.SetActive(true);
        }
        else
        {
            room3object.SetActive(false);
        }
    }

    public void Cube1()
    {
        room1 = !room1;
        room2 = !room2;
    }

    public void Cube2()
    {
        room2 = !room2;
        room3 = !room3;
    }

}
