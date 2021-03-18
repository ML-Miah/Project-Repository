using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationChange : MonoBehaviour
{
   // public Transform NewPlayerPosition;
    public GameObject player;
    public GameObject TeleportTo;


    private Vector2 TravelPos;

    private void Start()
    {
      //  TeleportTo = TravelPos;
       // TravelPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != player)
        {
            Debug.Log("NO ENTRY FOR YOU");
            return;
        }
     

        if (collision.gameObject == player)
        {
            

            Debug.Log("CHANGE PLACES");
            // collision.gameObject.transform.position = NewPlayerPosition.position;
            collision.gameObject.transform.position = TeleportTo.transform.position;
        }
    }
}