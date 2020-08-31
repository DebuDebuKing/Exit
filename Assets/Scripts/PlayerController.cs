using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float Health;
    [SerializeField] TextMesh txtt;

    [SerializeField]
    float HORIZONTAL;
    float VERTICAL;

    [Header("Movement")]
    public float movementSpeed;

    [Header("Weapon")]
    [SerializeField] Text txt;
    [SerializeField] GameObject weapon;
    [Header("Enable if Range , Disable for Melee")]
    public bool WeaponType;//


    //to check if im holding weapon
    bool amiusing;

    [SerializeField]
    bool mimim;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
      

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        WeaponPickUP();

        if(Health <= 0)
        {
            SceneManager.LoadScene("Menu");
        }

        txtt.GetComponent<TextMesh>().text = "Health:" + Health;

        if (weapon != null)
            weapon.transform.position = transform.position;

        dropWeapon();

        if(Input.GetKeyUp(KeyCode.E))
        {
            if(mimim)
            {
                mimim = false;
            }
        }
    }

    void movement()
    {
        HORIZONTAL = Input.GetAxisRaw("Horizontal");
        VERTICAL = Input.GetAxisRaw("Vertical");

        Vector2 Dir = new Vector2(HORIZONTAL * movementSpeed * Time.deltaTime, VERTICAL * movementSpeed * Time.deltaTime);
        transform.Translate(Dir);

        Vector3 lm = new Vector2(transform.localScale.x, transform.localScale.y);
        Vector2 lo = new Vector2(-transform.localScale.x, transform.localScale.y);


    }

    public void WeaponPickUP()
    {
        if (weapon != null)
        {
            if (!WeaponType)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    print("Swing");
                    WeaponSettings();
                    weapon.gameObject.SetActive(true);

                }
                else if (Input.GetMouseButtonUp(0))
                {
                    weapon.gameObject.SetActive(false);
                }
            }
            
            if(WeaponType)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    print("Shoot");
                    WeaponSettings();
                    weapon.gameObject.SetActive(true);

                }
                else if (Input.GetMouseButtonUp(0))
                {
                    weapon.gameObject.SetActive(false);
                }
            }
        }
    }
  
    private void OnCollisionStay2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Weapon")
            {
                print("Picked");
            if (Input.GetKeyDown(KeyCode.E) && weapon == null)
            {
                if (weapon == null)
                {
               
                    collision.gameObject.transform.parent = transform;
                    collision.gameObject.transform.position = transform.position;
                    weapon = collision.gameObject;

                    collision.gameObject.SetActive(false);
                    collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

                   
                    if(weapon.name.Contains("Sword"))
                    {
                        WeaponType = false;
                    }
                    else if(weapon.name.Contains("Gun"))
                    {
                        WeaponType = true;
                    }
                }

                if (weapon != null && Input.GetKey(KeyCode.E))
                {
                    weapon = collision.gameObject;
                }
                mimim = true;
            }
           
           }
        }
    

    void WeaponSettings()
    {


        {
            if (weapon.name.Contains("Sword"))
            {
                weapon.GetComponent<SwordScript>().hasBeenPickedup = true;

                print("Swing");

            }

            else if(weapon.name.Contains("Gun"))
            {
           
                weapon.GetComponent<GunScript>().hasBeenPickedup = true;
            }
        }

    }
    void dropWeapon()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (weapon != null && mimim == false)
            {
                if (WeaponType)
                {
                    weapon.SetActive(true);
                    weapon.GetComponent<GunScript>().hasBeenPickedup = false;
                    weapon.transform.parent = null;

                    weapon.GetComponent<BoxCollider2D>().isTrigger = false;
                    print("Spawned");
                    weapon = null;
                }
                else if(!WeaponType)
                {
                    weapon.SetActive(true);
                    weapon.GetComponent<SwordScript>().hasBeenPickedup = false;
                    weapon.transform.parent = null;

                    weapon.GetComponent<BoxCollider2D>().isTrigger = false;
                    print("Spawned");
                    weapon = null;
                }
            }
        }
    }
}
