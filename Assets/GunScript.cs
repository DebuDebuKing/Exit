using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public bool hasBeenPickedup;

    [SerializeField] GameObject bullet;
    [SerializeField] float bulletspeed;
    [SerializeField] float shootingrate;

    [Header("Shooting part")]
    [SerializeField] GameObject shootpart;

    Transform childposition;

    float timer;
    float timerbeforeshoot;
    // Start is called before the first frame update
    void Start()
    {
        childposition = transform.Find("position");
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;

        if (hasBeenPickedup)
        {
            print("Allowed");
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (timer > timerbeforeshoot)
            {
                shootingscript();
                timerbeforeshoot = timer + shootingrate;
            }

        }
    }

    void shootingscript()
    {
        if (bullet != null)
        {
          
            GameObject clone = Instantiate(bullet, childposition.transform.position, childposition.transform.rotation);
            Destroy(clone, 5);
            GameObject clone2 = Instantiate(shootpart, childposition.transform.position, childposition.transform.rotation);
            Destroy(clone2, 5);
        }
        
    }
}
