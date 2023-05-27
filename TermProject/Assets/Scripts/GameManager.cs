using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject endMenu;
    [SerializeField]
    private GameObject pauseMenu;
    private bool isPaused = false;

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

        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    public void EndGame()
    {
        audioManager.source.Stop();
        Time.timeScale = 0f;
        canvas.SetActive(true);
        endMenu.SetActive(true);
    }

    public void PauseGame()
    {
        if (isPaused) {
            isPaused = false;
            audioManager.source.UnPause();
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            canvas.SetActive(false);
        } else {
            isPaused = true;
            audioManager.source.Pause();
            Time.timeScale = 0f;
            canvas.SetActive(true);
            pauseMenu.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        endMenu.SetActive(false);
        canvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
