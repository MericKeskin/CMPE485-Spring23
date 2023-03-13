using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenPrefabScript : MonoBehaviour
{
    public GameObject objToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("c")) {
            Instantiate(objToSpawn);
        }
    }
}
