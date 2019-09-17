using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    private bool dooropen = false;
    private bool doorstay = true;
    private bool doorstuck = false;
    private int opentime = -1;

    public bool playercheck = false;

    public float speed = 5f;

    public GameObject door;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorstay == false)
        {
            if (opentime <= 50 || playercheck == false) opentime += 1;

            if (opentime > 50)
            {
                dooropen = false;
                doorstuck = true;
            }

            if (opentime > 100)
            {
                doorstuck = false;
            }

            if (opentime > 150)
            {
                doorstay = true;
                dooropen = true;
                opentime = -1;
            }

            if (dooropen == true)
            {
                door.transform.Translate(0, speed, 0);
            }
            else if (dooropen == false && doorstuck == false && playercheck == false)
            {
                door.transform.Translate(0, -speed, 0);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            door = collision.gameObject;
            if (Input.GetKeyDown(KeyCode.E) && opentime == -1)
            {
                if (doorstay == true)
                {
                    dooropen = true;
                    doorstay = false;
                    doorstuck = false;
                    opentime = 0;
                }

            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (doorstay == true)
        {
            door = null;
        }
    }
}
