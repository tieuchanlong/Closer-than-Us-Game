using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI continuetextDisplay;
    public GameObject DialogueBox;
    public string[] sentences;
    public int index_check = 0;
    public static int index;
    public static int initial_index;
    public static int sentence_numbers = 0; // this for counting the number of sentences to be loaded when needed
    public static bool in_conversation = true;
    public float typingSpeed;
    
    IEnumerator Type()
    {
        foreach (char letter in sentences[index])
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = "";
        DialogueBox.SetActive(true);
        textDisplay.gameObject.SetActive(true);
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        index = index_check;
        Debug.Log(sentence_numbers);
        if (index != -1)
        {
            if (textDisplay.text == sentences[index])
            {
                continuetextDisplay.gameObject.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    NextSentence();
                }
            }
            else
            {
                continuetextDisplay.gameObject.SetActive(false);
            }
        }
    }

    public void NextSentence()
    {
        if (index != -1)
        {
            if (index < initial_index + sentence_numbers - 1)
            {
                index++;
                index_check = index;
                textDisplay.text = "";
                StartCoroutine(Type());
            }
            else
            {
                textDisplay.text = "";
                textDisplay.gameObject.SetActive(false);
                continuetextDisplay.gameObject.SetActive(false);
                DialogueBox.SetActive(false);
                index = -1;
                in_conversation = false;
            }
        }
    }
}
