using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnemyAI : MonoBehaviour
{
    //health
    public float HP;
    [SerializeField] TextMeshProUGUI Healthpoint;


    //control mode - blue
    private float followspeed = 16f;
    private float newSpeed;
    private CharacterController characterController;
    [SerializeField]private bool isControllerEnabled = true;

    public bool playerSpell = false;
    public GameObject timer;
    public Slider slider;
    public float countdown = 20f;

    // Start is called before the first frame update
    void Start()
    {
        HP = 3;
        timer.SetActive(false);
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Healthpoint.text = "HP: " + HP.ToString("0");

        if(playerSpell == true)
        {
            ControlMode();
        }
        
       
    }

    void ControlMode()

    {
        isControllerEnabled = true;
        characterController.enabled = isControllerEnabled;
        Movement();

        timer.SetActive(true);
        countdown -= 1 * Time.deltaTime;
        slider.value = countdown;
        if(countdown <= 0)
        {
            countdown = 0;
            playerSpell = false;
            isControllerEnabled = false ;
            characterController.enabled = isControllerEnabled;
            countdown = 20;
        }
    }

    void Movement()
    {
        newSpeed = followspeed;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            newSpeed = followspeed * 1.5f;
        }

        else
        {
            newSpeed = followspeed;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            characterController.Move(direction * newSpeed * Time.deltaTime);
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
