using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedItems : MonoBehaviour
{
    public Items ItemRequired;
    //public Sprite Opened;
    public GameObject Locked;
    public GameObject Unlocked;

    //private SpriteRenderer spriteRend;
  //  private Collider2D theCollider;

    private void Start()
    {
        Locked.SetActive(true);
        Unlocked.SetActive(false);

        //spriteRend = GetComponent<SpriteRenderer>();
       // theCollider = GetComponent<Collider2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        InventoryManager inventory = collision.gameObject.GetComponent<InventoryManager>();
        
        {
            if (inventory != null)
            {

                for (int i = 0; i < inventory.itemsCollected.Count; i++)
                {
                    if (inventory.itemsCollected[i] == ItemRequired)
                    {

                        Locked.SetActive(false);
                        Unlocked.SetActive(true);
                        // spriteRend.sprite = Opened;
                        //theCollider.isTrigger = true;
                        break;
                    }
                }

            }
        }
    }

}
