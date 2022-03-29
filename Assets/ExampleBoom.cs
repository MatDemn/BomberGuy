using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleBoom : MonoBehaviour
{
    public bool boom = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > 5 && !boom) {
            Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();
            foreach(Rigidbody rb in rbs) {
                rb.AddExplosionForce(1000, transform.position, 1f);
            }
            boom = true;
        }
    }
}
