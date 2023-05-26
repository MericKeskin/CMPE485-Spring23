using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollisionScript : MonoBehaviour
{

    IEnumerator WallDown(GameObject effected)
    {
        while (effected.transform.position.y > -20) {
            effected.transform.position -= new Vector3(0, 0.06f, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger") {
            GameObject effected = other.GetComponent<TriggerScript>().relatedObject;
            StartCoroutine(WallDown(effected));
        }
    }

}
