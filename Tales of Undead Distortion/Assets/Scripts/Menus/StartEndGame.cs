using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndGame : MonoBehaviour
{
    public GameObject Player;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            FindObjectOfType<GUIMenuManager>().EndGame();
        }
    }

}
