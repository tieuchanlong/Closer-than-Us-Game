using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    /*float translation;
    public float speed = 5f;

    public Transform PlayerGFX;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Horizontal") * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift)) transform.Translate(2f * speed * translation, 0f, 0f);
        else transform.Translate(speed * translation, 0f, 0f);

        if (Input.GetAxis("Horizontal") < 0) PlayerGFX.localScale = new Vector3(PlayerGFX.localScale.x * -1, PlayerGFX.localScale.y, PlayerGFX.localScale.z);
        else if (Input.GetAxis("Horizontal") > 0)  PlayerGFX.localScale = new Vector3(PlayerGFX.localScale.x * 1, PlayerGFX.localScale.y, PlayerGFX.localScale.z);
    }*/

    public CharacterController2D controller;
    public GameObject PlayerGFX;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public float runSpeed = 40f;
    public int HP = 100;
    public static float Oil = 100f;

    private bool knockback = false;
    private bool knockRight = false;
    private int knockcount = 0;
    public float knockforcex = 5f;
    public float knockforcey = 5f;

    public static bool takeDmg = false;

    public Image OilBar;
    public Image OilCharge;

    public GameObject WalkingSound;


    void Update()
    {
        //UpdateHealth();

        if (Dialogue.in_conversation == false)
        {
            PlayerMovements();
            UpdateOil();
        }
        
    }

    void PlayerMovements()
    {
        if (knockback == false)
        {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && jump == false)
            {
                WalkingSound.SetActive(true);
            }
            else
            {
                WalkingSound.SetActive(false);
            }

            if (Input.GetKey(KeyCode.LeftShift)) horizontalMove = 2 * Input.GetAxis("Horizontal") * runSpeed;
            else horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
                PlayerGFX.GetComponent<Animator>().SetBool("Jump", true);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                crouch = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                crouch = false;
            }
        }
        else
        {
            knockcount += 1;

            if (knockRight) transform.Translate(knockforcex, knockforcey, 0f);
            else transform.Translate(-knockforcex, knockforcey, 0f);

            if (knockcount == 5)
            {
                knockcount = 0;
                knockback = false;
            }
        }
    }

    public void OnLanding()
    {
        PlayerGFX.GetComponent<Animator>().SetBool("Jump", false);
    }

    void UpdateOil()
    {
        Oil -= 0.5f * Time.deltaTime;
        float width = Oil / 100 * OilBar.rectTransform.rect.width;
        OilCharge.rectTransform.sizeDelta = new Vector2(width, OilCharge.rectTransform.rect.height);
        OilCharge.rectTransform.position = new Vector2(OilBar.rectTransform.position.x - (1f - Oil / 100) * OilBar.rectTransform.rect.width, OilBar.rectTransform.position.y);
    }

    void FixedUpdate()
    {
        // Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            knockback = true;
            if (collision.gameObject.transform.position.x > PlayerGFX.transform.position.x + PlayerGFX.GetComponent<SpriteRenderer>().bounds.size.x / 2) knockRight = false;
            else knockRight = true;
            if (takeDmg == false) takeDmg = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            HP = 0;
        }
    }

}
