using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject startPlatform;
    [SerializeField]
    private GameObject dancingLine;
    private Camera mainCamera;
    [HideInInspector]
    public string gameState;
    private AudioManager audioManager;

    IEnumerator LowerStartPlatform()
    {
        while (startPlatform.transform.position.y > -1.5) {
            startPlatform.transform.position -= new Vector3(0, 0.05f, 0);
            dancingLine.transform.position -= new Vector3(0, 0.05f, 0);
            mainCamera.transform.position += new Vector3(0, 0.05f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        gameState = "ready";
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = "prep";
        mainCamera = FindObjectOfType<Camera>();
        audioManager = FindObjectOfType<AudioManager>();
        StartCoroutine(LowerStartPlatform());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == "ready" && Input.GetKeyDown(KeyCode.Space)) {
            audioManager.source.Play();
            gameState = "start";
        }
    }
}
