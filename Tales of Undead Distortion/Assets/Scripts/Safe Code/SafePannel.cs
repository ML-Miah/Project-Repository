using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePannel : MonoBehaviour
{
    [SerializeField]

    public Text codeText;
    public string codeTextValue = "";
    public string SafeCombo = "1234";

    

    private void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == SafeCombo)
        {
            SafeBase.isSafeOpened = true;
        }

        if (codeTextValue.Length >= 4)
        {
            codeTextValue = " ";
            return;
        }
    }

    public void AddDigit (string Digit)
    {
        codeTextValue += Digit;
    }

}
