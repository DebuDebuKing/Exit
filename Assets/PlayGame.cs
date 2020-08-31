using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    void Start()
    {
        Invoke("playgame", 1);
    }
    void Update()
    {
       
    }
    public void playgame()

    {
      
        SceneManager.LoadScene("SampleScene");
    }
}
