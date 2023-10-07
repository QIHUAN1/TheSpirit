using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAll : MonoBehaviour
{
    #region Singleton

    public static GameAll instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
