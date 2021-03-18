using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField]
    private int MaxTriggerAmount = 1;
    public int TriggerCount = 0;


    public GameObject player;
    public GameObject TalkingCharacter;
    public GameObject EnemySpawn;
    public GameObject ItemRevel;

    public Dialogue CutSceneDialouge;

    private void Start()
    {
        TalkingCharacter.SetActive(false);
        ItemRevel.SetActive(false);
        EnemySpawn.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            TriggerCount++;

            if (TriggerCount == MaxTriggerAmount)

            {
                FindObjectOfType<DialougeManager>().StartDialogue(CutSceneDialouge);
                TalkingCharacter.SetActive(true);
                ItemRevel.SetActive(true);
                EnemySpawn.SetActive(true);
            }


            else
            {
                return;
            }
        }
    }
}

    


       

