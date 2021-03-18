using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : EnemyBase
{
    [Header ("Patrol Points")]
    public Transform PP1;
    public Transform PP2;

    [Header("Target")]
    public Transform PPT;

    [Header("Damage")]
    public float TotalDamage = 10;

    [Header("Direction")]

    public Vector2 direction;

    private void Awake()
    {
        //Patrol Target is currently partol point 1
        PPT = PP1;
    }


    private void Start()
    {
     
    }

    private void Update()
    {
        Move();
    }

    //Overide the movement from the EnemyBase.
    override public void Move()
    {
        base.Move();
        

        //If player not close enough move to Patroling points.
        if (Vector3.Distance(transform.position, Player.transform.position) > Distance)
        {
            // Switches way point target once one is reached
            if (Vector3.Distance(transform.position, PP1.position) < 0.01f)
            {
                PPT = PP2;
            }

            if (Vector3.Distance(transform.position, PP2.position) < 0.01f)
            {
                PPT = PP1;
            }

            
            //Go towards player gameObject
            transform.position = Vector3.MoveTowards(transform.position, PPT.position, MovementSpeed * Time.deltaTime);
        }
    }







}


