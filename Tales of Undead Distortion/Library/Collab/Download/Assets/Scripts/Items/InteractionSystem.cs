using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header ("Parameters for Detections")]

    // Point of Detection
    public Transform DetPoint;

    // Radius of Dectection
    public float DetRad = 0.2f;
    // Layer of Dectection


    //Examine Window Object
    public LayerMask DetLayer;

    //Tigger Cached Object
    public GameObject DetectedItem;

    [Header("Examine Fields")]

    public GameObject examineBox;
    public Text examineText;
    public bool beingExamined = false;

    

    

   

    private void Update()
    {
        if (DetectItem())
        {
            if (InteractionInput())
            {
               DetectedItem.GetComponent<Items>().Interact();

                DetectedItem.GetComponent<DialogueTrigger>().TriggerDialogue();

            }
        }
    }

    private bool InteractionInput()
    {

        return Input.GetKeyDown(KeyCode.Return);
        
    }

   private bool DetectItem()
    {

        Collider2D Interactable = Physics2D.OverlapCircle(DetPoint.position, DetRad, DetLayer);
        
        if (Interactable == null)
        {
           // examineBox.SetActive(false);
          //  Time.timeScale = 1f;
          //  beingExamined = false;

            return true;
        }

        else
        {
            DetectedItem = Interactable.gameObject;
            return true;
        }
        
    }


    /*public void ExamineObject(Items Item)
    {
        if (beingExamined)
        {
      
            examineBox.SetActive(false);
            Time.timeScale = 1f;
            beingExamined = false;
            Debug.Log("BYYYYYE");
        }

        else
        {
            //Display examine box
            examineBox.SetActive(true);

            //Show item description text
            examineText.text = Item.ExamineText;

            //Pause Background gameplay and movement
            Time.timeScale = 0f;

            beingExamined = true;
            Debug.Log("LOOKY LOOKY");

          
        }
        
    } */

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireSphere(transform.position, DetRad);
    }







}
