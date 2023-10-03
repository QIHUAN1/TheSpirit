using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAI : MonoBehaviour
{
    public float HP;
    [SerializeField] TextMeshProUGUI Healthpoint;

    // Start is called before the first frame update
    void Start()
    {
        HP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Healthpoint.text = "HP: " + HP.ToString("0");
    }

    public void TakeDamage ()
    {
        HP -= 1;
        if(HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
