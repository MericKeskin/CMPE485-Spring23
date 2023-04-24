using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyScript : MonoBehaviour
{

    public TextMeshProUGUI status;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            status.text = "Press E to pick up";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            status.text = "";
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Door") {
            FindObjectOfType<GameManager>().WinGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
