using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COnversationControl : MonoBehaviour
{
    public GameObject[] sentences;
    private int conversation_counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sentences[conversation_counter].SetActive(true);
            conversation_counter += 1;
        }
    }
}
