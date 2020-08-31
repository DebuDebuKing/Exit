using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackScript : MonoBehaviour
{
    [Header("Enable for enemy Against player, disable for player against enemy")]
    [SerializeField] bool enemyOrPlayer;
    [SerializeField] GameObject parent;
    [SerializeField] float kbforce;

    [SerializeField] bool bulletorSword;
    private void Update()
    {
        if (!enemyOrPlayer)
        {

        }
    }
    private void Start()
    {
        if (!enemyOrPlayer)
        {
            if (bulletorSword)
                parent = transform.parent.gameObject;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyOrPlayer)
        {
            if (collision.gameObject.tag == "Player")
            {
                Vector2 dir = collision.gameObject.transform.position - transform.position;


                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir.normalized * kbforce, ForceMode2D.Impulse);
            }
        }

        if (!enemyOrPlayer)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Vector2 dir = collision.gameObject.transform.position - transform.position;


                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir.normalized * kbforce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyOrPlayer)
        {
            if (collision.gameObject.tag == "Player")
            {
                Vector2 dir = collision.gameObject.transform.position - transform.position;


                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir.normalized * kbforce, ForceMode2D.Impulse);
            }
        }

        if (!enemyOrPlayer)
        {
            if (bulletorSword)
            {

                if (parent.GetComponent<SwordScript>().hasBeenPickedup)
                {
                    if (collision.gameObject.tag == "Enemy")
                    {
                        Vector2 dir = collision.gameObject.transform.position - transform.position;

                        print("Sword");
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir.normalized * kbforce, ForceMode2D.Impulse);
                    }
                }
            }
            else if (!bulletorSword)
            {
               
                
                if (collision.gameObject.tag == "Enemy")
                {
                    Vector2 dir = collision.gameObject.transform.position - transform.position;

                    print("Bullet");
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir.normalized * kbforce, ForceMode2D.Impulse);
                }
            }
        }
    }
}



