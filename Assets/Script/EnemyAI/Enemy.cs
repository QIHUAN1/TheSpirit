using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public LayerMask isGorund, isPlayer;

    //idle
    public bool isIdle;

    //moveing
    public Vector3 walkPoint;
    public bool walkPointSet;

    public Transform walkPointRangeMax;
    public Transform walkPointRangeMin;



    //attack
    public float timeBetweenAttacks;
    bool alreadyAttack;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.Find("Avatar").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        if (!playerInAttackRange && !playerInSightRange) 
        { 
            if(isIdle == false)
            {
                Moving();
            }

            else
            {
                Idleing();
            }
        }
        if (!playerInAttackRange && playerInSightRange) Chasing();
        if (playerInAttackRange && playerInSightRange) Attacking();

    }

    private void Idleing()
    {

    }    

    private void Moving()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkpoint = transform.position - walkPoint;
        if(distanceToWalkpoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(walkPointRangeMin.position.z, walkPointRangeMax.position.z);
        float randomX = Random.Range(walkPointRangeMin.position.x, walkPointRangeMax.position.x);

        walkPoint = new Vector3(randomX, transform.position.y,randomZ);

        //walkPointSet = true;

        if (Physics.Raycast(walkPoint, -transform.up, 10f, isGorund))
        {
           walkPointSet = true;
        }
            

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        //Gizmos.DrawSphere(transform.position, walkPointRange);

    }

    private void Chasing()
    {
        agent.SetDestination(player.position);
    }

    private void Attacking()
    {

        transform.LookAt(player);

        if(!alreadyAttack)
        {
            alreadyAttack = true;
            Invoke("ResetAttack", timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttack = false;
    }

}
