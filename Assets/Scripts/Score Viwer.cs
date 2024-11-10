using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViwer : MonoBehaviour
{
    public TMP_Text timerText;
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string myString = score.AllScore.ToString();
        timerText.text = string.Format(myString);
    }
}
