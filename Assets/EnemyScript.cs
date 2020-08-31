using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Transform playerDestination;

    float damage = 0;

    public bool detected = true;


    [SerializeField] float Speed;


    // Start is called before the first frame update
    void Start()
    {
        if (damage == 0) damage = 30;


        playerDestination = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        AttackPlayer();
    }

    void AttackPlayer()
    {
        if (detected)
        {
            Vector2 dir = playerDestination.position - transform.position;
            transform.Translate(dir.normalized * Speed * Time.deltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
       if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().Health -= damage;
        }
    }
}
