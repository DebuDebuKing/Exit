using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float _Health;

    // Update is called once per frame
    void Update()
    {
        if (_Health < 0)
        {
            Destroy(gameObject);
        }
    }
}
