using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GotoMenu", 2);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
