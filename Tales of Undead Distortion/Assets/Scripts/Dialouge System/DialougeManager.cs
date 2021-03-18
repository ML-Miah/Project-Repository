using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<Sprite> CharacterImage;

    [Header ("UI - Text Box Holder")]
    public Text DialougeText;

    [Header ("UI - Image/Sprite Holder")]
    public Image DialougeImage;



    public GameObject DialougeBox;
    void Start()
    {
        sentences = new Queue<string>();
        CharacterImage = new Queue<Sprite>();

        DialougeBox.SetActive(false);
        Time.timeScale = 1f;
    }


    public void StartDialogue(Dialogue dialogue )
    {
        DialougeBox.SetActive(true);
        Time.timeScale = 0.0f;
      
        
        
        
        

        sentences.Clear();
        CharacterImage.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            
        }
        
        foreach (Sprite picture in dialogue.CharacterPortrait)
        {
            CharacterImage.Enqueue(picture);
        }
        

        DisplayNextSentence();  
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
           

            EndDialogue();
            return;

            
        }

        if (CharacterImage.Count == 0)
        {

            return;
        }




        Sprite picture = CharacterImage.Dequeue();
        DialougeImage.sprite = picture;
        

        string sentence = sentences.Dequeue();
        DialougeText.text = sentence;


    }

    public void EndDialogue()
    {
        DialougeBox.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("End of Chat");
    }
}
