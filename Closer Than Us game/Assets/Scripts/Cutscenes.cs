using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour
{
    public int cutscene = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cutscene == 1)
        {
            Dialogue.index = 0;
            Dialogue.initial_index = 0;
            Dialogue.sentence_numbers = 2;
        }
    }
}
