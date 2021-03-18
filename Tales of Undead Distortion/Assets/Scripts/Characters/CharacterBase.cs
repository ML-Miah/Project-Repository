using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public string characterName;
    public float moveSpeed;
    public Animator PlayerAnimation;
    public AudioSource audioSrc;
    bool isMoving = false;

    public void ControlledMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            PlayerAnimation.Play("MoveLeft");
            PlayerAnimation.SetBool("IsStop", false);
            isMoving = true;
            if (isMoving)
            {
                if (!audioSrc.isPlaying)
                    audioSrc.Play();

            }
            else
                audioSrc.Stop();
        }

        if (Input.GetKeyUp("a"))
        {
            PlayerAnimation.SetBool("IsStop", true);
            isMoving = false;
        }
       
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            PlayerAnimation.Play("MoveRight");
            PlayerAnimation.SetBool("IsStop", false);
            isMoving = true;
            if (isMoving)
            {
                if (!audioSrc.isPlaying)
                    audioSrc.Play();

            }
            else
                audioSrc.Stop();
        }

        if (Input.GetKeyUp("d"))
        {
            PlayerAnimation.SetBool("IsStop", true);
            isMoving = false;
        }


        if (Input.GetKey(KeyCode.W))
        {
           
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            PlayerAnimation.Play("MoveBack");
            PlayerAnimation.SetBool("IsStop", false);
            isMoving = true;
            if (isMoving)
            {
                if (!audioSrc.isPlaying)
                    audioSrc.Play();

            }
            else
                audioSrc.Stop();

        }
        if (Input.GetKeyUp("w"))
        {
            PlayerAnimation.SetBool("IsStop", true);
            isMoving = false;
        }


        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            PlayerAnimation.Play("MoveForward");
            PlayerAnimation.SetBool("IsStop", false);
            isMoving = true;
            if (isMoving)
            {
                if (!audioSrc.isPlaying)
                    audioSrc.Play();

            }
            else
                audioSrc.Stop();
        }
        if (Input.GetKeyUp("s"))
        {
            PlayerAnimation.SetBool("IsStop", true);
            isMoving = false;
        }
        



    }

    public void Dies()
    {
        FindObjectOfType<GUIMenuManager>().GameOver();
        Destroy(gameObject);
        
    }

}
