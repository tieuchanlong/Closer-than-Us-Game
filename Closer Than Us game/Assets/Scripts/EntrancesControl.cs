using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrancesControl : MonoBehaviour
{
    public int SceneDoor1;
    public int SceneDoor2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Door1"))
        {
            if  (Input.GetKey(KeyCode.E)) SceneManager.LoadScene(SceneDoor1);
        }

        if (collision.CompareTag("Door2"))
        {
            if (Input.GetKey(KeyCode.E)) SceneManager.LoadScene(SceneDoor2);
        }
    }
}
