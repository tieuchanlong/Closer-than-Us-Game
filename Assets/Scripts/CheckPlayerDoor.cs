using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerDoor : MonoBehaviour
{
    public GameObject Player;
    
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
        if (collision.CompareTag("PlayerCheck"))
        {
            Debug.Log("PlayerCheck");
            GetComponent<DoorControl>().playercheck = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerCheck"))
        {
            GetComponent<DoorControl>().playercheck = false;
        }
    }
}
