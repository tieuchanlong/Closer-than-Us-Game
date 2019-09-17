using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && PauseScreen.active == false)
        {
            PauseScreen.SetActive(true);
        }
    }

    public void Resume()
    {
        PauseScreen.SetActive(false);
    }
}
