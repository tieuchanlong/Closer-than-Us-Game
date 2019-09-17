using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttacks : MonoBehaviour
{
    public GameObject AttackBox;
    public GameObject AttackBox1;
    private float waitTime = 0f;
    public float attackTime = 2f;

    public static bool attack = false;
    public static bool attackRight = true;

    public static int attackCnt = 0;

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0)
        {
            attackRight = true;
        }
        else attackRight = false;

        if (Input.GetMouseButtonDown(0) && attack == false)
        {
            if (attackRight) AttackBox.SetActive(true);
            else AttackBox1.SetActive(true);
            attack = true;
            waitTime = 0f;
            attackCnt += 1;
            if (attackCnt == 4) attackCnt = 1;
        }

        if (attack == true)
        {
            waitTime += Time.deltaTime;

            if (waitTime >= attackTime)
            {
                attack = false;
            }

            animator.SetBool("Attack", attack);
        }
        else
        {
            AttackBox.SetActive(false);
            AttackBox1.SetActive(false);

            animator.SetBool("Attack", attack);
        }
    }
}
