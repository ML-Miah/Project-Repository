using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteract : MonoBehaviour
{
    public GameObject currentInteractObj = null; //interact with nothing at the beginning
    public GameObject blueFlameCanvas;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInteractObj && !blueFlameCanvas.activeSelf)//in project setting I set its as "E" to interact with object.
        {
            currentInteractObj.SendMessage("DoDialogue");
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) //check when in range so player can interact with the obj
    {
        if (other.CompareTag("interactObj"))
        {
            //Debug.Log("I touched the flame"); //just for testing
            currentInteractObj = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other) //when exiting trigger range return null to the obj that player is currently can interact with.
    {
        if (other.CompareTag("interactObj"))
        {   
            if(other.gameObject == currentInteractObj)
            {
                currentInteractObj.SendMessage("ExitDialogue");
                currentInteractObj = null;
            }         
        }
    }
}
