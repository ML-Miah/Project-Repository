using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    [Header("UI Open")]
     public bool UIOpen;

    [Header ("Items")]
    public GameObject InventoryUI;
    public Image[] ItemImages;

    [Header("Item Description")]
    public GameObject DesWindow;
    public Text ItemName;
    public Text ItemDes;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenInventory();
        }
    }

    public void OpenInventory()
    {
        if (UIOpen)
        {
            InventoryUI.SetActive(false);
            UIOpen = false;
            Time.timeScale = 1f;
        }

        else
        {
            InventoryUI.SetActive(true);
            UIOpen = !UIOpen;
            Time.timeScale = 0f;
        }
        
    }

    //Add item to the items list
    public void PickUp (GameObject item)
    {
        items.Add(item);
        UpdateInventory();
    }

    void UpdateInventory()
    {
        HideAll();

        for (int i = 0; i < items.Count; i++)
        {
            ItemImages[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            ItemImages[i].gameObject.SetActive(true);
        }
    }

    // Hide all item images

    void HideAll()
    {
        foreach (var i in ItemImages)
        {
            i.gameObject.SetActive(false);
        }
    }

    public void ShowTitle(int ID)
    {
        ItemName.text = items[ID].name;
        ItemDes.text = items[ID].GetComponent<Items>().Description;
        ItemName.gameObject.SetActive(true);
        ItemDes.gameObject.SetActive(true);
    }

    public void HideInventoryText()
    {
        ItemName.gameObject.SetActive(false);
        ItemDes.gameObject.SetActive(false);
    }
}
