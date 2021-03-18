using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Items> itemsCollected = new List<Items>();

    [Header("UI Open")]
     public bool UIOpen;

    [Header ("Inventory UI")]
    public GameObject InventoryUI;
    public GameObject LockedUI;

    [Header("Items")]
    public Image[] ItemImages;

    [Header("Item ExamineText")]
    public GameObject DesWindow;
    public Text ItemName;
    public Text ItemDescription;

    private void Start()
    {
        LockedUI.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }
    }

    public void OpenInventory()
    {
        if (UIOpen)
        {
            FindObjectOfType<GUIMenuManager>().CloseInventory();
            UIOpen = false;
           
        }

        else
        {
            FindObjectOfType<GUIMenuManager>().OpenInventory();
            UIOpen = true;
        }
        
    }

   // Add item to the items list
     public void PickUp (Items item)
    {

       itemsCollected.Add(item);
       UpdateInventory();

      }


    public void UpdateInventory()
    {
        HideAll();

        for (int i = 0; i < itemsCollected.Count; i++)
        {
            ItemImages[i].sprite = itemsCollected[i].GetComponent<SpriteRenderer>().sprite;
            ItemImages[i].gameObject.SetActive(true);
        }
    }

    // Hide all item images

    public void HideAll()
    {
        foreach (var items in ItemImages)
        {
            items.gameObject.SetActive(false);
        }
    }

    public void ShowItemDetails(int ID)
    {
        ItemName.text = itemsCollected[ID].name;
        ItemDescription.text = itemsCollected[ID].GetComponent<Items>().DescriptionText;
        ItemName.gameObject.SetActive(true);
        ItemDescription.gameObject.SetActive(true);
    }

    public void HideItemDetails()
    {
        ItemName.gameObject.SetActive(false);
        ItemDescription.gameObject.SetActive(false);
    }

    

  
}
