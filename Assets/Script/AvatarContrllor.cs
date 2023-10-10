using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AvatarContrllor : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    [SerializeField]private float newSpeed;

    //hp
    [SerializeField] TextMeshProUGUI Healthpoint;
    public float healthPoint;
    bool canHurt;

    //potion
    [SerializeField] TextMeshProUGUI potionUI;
    public float potionNum;

    public float rotateSpeed;


    // Start is called before the first frame update
    void Start()
    {
        healthPoint = 4;
        canHurt = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        LookatMouse();

        Healthpoint.text = "HP: " + healthPoint.ToString("0");

        if (healthPoint <= 0)
        {
            Debug.Log("gameover");
        }

        Potion();
        potionUI.text = "Potion: " + potionNum.ToString("0");
    }

    void Movement()
    {
        //speed up
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 75;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 50;
        }


        newSpeed = speed;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            newSpeed = speed * 1.5f;
        }

        else
        {
            newSpeed = speed;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * newSpeed * Time.deltaTime);
        }

    }

    void LookatMouse()
    {
        Plane Playerplane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if(Playerplane.Raycast(ray,out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetrotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("shadow"))
        {
          if(canHurt)
            {
                healthPoint -= 1;
                canHurt = false;
                Invoke("CanHurtAgain", 2f);
            }

        }
    }

    void CanHurtAgain()
    {
        canHurt = true;
    }

    void Potion()
    {
        if(potionNum <= 0)
        {
            potionNum = 0;
        }

        if(potionNum > 0)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                healthPoint += 1;
                potionNum -= 1;
            }
        }
    }

}
