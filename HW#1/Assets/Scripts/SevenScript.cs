using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenScript : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, -500*Time.deltaTime, 2000*Time.deltaTime);
    }
}
