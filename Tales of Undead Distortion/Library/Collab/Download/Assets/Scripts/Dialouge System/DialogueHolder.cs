using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textDisplay;

    public string[] sentences;
    private int index; //not assign so default is 0
    public float typeSpeed;
    public GameObject continueButton;

    void OnEnable()
    {
        StartCoroutine(Type());
    }
    void OnDisable()
    {
        index = 0;
    }
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            this.gameObject.SetActive(false);

        }

    }
}



    
    

