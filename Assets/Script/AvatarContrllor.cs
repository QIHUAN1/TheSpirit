using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarContrllor : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6;
    [SerializeField]private float newSpeed;

    public float rotateSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        LookatMouse();

    }

    void Movement()
    {
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
}
