using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public float HP;
    [SerializeField] TextMeshProUGUI Healthpoint;

    //control mode
    public Transform player;
    public float followspeed = 5f;
    private Vector3 initialOffset;
    public bool starttest;


    public bool playerSpell = false;
    public GameObject timer;
    public Slider slider;
    float countdown = 20f;

    // Start is called before the first frame update
    void Start()
    {
        HP = 3;
        timer.SetActive(false);
        starttest = false;
    }

    // Update is called once per frame
    void Update()
    {
        Healthpoint.text = "HP: " + HP.ToString("0");

        if(playerSpell == true)
        {
            ControlMode();
        }

        if (starttest == true)
        {
            initialOffset = transform.position - player.position;
        }
        else
        {
            
        }
    }

    void ControlMode()

    {
        starttest = true;
        starttest = false;

        Vector3 targetPosition = player.position + initialOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followspeed * Time.deltaTime);

        timer.SetActive(true);
        countdown -= 1 * Time.deltaTime;
        slider.value = countdown;
        if(countdown <= 0)
        {
            countdown = 0;
            playerSpell = false;
            countdown = 20;
        }
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
