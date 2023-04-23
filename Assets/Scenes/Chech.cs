using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chech : MonoBehaviour
{
    private bool inCollision = false;
    private void OnTriggerEnter(Collider other)
    {
        if (inCollision == true)
            return;

        inCollision = true;
        chech1();
        
    }

    private void chech1()
    {
        Debug.Log($"Object: {gameObject.name}");
    }
}
