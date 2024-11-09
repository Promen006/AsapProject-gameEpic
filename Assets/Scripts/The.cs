using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class The : MonoBehaviour
{
    public static The Instance { get; private set; }
    // Start is called before the first frame update
    private void Start()
    {
        Instance ??= this;

        if(Instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
