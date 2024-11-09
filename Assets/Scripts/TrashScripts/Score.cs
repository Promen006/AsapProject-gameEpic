using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int AllScore;
    // Start is called before the first frame update
    void Start()
    {
        AllScore = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trash1")
        {
            Destroy(other.gameObject);
            AllScore += 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
           
    }

}
