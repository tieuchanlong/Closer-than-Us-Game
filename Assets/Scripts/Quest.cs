using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public GameObject QuestBox;
    public int index = -1;
    public string[] quest;
    public static int oil_plants = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (index != -1)
        {
            textDisplay.text = quest[index];
            textDisplay.gameObject.SetActive(true);
            QuestBox.SetActive(true);
        }
        else
        {
            textDisplay.gameObject.SetActive(false);
            QuestBox.SetActive(false);
        }

        Quest1();
    }

    void Quest1()
    {
        if (index == 0)
        {
            if (oil_plants < 5) textDisplay.text = "Find the oil plant " + oil_plants.ToString() + "/5"; 
            else
            {
                index++;
            }
        }

        if (index == 1)
        {
            textDisplay.text = "Bring the plants to the doctor."; 
        }
    }
}
