using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConytrols : MonoBehaviour
{
    public int translation = -1;
    public float speed = 50f;
    public int changecnt = 0;
    public bool changedir = false;

    public int HP = 5;
    private bool knocked = false;
    private bool knockRight = false;
    private int knockCnt = 0;
    public float knockSpd = 5;
    private bool attacked = false;
    private int attackCnt = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        translation = Random.Range(0, 1);
        if (translation == 0) translation = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (knocked == false)
        {
            transform.Translate(speed * translation * Time.deltaTime, 0f, 0f);
            transform.localScale = new Vector3(-translation * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            if (changedir == true)
            {
                changecnt += 1;

                if (changecnt > 70)
                {
                    changecnt = 0;
                    changedir = false;
                }
            }
        }
        else
        {
            knockCnt += 1;

            if (knockCnt > 60)
            {
                knocked = false;
            }

            if (knockRight) transform.Translate(knockSpd * Time.deltaTime, 0f, 0f);
            else transform.Translate(-knockSpd * Time.deltaTime, 0f, 0f);
        }

        if (attacked == true)
        {
            attackCnt += 1;
        }

        if (attackCnt >= 60)
        {
            attacked = false;
            attackCnt = -1;
        }

        Die();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Debug.Log("Hey");
            if (changedir == false)
            {
                translation = -translation;
                changedir = true;
            }
        }

        if (other.CompareTag("AttackBox"))
        {
            if (attackCnt == -1)
            {
                attacked = true;
                attackCnt = 0;
                HP -= 1;
            }

            if (CharacterAttacks.attackCnt == 3)
            {
                knockCnt = 0;
                knocked = true;
                if (CharacterAttacks.attackRight)
                {
                    knockRight = true;
                }
                else knockRight = false;
            }
            else
            {
                // That enemy will take damage
            }
        }
    }


    void Die()
    {
        if (HP == 0)
        {
            // Die animation
            Destroy(gameObject);
        }
    }
}
