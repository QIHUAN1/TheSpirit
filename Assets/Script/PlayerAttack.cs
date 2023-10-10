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

    [SerializeField] TextMeshProUGUI bullteNum;
    [SerializeField] TextMeshProUGUI bullteName;

    [SerializeField] TextMeshProUGUI redB;
    [SerializeField] TextMeshProUGUI yellowB;
    [SerializeField] TextMeshProUGUI blueB;


    public Slider slider;


    public List<GameObject> bulletTypes;
    public List<float> bulletCounts;
    private int selectedBulletIndex = 0;


    //public GameObject effact;

    public LineRenderer lineRenderer;



    // Start is called before the first frame update
    void Start()
    {
        readytoShoot = true;
        cooldown = 2;

        UpdateUI();

    }

    public void UpdateUI()
    {
        if (bullteName != null && bullteNum != null)
        {
            // Update the UI text elements with the selected bullet's name and count
            bullteName.text = bulletTypes[selectedBulletIndex].name;
            bullteNum.text = "Spell :" + bulletCounts[selectedBulletIndex].ToString();

            redB.text = "Red Spell : " + bulletCounts[0];
            yellowB.text = "Yellow Spell : " + bulletCounts[1];
            blueB.text = "Blue Spell : " + bulletCounts[2];
        }
    }

    // Update is called once per frame
    void Update()
    {
        SwitchBullte();
        
        slider.value = cooldown;


        if (Input.GetMouseButton(1))
        {
            aimMode = true;
        }
        else
        {
            aimMode = false;
            lineRenderer.enabled = false;
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

    void SwitchBullte()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectedBulletIndex--;
            if (selectedBulletIndex < 0)
                selectedBulletIndex = bulletTypes.Count - 1;

            UpdateUI();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            selectedBulletIndex++;
            if (selectedBulletIndex >= bulletTypes.Count)
                selectedBulletIndex = 0;

            UpdateUI();
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
        lineRenderer.enabled = true;
        if (Physics.Raycast(ray, out hitinfo, 60f))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hitinfo.point);

        }
        else
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 60f, Color.red);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * 60f);
        }
    }

    void Shoot()
    {
        if(readytoShoot == true)
        {

            if (selectedBulletIndex >= 0 && selectedBulletIndex < bulletCounts.Count)
            {

                if (bulletCounts[selectedBulletIndex] > 0)
                {
                    RaycastHit hitinfo;
                    Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

                    if (Physics.Raycast(ray, out hitinfo, 60f, aimRay))
                    {
                        Debug.Log(hitinfo.transform.name);
                        //Destroy(hitinfo.transform.gameObject);

                        EnemyAI enemy = hitinfo.transform.GetComponent<EnemyAI>();
                        if (enemy != null)
                        {
                            //enemy.TakeDamage();

                            Instantiate(bulletTypes[selectedBulletIndex], hitinfo.point, Quaternion.LookRotation(hitinfo.normal));
                        }



                    }

                    bulletCounts[selectedBulletIndex]--;
                    UpdateUI();

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

}
