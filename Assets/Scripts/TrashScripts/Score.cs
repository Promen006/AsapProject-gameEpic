using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int AllScore;
    // Start is called before the first frame update
    void Start()
    {
        AllScore = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<LayerTrash>())
        {
            Destroy(other.gameObject);
            AllScore += 3;
        }

        if (other.GetComponent<FlyTrash>())
        {
            Destroy(other.gameObject);
            AllScore += 5;
        }
        if (other.GetComponent<BouncingObject>())
        {
            Destroy(other.gameObject);
            AllScore += 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
           
    }

}
