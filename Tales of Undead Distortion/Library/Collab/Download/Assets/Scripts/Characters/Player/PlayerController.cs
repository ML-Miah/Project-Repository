using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : CharacterBase
{
    public int CurrentHP;
    public int MaxHP;

    public GameObject Enemy;

    public HealthBarUI HPBar;
    void Start()
    {
        CurrentHP = MaxHP;
        HPBar.SetMaxHealth(MaxHP);
    }

    // Update is called once per frame
    void Update()
    {
        ControlledMove();

        CheckHP();

       
    }

    void CheckHP()
    {
        HPBar.SetHealth(CurrentHP);

        if (CurrentHP <= 0)
        {
            Dies();
        }

        else
        {
            return;
        }
    }

    private bool InteractionInput()
    {

        return Input.GetKeyDown(KeyCode.U);

    }

    

    public void OnTriggerEnter2D(Collider2D Other)
    {
       

        HealthItem health = Other.GetComponent<HealthItem>();

            if (health != null && CurrentHP < MaxHP)
            {
                CurrentHP += health.HealthAmount;
            
            }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      

        if (collision.gameObject.tag == ("Enemy"))
        {
            CurrentHP -= collision.gameObject.GetComponent<EnemyBase>().Damage;
            Debug.Log("OWCH");
        }
    }



}
