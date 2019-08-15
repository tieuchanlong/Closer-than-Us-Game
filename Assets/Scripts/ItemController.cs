using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Transform InteractText;

    private int texttype = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (texttype == 1)
        {
            InteractText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        texttype = 0;
        InteractText.gameObject.SetActive(false);
        InteractText = null;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Oil"))
        {

            texttype = 1;

            InteractText = other.gameObject.transform.GetChild(1);


            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(other.gameObject);

                if (Quest.oil_plants < 5) Quest.oil_plants += 1;

                CharacterController.Oil += 20f;
                CharacterController.Oil = Mathf.Min(CharacterController.Oil, 100f);
            }
        }

        if (other.CompareTag("House"))
        {

            texttype = 1;

            InteractText = other.gameObject.transform.GetChild(1);

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Enter the house
            }
        }
    }

}
