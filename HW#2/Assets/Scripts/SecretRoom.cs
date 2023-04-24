using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoom : MonoBehaviour
{

    public GameObject secretWall;
    public float wallSpeed = 0.1f;
    Coroutine currentCo;

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OpenWall()
    {
        while (true) {
            secretWall.transform.position = secretWall.transform.position + new Vector3(0, wallSpeed, 0);
            if (secretWall.transform.position.y > 77.4) {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator CloseWall()
    {
        while (true) {
            secretWall.transform.position = secretWall.transform.position + new Vector3(0, -wallSpeed, 0);
            if (secretWall.transform.position.y < 68.4) {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            if (currentCo != null) {
                StopCoroutine(currentCo);
            }
            currentCo = StartCoroutine(OpenWall());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            if (currentCo != null) {
                StopCoroutine(currentCo);
            }
            currentCo = StartCoroutine(CloseWall());
        }
    }
}
