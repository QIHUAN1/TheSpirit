using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public bool room1;
    public bool room2;
    public bool room3;
    public bool room3_5;
    public bool room4;
    public bool room4_5;
    public bool room5;
    public bool room6;
    public bool room7;
    public bool room8;
    public bool room9;

    public GameObject room1object;
    public GameObject room2object;
    public GameObject room3object;
    public GameObject room3_5object;
    public GameObject room4object;
    public GameObject room4_5object;
    public GameObject room5object;
    public GameObject room6object;
    public GameObject room7object;
    public GameObject room8object;
    public GameObject room9object;

    private void Start()
    {
        room1object.SetActive(true);
        room2object.SetActive(false);
        room3object.SetActive(false);
        room3_5object.SetActive(false);
        room4object.SetActive(false);
        room4_5object.SetActive(false);
        room5object.SetActive(false);
        room6object.SetActive(false);
        room7object.SetActive(false);
        room8object.SetActive(false);
        room9object.SetActive(false);
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

        if (room3_5 == true)
        {
            room3_5object.SetActive(true);
        }
        else
        {
            room3_5object.SetActive(false);
        }

        if (room4 == true)
        {
            room4object.SetActive(true);
        }
        else
        {
            room4object.SetActive(false);
        }

        if (room4_5 == true)
        {
            room4_5object.SetActive(true);
        }
        else
        {
            room4_5object.SetActive(false);
        }

        if (room5 == true)
        {
            room5object.SetActive(true);
        }
        else
        {
            room5object.SetActive(false);
        }

        if (room6 == true)
        {
            room6object.SetActive(true);
        }
        else
        {
            room6object.SetActive(false);
        }

        if (room7 == true)
        {
            room7object.SetActive(true);
        }
        else
        {
            room7object.SetActive(false);
        }

        if (room8 == true)
        {
            room8object.SetActive(true);
        }
        else
        {
            room8object.SetActive(false);
        }

        if (room9 == true)
        {
            room9object.SetActive(true);
        }
        else
        {
            room9object.SetActive(false);
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

    public void Cube3()
    {
        room3 = !room3;
        room3_5 = !room3_5;
    }

    public void Cube4()
    {
        room3 = !room3;
        room4 = !room4;
    }

    public void Cube5()
    {
        room4 = !room4;
        room4_5 = !room4_5;
    }

    public void Cube6()
    {
        room4_5 = !room4_5;
        room5 = !room5;
    }

    public void Cube7()
    {
        room4 = !room4;
        room6 = !room6;
    }

    public void Cube8()
    {
        room4 = !room4;
        room7 = !room7;
    }

    public void Cube9()
    {
        room7 = !room7;
        room8 = !room8;
    }

    public void Cube10()
    {
        room8 = !room8;
        room9 = !room9;
    }

}
