using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectorScript : MonoBehaviour
{
    [Header("The detector for the enemy , place the enemy object")]
    [SerializeField] GameObject theOnetoTellifDetected;

    private void Start()
    {
        if(theOnetoTellifDetected != null)
        theOnetoTellifDetected.GetComponent<EnemyScript>().detected = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (theOnetoTellifDetected != null)
                theOnetoTellifDetected.GetComponent<EnemyScript>().detected = true;
        }
    }
}
