using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpPhysics : MonoBehaviour
{

    public LayerMask pickMask;
    public Camera camera;
    public Transform pickTarget;
    public float pickRange;
    private Rigidbody rb;
    public TextMeshProUGUI status;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (rb) {
                rb.useGravity = true;
                rb = null;
                return;
            }
            Ray cameraRay = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, pickRange, pickMask)) {
                rb = hitInfo.rigidbody;
                rb.useGravity = false;
                rb.isKinematic = false;
                status.text = "";
            }
        }
    }

    void FixedUpdate()
    {
        if (rb) {
            Vector3 direction = pickTarget.position - rb.position;
            float distance = direction.magnitude;

            rb.velocity = direction * 12f * distance;
        }
    }

}
