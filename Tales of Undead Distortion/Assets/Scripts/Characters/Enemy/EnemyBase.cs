using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public string EnemyName;
    public float MovementSpeed;
    public GameObject Player;

    public float Distance;
    public int Damage = 10;

    
    private void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < Distance)
            {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, MovementSpeed * Time.deltaTime);
        }
    }

   

}
