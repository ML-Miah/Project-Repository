using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Items : MonoBehaviour
{
    
   
    public enum TypeInteraction { None, PickUp, Examine}
    public TypeInteraction InteractionType;
    
    public enum InventoryType { None, Equipment, Collectable}
    public InventoryType ItemType;

  



   // [Header("Examine")]
   // public string ExamineText;

    [Header("Inventory Description")]
    [TextArea(3, 10)]
    public string DescriptionText;

    [Header("Custom Event")]
    public UnityEvent CustEvent;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 9;
    }

    public void Interact()
    {
        switch (InteractionType)
        {
            case TypeInteraction.PickUp:

                // Add Item to list - TEMP

                FindObjectOfType<InventoryManager>().PickUp(this);
                GetComponent<DialogueTrigger>().TriggerDialogue();




                Debug.Log("MINE NOW");

                gameObject.SetActive(false);
                break;

                case TypeInteraction.Examine:
                //Calling Examine Object in the Interaction System
                
                GetComponent<DialogueTrigger>().TriggerDialogue();
             break;

            

                
                

            default:
                Debug.Log("YOU FORGOT TO GIVE IT A TYPE");
                break;
        }

        //Call the custom event
        CustEvent.Invoke();
    }

}

