using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Passcode : MonoBehaviour
{
    public GameObject block;
    
    string Code = "0518";
    string Nr = null;

    int NrIndex = 0;
    string alpha;

    //public Text uiText = null;
    [SerializeField] TextMeshProUGUI uiText = null;
    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        uiText.text = Nr;
    }

    public void Enter()
    {
        if(Nr == Code)
        {
            Destroy(block);
        }
    }

    public void Delete()
    {
        NrIndex++;
        Nr = null;
        uiText.text = Nr;
    }

}
