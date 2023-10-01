using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] LayerMask aimRay;


    [SerializeField] Transform avatarAim;
    [SerializeField] LineRenderer lr;


    public bool aimMode;
    public bool readytoShoot;

    
    // Start is called before the first frame update
    void Start()
    {
        readytoShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            aimMode = true;
        }
        else
        {
            aimMode = false;
        }

        if(aimMode == true)
        {
            Aim();
            
            if(Input.GetMouseButton(0))
            {
                Shoot();
            }   

            
        }
    }

    void Aim()
    {
        //aim line
        RaycastHit hitinfo;
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(ray, out hitinfo, 60f,aimRay))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);
            lr.enabled = true;
            lr.SetPosition(0, avatarAim.transform.position);
            lr.SetPosition(1, hitinfo.point);

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 60f, Color.green);
            lr.enabled = false;
        }
    }

    void Shoot()
    {
        if(readytoShoot == true)
        {
            RaycastHit hitinfo;
            Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

            if (Physics.Raycast(ray, out hitinfo, 60f, aimRay))
            {           
                Debug.Log(hitinfo.transform.name);
                //Destroy(hitinfo.transform.gameObject);
            }

            readytoShoot = false;
            Invoke("CountDown", 3f);
        }
    }

    void CountDown()
    {
        readytoShoot = true;
    }
}
