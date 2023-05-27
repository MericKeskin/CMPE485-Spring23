using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{

    private GameManager gameManager;
    // private Rigidbody rb;
    public float rate;
    public float lineSpeed;
    private float x_speed;
    private float z_speed;
    private float temp;
    private Vector3 movement;
    private Vector3 trailPosition;
    [HideInInspector]
    public string lineState;
    private bool tap = false;
    private bool firstTrail = false;
    [SerializeField] private GameObject trailPrefab;

    void Turn()
    {
        temp = x_speed;
        x_speed = z_speed;
        z_speed = temp;
    }

    void TrailLine()
    {
        if (lineState == "ground") {
            trailPosition = transform.position;
            GameObject trail = Instantiate(trailPrefab, trailPosition, transform.rotation);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
        // rb = gameObject.GetComponent<Rigidbody>();
        x_speed = 0;
        z_speed = lineSpeed;
        // lineState = "ground";

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == "start" && lineState == "ground" && Input.GetKeyDown(KeyCode.Space)) {
            tap = true;
        }
    }

    void FixedUpdate()
    {
        if (gameManager.gameState == "ready" && !firstTrail) {
            TrailLine();
            firstTrail = true;
        }
        if (gameManager.gameState == "start") {
            if (tap) {
                Turn();
                TrailLine();
                tap = false;
            }
            movement = new Vector3(x_speed, 0, z_speed);
            transform.position += movement;
            if ((transform.position-trailPosition).magnitude > trailPrefab.transform.localScale.magnitude/2) {
                TrailLine();
            }
        }
    }
}
