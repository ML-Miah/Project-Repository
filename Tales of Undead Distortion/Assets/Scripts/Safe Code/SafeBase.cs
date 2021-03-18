using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBase : MonoBehaviour
{
    public static bool isSafeOpened = false;

    public GameObject Player;
    [Header("Items in safe")]

   // public GameObject IteminSafe;

   // public GameObject[] SafeItems;


    [SerializeField]
    public GameObject codePanel;
   // public GameObject closedSafe;
    //public GameObject openedSafe;
    public GameObject Safe;
  //  public GameObject[] SafeItems;


    private void Start()
    {
        Safe.SetActive(true);
        codePanel.SetActive(false);
       // closedSafe.SetActive(true);
       // openedSafe.SetActive(false);
       // IteminSafe.SetActive(false);
      //  SafeItems.setActive(false);
        
    }

    private void Update()
    {
        if (isSafeOpened)
        {
            Safe.SetActive(false);
            codePanel.SetActive(false);
          //  closedSafe.SetActive(false);
           // openedSafe.SetActive(true);
           // IteminSafe.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == Player && !isSafeOpened)
        {
            codePanel.SetActive(true);
            Debug.Log("SAFE TIME");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == Player)
        {
            codePanel.SetActive(false);
        }
    }
}
