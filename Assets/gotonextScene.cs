using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotonextScene : MonoBehaviour
{
    [SerializeField] string scenenanme;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D col)
    {
     if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scenenanme);
        }
    }
}
