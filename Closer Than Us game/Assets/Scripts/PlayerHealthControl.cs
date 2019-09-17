using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthControl : MonoBehaviour
{
    public Image HealthBar;
    public Image Health;

    private int HPdectime = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(CharacterController.takeDmg);
        if (CharacterController.takeDmg == true && HPdectime == -1)
        {
            HPdectime = 0;
            GetComponent<CharacterController>().HP -= 10;
            GetComponent<CharacterController>().HP = Mathf.Max(GetComponent<CharacterController>().HP, 0);
            Debug.Log("Dec");
        }

        if (HPdectime >= 0) HPdectime += 1;

        if (HPdectime == 60)
        {
            CharacterController.takeDmg = false;
            HPdectime = -1;
        }

        UpdateHealth();
    }

    void UpdateHealth()
    {
        float width = (float)GetComponent<CharacterController>().HP / 100 * HealthBar.rectTransform.rect.width;
        Health.rectTransform.sizeDelta = new Vector2(width, Health.rectTransform.rect.height);
        Health.rectTransform.position = new Vector2(HealthBar.rectTransform.position.x - (1f - (float)GetComponent<CharacterController>().HP / 100) * HealthBar.rectTransform.rect.width, HealthBar.rectTransform.position.y);

    }
}
