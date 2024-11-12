using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreprec : MonoBehaviour
{
    public TMP_Text timerText;
    // Start is called before the first frame update
    void Update()
    {
        string myString = Score.AllScore.ToString();
        timerText.text = string.Format(myString);
        
    }
    
}
