using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollisionScript : MonoBehaviour
{

    private GameManager gameManager;

    IEnumerator WallDown(GameObject wall, float toPos, float speed)
    {
        while (wall.transform.position.y > toPos) {
            wall.transform.position -= new Vector3(0, speed, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator WallUp(GameObject wall, float toPos, float speed)
    {
        while (wall.transform.position.y < toPos) {
            wall.transform.position += new Vector3(0, speed, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Trigger") {
            TriggerScript trigger = other.GetComponent<TriggerScript>();
            GameObject wall = trigger.relatedObject;
            float toPos = trigger.toPos;
            float speed = trigger.speed;
            
            if (wall.transform.position.y > toPos) {
                StartCoroutine(WallDown(wall, toPos, speed));
            } else {
                StartCoroutine(WallUp(wall, toPos, speed));
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Obstacle") {
            Debug.Log("finish");
        }

    }

    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();

    }

}
