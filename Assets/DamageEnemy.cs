using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] float Damage;

    [Header("Parent for sword only")]
    [SerializeField] GameObject parent;
    [SerializeField] GameObject blooddd;
    [SerializeField] TextMesh txt;

    [Header("Disable if  sword")]
    [SerializeField] bool bulletorsword;

    [Header("Only for bullet")]
    [SerializeField] float bulletspeed;
    
    
    private void Start()
    {
        if(!bulletorsword)
        parent = transform.parent.gameObject;

    }
    private void Update()
    {
        if(bulletorsword)
        {
            transform.Translate(Vector2.left * -bulletspeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (!bulletorsword)
            {
                float amt = Random.Range(Damage / 2, Damage);
                int akk = (int)Mathf.Round(amt);
                if (parent.GetComponent<SwordScript>().hasBeenPickedup)
                {
                    collision.gameObject.GetComponent<EnemyHealth>()._Health -= akk;
                    GameObject blood = Instantiate(blooddd, transform.position, Quaternion.identity);
                    Destroy(blood, 0.5f);

                    TextMesh txtt = Instantiate(txt, collision.transform.position, Quaternion.identity);
                    txtt.GetComponent<TextMesh>().text = akk.ToString();
                    txtt.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                    Destroy(txtt, 0.5f);
                }
            }

            else if(bulletorsword)
            {
             

                float amt = Random.Range(Damage / 2, Damage);
                int akk = (int)Mathf.Round(amt);

                collision.gameObject.GetComponent<EnemyHealth>()._Health -= akk;
                GameObject blood = Instantiate(blooddd, transform.position, Quaternion.identity);
                Destroy(blood, 0.5f);

                TextMesh txtt = Instantiate(txt, collision.transform.position, Quaternion.identity);
                txtt.GetComponent<TextMesh>().text = akk.ToString();
                txtt.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                Destroy(txtt, 0.5f);


            }
        }
    }
}
