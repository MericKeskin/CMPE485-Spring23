using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMovement : MonoBehaviour
{

    public float trapSpeed = 0.1f;
    private float delta = 0.01f;
    public float max_x = 30;
    public float min_x = -10;
    public float trapWaitTime = 4f;
    private bool willWait;

    IEnumerator TrapMove()
    {
        while (true) {
            willWait = false;
            transform.position = transform.position + new Vector3(trapSpeed, 0, 0);
            if ((transform.position.x > max_x) || (transform.position.x < min_x)) {
                willWait = true;
                trapSpeed = trapSpeed * -1;
            }
            yield return new WaitForSeconds(willWait ? trapWaitTime : delta);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            other.transform.parent = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TrapMove());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
