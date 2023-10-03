using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] LayerMask aimRay;

    [SerializeField] Transform avatarAim;

    public bool aimMode;
    public bool readytoShoot;

    public float cooldown;


    public float bullte;
    [SerializeField] TextMeshProUGUI bullteNum;

    public Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        readytoShoot = true;
        cooldown = 2;

        bullte = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(bullte < 0)
        {
            bullte = 0;
        }


        bullteNum.text = "Bullte:" + bullte.ToString("0");
        slider.value = cooldown;


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

    private void FixedUpdate()
    {

        if (cooldown == 2)
        {
            readytoShoot = true;
        }

        if (cooldown > 2)
        {
            cooldown = 2;
        }


        if (cooldown < 2)
        {
            cooldown += 1 * Time.deltaTime;
        }
    }

    void Aim()
    {
        //aim line
        RaycastHit hitinfo;
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(ray, out hitinfo, 60f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 60f, Color.green);
        }
    }

    void Shoot()
    {
        if(readytoShoot == true)
        {
            
            if(bullte > 0)
            {

                
                RaycastHit hitinfo;
                Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

                if (Physics.Raycast(ray, out hitinfo, 60f, aimRay))
                {
                    Debug.Log(hitinfo.transform.name);
                    //Destroy(hitinfo.transform.gameObject);

                    EnemyAI enemyAI = hitinfo.transform.GetComponent<EnemyAI>();
                    if(enemyAI != null)
                    {
                        enemyAI.TakeDamage();
                    }
                    
                }

                bullte -= 1;

                readytoShoot = false;
                cooldown = 0;
            }
            
            else
            {
                Debug.Log("no bullet lmao");
            }
        }
    }

}
