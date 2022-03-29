using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float destroyTime;

    public bool isEnabled;
    public void Start() 
    {
        if(isEnabled) {
            destroyTime = 1f;
            Destroy(gameObject, destroyTime);
        }
    }
}
